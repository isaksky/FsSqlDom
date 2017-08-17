open System
open System.IO
open System.Text
open System.Data
open System.Data.SqlClient
open System.Collections.Generic

#r "../lib/Microsoft.SqlServer.TransactSql.ScriptDom.dll"
#r "../bin/FsSqlDom/FsSqlDom.dll"

open Microsoft.SqlServer.TransactSql.ScriptDom
open System.Reflection
open FSharp.Reflection

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

let query_expr = 
  match parse "select top 10 foo from bar where baz = zap" with
  | Choice1Of2 expr -> expr
  | Choice2Of2 _errs -> failwith "Bad query"

type StringTree(var_id: int) =
  member val children = ResizeArray<StringTree>() with get
  member val sb = StringBuilder() with get
  member x.var_id = var_id

let prop_checksum (pi: PropertyInfo) = pi.Name + "_" + pi.PropertyType.FullName

let base_props = typeof<TSqlFragment>.GetProperties() |> Array.map prop_checksum |> Set.ofArray

let get_props_to_init (expr: TSqlFragment) =
  expr.GetType().GetProperties()
  |> Array.filter (fun pi -> not (Set.contains (prop_checksum pi) base_props))

let rec render (sb:StringBuilder) (tree:StringTree) =
  for c in tree.children do render sb c
  sb.Append (tree.sb.ToString()) |> ignore

let get_cs_build_str (expr: TSqlFragment) : string =
  let mutable var_id = 0
  let root = StringTree(1)



  let rec add (expr: TSqlFragment) (tree: StringTree) =
    let sb = tree.sb
    let var = sprintf "var%d" tree.var_id
    sb.wl "let %s = %s()" var (expr.GetType().Name)

    for pi in get_props_to_init expr do
      let typ = pi.PropertyType
      if typ.IsGenericType then
        let genTp = typ.GetGenericTypeDefinition()
        match typ.GetGenericArguments() with
        | [|gentypA|] ->
          let cleanName = typ.Name.Substring(0, (typ.Name.Length - 2))
          match cleanName with
          | "IList" ->
            let xs = pi.GetValue(expr) :?> obj seq
            for o in xs do
              var_id <- var_id + 1
              sb.wl "%s.%s.Add var%d" var (pi.Name) var_id
              let sub = StringTree(var_id)
              tree.children.Add(sub)
              let v = pi.GetValue(expr)
              addI v sub
            //sprintf "(%s) list" (x.getDestTypeName gentypA)
            //failwith "no lists"
          | "Nullable" ->
            failwith "no nullable"
            //sprintf "(%s) option" (x.getDestTypeName gentypA)
          | _ -> failwith ""
            // sprintf "%s<%s>" cleanName (gentypA.Name)
        | x -> failwithf "Unhandled gen arguments ary: %A" x
      elif typ.IsEnum then
        sb.wl "%s.%s <- %A" var (pi.Name) (expr.ToString())
      elif typ.IsValueType then
        sb.wl "%s.%s <- %A" var (pi.Name) (pi.GetValue(expr))
      else
        var_id <- var_id + 1
        sb.wl "%s.%s <- var%d" var (pi.Name) var_id
        let sub = StringTree(var_id)
        tree.children.Add(sub)
        let v = pi.GetValue(expr)
        add v sub
  
  and addI (o: obj) (tree: StringTree) =
    match o with
    | :? seq<TSqlFragment> as frags ->
      for f in frags do add f tree
    | :? TSqlFragment as f -> add f tree
    | :? string as s ->
      tree.sb.wl "let var%d = %A" tree.var_id s
    | x -> tree.sb.wl "// what is %A ? " x

  add expr root
  let sb = StringBuilder()
  render sb root
  sb.ToString()

let s = get_cs_build_str query_expr