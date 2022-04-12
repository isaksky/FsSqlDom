module FsSqlDomGallery.SyntaxBuilding

open System
open System.IO
open System.Text
open System.Collections.Generic

open Microsoft.SqlServer.TransactSql.ScriptDom
open System.Reflection
open Microsoft.FSharp.Reflection

type StringBuilder with
    // Write with format string
    member this.w fmt =
      let cont (s:string) =
        this.Append(s) |>ignore
      Printf.kprintf cont fmt
    // WriteLine with format string
    member this.wl fmt =
      let cont (s:string) =
        if s.Length > 0 then
          this.AppendLine(s) |>ignore
      Printf.kprintf cont fmt
    // Write plain string
    member this.ws (s:string) = this.Append(s) |> ignore
    // Write character
    member this.wc (c:char) = this.Append(c) |> ignore

type Type with
  member x.TreeName =
    "ScriptDom." + x.Name

let parse (sql:string) =
  let parser = TSql140Parser(false)
  let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
  use tr = new StringReader(sql) :> TextReader
  let res = parser.Parse(tr, &errs)

  if errs.Count = 0 then
    Choice1Of2(res)
  else
    Choice2Of2(errs)

type CodeNode() =
  member val is_inline = false with get, set
  member val var_id = 0 with get, set
  member val prop_name = "" with get, set
  member val format_str = "" with get, set
  member val is_list_prop = false with get, set
  member val dependencies = ResizeArray<CodeNode>() with get, set
  member val list_dependencies = ResizeArray<CodeNode>() with get, set
  member val friendly_type_name = "" with get, set

let combine_sbs (b:StringBuilder) (a:StringBuilder) =
  let a = a.ToString().Trim()
  if a.Length > 0 then
    a + "\n" + b.ToString()
  else b.ToString()

let prop_checksum (pi: PropertyInfo) = pi.Name + "_" + pi.PropertyType.FullName

let base_props = typeof<TSqlFragment>.GetProperties() |> Array.map prop_checksum |> Set.ofArray

let get_props_to_init (expr: TSqlFragment) (default_instance: TSqlFragment) =
  expr.GetType().GetProperties()
  |> Array.filter 
    (fun pi -> 
      let is_base_prop = Set.contains (prop_checksum pi) base_props
      let is_indexer = pi.GetIndexParameters().Length > 0

      let is_mut =
        if pi.CanWrite then 
          true
        else
          let cleanName = pi.PropertyType.Name.Substring(0, (pi.PropertyType.Name.Length - 2))
          match cleanName with
          | "IList" -> true
          | _ -> false

      let should_init = is_mut && (not is_indexer) && (not is_base_prop)
      
      // Skip values same as the default for type using parameterless ctor
      should_init && pi.GetValue(expr) <> pi.GetValue(default_instance) )

let is_simple_inline_prop (pi:PropertyInfo) =
  pi.PropertyType.IsValueType || pi.PropertyType.IsEnum || pi.PropertyType = typeof<string>

let friendly_var_name (node: CodeNode) = 
  sprintf "%s%d" node.friendly_type_name node.var_id

let rec render (tree: CodeNode) (fsharp_syntax:bool) : string =
  let rendered = HashSet<int>()
  let rec render' (tree:CodeNode) : string * string =
    
    if tree.is_inline then
      let pre_sb = StringBuilder()
      let pre_pre_sb = StringBuilder()

      let depstmp = ResizeArray<obj>()
      for node in tree.dependencies do
        let pre, cur = render' node
        pre_sb.wl "%s" pre
        depstmp.Add (box cur)
    
      let deps : obj[] = Array.ofSeq depstmp
      let cur = String.Format(tree.format_str, deps)

      let pre = 
        pre_pre_sb
        |> combine_sbs pre_sb
      pre, cur
    else
      let pre_sb = StringBuilder()

      let vname = friendly_var_name tree

      if rendered.Contains tree.var_id then
        "", vname
      else
        let depstmp = ResizeArray<obj>()

        for node in tree.dependencies do
          let pre, cur = render' node
          if pre <> "" then
            pre_sb.wl "%s" pre

          depstmp.Add (box cur)

        let deps : obj[] = depstmp |> Array.ofSeq
        let decl = String.Format(tree.format_str, deps)
        let list_sb_inline = StringBuilder()
        let list_sb = StringBuilder()
        let mutable statement_sep = ""
        for list_prop in tree.list_dependencies do
          for node in list_prop.dependencies do
            statement_sep <- "\n"
            let npre, ncur = (render' node)
            if npre.Trim() <> "" then 
              list_sb.wl "%s" npre
            list_sb_inline.w "%s.%s.Add (%s)" vname (list_prop.prop_name) ncur
            if not fsharp_syntax then list_sb_inline.wc ';'
            list_sb_inline.wc '\n'
    
        let pre =
          (pre_sb
          |> combine_sbs list_sb
          |> fun x -> x.ToString())
          + (if list_sb.Length > 0 then "\n" else "") 
          + if fsharp_syntax then 
              (sprintf "let %s = %s" vname decl)
            else
              (sprintf "var %s = %s;" vname decl)
          + statement_sep
          + list_sb_inline.ToString()
      
        rendered.Add (tree.var_id) |> ignore
        pre, vname
  let pre, cur = render' tree
  pre


let simple_literal (typ:Type) (o:obj) =
  
  if typ.IsEnum then
    typ.Name + "." + (o.ToString())
  elif typ.IsValueType then
    sprintf "%A" o
  elif typ = typeof<string> then
    sprintf "\"%s\"" (o :?> string)
  else
    failwith "not a simple type"

let get_cs_build_str (expr: TSqlFragment) (reuse_vars: bool) (fsharp_syntax: bool) : string =
  let var_id = ref 0
  let root = CodeNode(var_id = !var_id)

  let existing_vars = Dictionary<FsSqlDom.Dom.TSqlFragment, CodeNode>(HashIdentity.Structural)

  let rec addTop (expr: TSqlFragment) (tree: CodeNode) =
    let sb = StringBuilder()
    sb.w "%s" (expr.GetType().TreeName)

    addProps expr tree
    
    tree.is_inline <- false

  and addProps (expr: TSqlFragment) (tree: CodeNode) : unit =
    (* Yup. 😎 *)
    let instance_default = Activator.CreateInstance(expr.GetType())  :?> TSqlFragment
    let mutable i = 0
    let prop_inits = ResizeArray<string>()
    tree.is_inline <- true
    for pi in get_props_to_init expr instance_default do
      let typ = pi.PropertyType
      let v = pi.GetValue(expr)
      match getInner v (pi.Name) (pi.PropertyType) with
      | None -> ()
      | Some child ->
        if not child.is_inline then tree.is_inline <- false
        if child.is_list_prop then
          tree.list_dependencies.Add child
          tree.is_inline <- false
        else
          tree.dependencies.Add child
          prop_inits.Add (sprintf "%s = {%d}" pi.Name i)
          i <- i + 1
    if fsharp_syntax then
      tree.format_str <- sprintf "%s(%s)" (expr.GetType().TreeName) (prop_inits |> String.concat ", ")
    else
      let arg_str =
        if prop_inits.Count > 0 then
          sprintf " {{ %s }}" (prop_inits |> String.concat ", ")
        else "()"
      tree.format_str <- sprintf "new %s%s" (expr.GetType().TreeName) arg_str
    tree.friendly_type_name <- 
      let s = expr.GetType().Name
      Char.ToLowerInvariant(s.[0]).ToString() + s.Substring(1)
            
  and getInner (o: obj) (pname:string) (ptyp:Type) : CodeNode option =
    if ptyp.IsEnum then
      CodeNode
        ( prop_name = pname, 
          is_inline = true, 
          format_str = sprintf "%s" (ptyp.TreeName + "." + (o.ToString())))
      |> Some
    elif ptyp.IsValueType then
      CodeNode
          ( prop_name = pname, 
            is_inline = true, 
            format_str = sprintf "%A" o)
      |> Some
    else
      match o with
      | null -> None
      | :? string as s ->
        let escaped_s = s.Replace("{", "{{").Replace("}", "}}")
        CodeNode
          ( prop_name = pname, 
            is_inline = true, 
            format_str = "\"" + escaped_s + "\"")
        |> Some
      | :? TSqlFragment as frag ->
        if reuse_vars then
          let fs_frag = FsSqlDom.Dom.TSqlFragment.FromCs(frag, null)
          match existing_vars.TryGetValue(fs_frag) with
          | false, _ ->
            let inner = CodeNode(prop_name = pname)
            addProps frag inner
        
            if not inner.is_inline then 
              incr var_id
              inner.var_id <- !var_id
            existing_vars.Add(fs_frag, inner)
            Some inner
          | true, codenode ->
            Some codenode          
        else

          let inner = CodeNode(prop_name = pname)
          addProps frag inner
        
          if not inner.is_inline then 
            incr var_id
            inner.var_id <- !var_id

          Some inner
      | :? seq<obj> as xs ->
        let list_prop = CodeNode(prop_name = pname, is_list_prop = true)
        for x in xs do
          match getInner x "" (x.GetType()) with
          | None -> ()
          | Some child ->
            list_prop.dependencies.Add child 
        incr var_id
        list_prop.var_id <- !var_id
        Some list_prop
      | x -> failwithf "Unhandled value: %A" x
      //| x -> tree.sb.wl "// what is %s %A ? " (ptyp.Name) x

  addTop expr root
  render root fsharp_syntax

type SyntaxException(msg, errors) =
  inherit Exception(msg)
  member x.errors = errors

let build_syntax(sql_query:string, reuse_vars: bool, fsharp_syntax: bool) : string =
  let parser = TSql140Parser(false)
  let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
  use tr = new StringReader(sql_query) :> TextReader
  let res = parser.Parse(tr, &errs)

  if errs.Count = 0 then
    get_cs_build_str res reuse_vars fsharp_syntax
  else
    raise <| SyntaxException("Invalid SQL", ResizeArray<_>(errs))
