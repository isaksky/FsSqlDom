module FsSqlDomGallery.SyntaxBuilding

open System
open System.IO
open System.Text
open System.Collections.Generic

open Microsoft.SqlServer.TransactSql.ScriptDom
open System.Reflection
open Microsoft.FSharp.Reflection

open FsSqlDom

type StringBuilder with
    // Write with format string
    member this.w fmt =
      let cont (s:string) =
        this.Append(s) |>ignore
      Printf.kprintf cont fmt
    // WriteLine with format string
    member this.wl fmt =
      let cont s =
        this.AppendLine(s) |>ignore
      Printf.kprintf cont fmt
    // Write plain string
    member this.ws (s:string) = this.Append(s) |> ignore
    // Write character
    member this.wc (c:char) = this.Append(c) |> ignore

let parse (sql:string) =
  let parser = TSql130Parser(false)
  let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
  use tr = new StringReader(sql) :> TextReader
  let res = parser.Parse(tr, &errs)

  if errs.Count = 0 then
    Choice1Of2(res)
  else
    Choice2Of2(errs)

type StringTree(var_id: int) =
  member val children = ResizeArray<StringTree>() with get
  member val sb = StringBuilder() with get
  member x.var_id = var_id

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

let rec render (sb:StringBuilder) (tree:StringTree) =
  for c in tree.children do render sb c
  sb.Append (tree.sb.ToString()) |> ignore

let simple_literal (typ:Type) (o:obj) =
  
  if typ.IsEnum then
    typ.Name + "." + (o.ToString())
  elif typ.IsValueType then
    sprintf "%A" o
  elif typ = typeof<string> then
    sprintf "\"%s\"" (o :?> string)
  else
    failwith "not a simple type"

let get_cs_build_str (expr: TSqlFragment) : string =
  let var_id = ref 0
  let root = StringTree(!var_id)  

  let rec addTop (expr: TSqlFragment) (tree: StringTree) =
    let sb = tree.sb
    let var = sprintf "var%d" tree.var_id
    sb.w "let %s = %s(" var (expr.GetType().Name)

    (* Yup. 😎 *)
    let instance_default = Activator.CreateInstance(expr.GetType())  :?> TSqlFragment

    let props = get_props_to_init expr instance_default

    if Array.forall is_simple_inline_prop props then
      seq {
        for i = 0 to props.Length - 1 do
          let pi = props.[i]
          let o = pi.GetValue(expr)
          match o with
          | null -> ()
          | _ ->
            //if o <> pi.GetValue(instance_default) then // don't care about props that are same as the default
            yield sprintf "%s = %s" (pi.Name) (simple_literal (pi.PropertyType) o)
      } |> String.concat ", " |> sb.ws
      sb.ws ")\n"
    else
      sb.ws ")\n"
      for pi in get_props_to_init expr instance_default do
        let typ = pi.PropertyType
        let v = pi.GetValue(expr)
        //if v <> pi.GetValue instance_default then
        addInner v var (pi.Name) (pi.PropertyType) tree     
            
  and addInnerListMember (o: obj) (var:string) (pname:string) (parent_tree: StringTree) =
    if Object.ReferenceEquals(null, o) then
      ()
    else
      let typ = o.GetType()
      if typ.IsEnum then
        parent_tree.sb.wl "%s.%s.Add (%s)" var pname (simple_literal typ o)
      elif typ.IsValueType then
        parent_tree.sb.wl "%s.%s.Add (%s)" var pname (o.ToString())
      else
        match o with
        | :? TSqlFragment as frag ->
          incr var_id
          parent_tree.sb.wl "%s.%s.Add var%d" var pname !var_id
          let sub = StringTree(!var_id)
          parent_tree.children.Add sub
          addTop frag sub
        | x -> failwithf "Unhandled value: %A" x

  and addInner (o: obj) (parent_var:string) (pname:string) (ptyp:Type) (tree: StringTree) =
    if ptyp.IsEnum then
      tree.sb.wl "%s.%s <- %s" parent_var pname (ptyp.Name + "." + (o.ToString()))
    elif ptyp.IsValueType then
      tree.sb.wl "%s.%s <- %A" parent_var pname o
    else
      match o with
      | null -> ()
      | :? string as s ->
        tree.sb.wl "%s.%s <- %A" parent_var pname o
      | :? TSqlFragment as frag ->
        incr var_id

        tree.sb.wl "%s.%s <- var%d" parent_var pname !var_id
        let sub = StringTree(!var_id)
        tree.children.Add sub
        addTop frag sub
      | :? seq<obj> as xs ->
        for x in xs do
          addInnerListMember x parent_var (pname) tree
      | x -> tree.sb.wl "// what is %s %A ? " (ptyp.Name) x

  addTop expr root
  let sb = StringBuilder()
  render sb root
  sb.ToString()

type SyntaxException(msg, errors) =
  inherit Exception(msg)
  member x.errors = errors

let build_syntax (sql_query:string) : string =
  let parser = TSql130Parser(false)
  let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
  use tr = new StringReader(sql_query) :> TextReader
  let res = parser.Parse(tr, &errs)

  if errs.Count = 0 then
    get_cs_build_str res
  else
    raise <| SyntaxException("Invalid SQL", ResizeArray<_>(errs))
