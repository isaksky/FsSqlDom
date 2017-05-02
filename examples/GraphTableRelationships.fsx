open System
open System.IO
open System.Data
open System.Data.SqlClient
open System.Collections.Generic

#r "../lib/Microsoft.SqlServer.TransactSql.ScriptDom.dll"
#r "../bin/FsSqlDom/FsSqlDom.dll"

open Microsoft.SqlServer.TransactSql
open FsSqlDom.Dom

let conn = 
  let connb = SqlConnectionStringBuilder(DataSource="ISAK-NEW\\SQLEXPRESS", IntegratedSecurity = true, InitialCatalog = "AdventureWorks2014")
  let conn = new SqlConnection((connb.ConnectionString))
  conn.Open()
  conn

type StatementDef = { name: string; type_desc:string; sql: string}

let fetchDefs() =
  use cmd = conn.CreateCommand()
  cmd.CommandText <- "select o.name, o.type_desc, m.definition
from sys.sql_modules m
join sys.objects o on m.object_id = o.object_id"
  use rdr = cmd.ExecuteReader()
  let ret = ResizeArray<_>()
  while rdr.Read() do
    let def : StatementDef = { name = rdr.GetString(0); type_desc = rdr.GetString(1); sql = rdr.GetString(2) }
    ret.Add def
  ret

let normalizeTablename (tname:string) =
  if tname.StartsWith("dbo.") then tname.Substring(4) else tname

let fetchTables() =
  use cmd = conn.CreateCommand()
  cmd.CommandText <- "select s.name + '.' + t.name from sys.tables t join sys.schemas s on t.schema_id = s.schema_id
 where t.is_ms_shipped = 0
 union all
 select s.name + '.' + v.name from sys.views v join sys.schemas s on v.schema_id = s.schema_id"
  use rdr = cmd.ExecuteReader()
  let ret = HashSet<_>()
  while rdr.Read() do ignore <| (ret.Add <| rdr.GetString(0))
  for t in (Array.ofSeq ret) do ret.Add (normalizeTablename t) |> ignore
  ret

let parse (sql:string) =
  let parser = ScriptDom.TSql130Parser(false)
  let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
  use tr = new StringReader(sql) :> TextReader
  let res = parser.Parse(tr, &errs)

  if errs.Count = 0 then
    Choice1Of2(res)
  else
    Choice2Of2(errs)

type Ops =
  static member GetName(ident:Identifier) : string =
    match ident with
    | Identifier.Base(QuoteType=quoteType; Value=Some(v)) -> v
    | _ -> failwith "Not implemented yet"
      
  static member GetName(mult:MultiPartIdentifier) : string list  =
    match mult with
    | MultiPartIdentifier.SchemaObjectName(so) -> Ops.GetName so
    | MultiPartIdentifier.Base(count, identifiers) -> identifiers |> List.map Ops.GetName 
      
  static member GetName(so:SchemaObjectName) : string list  =
    match so with
    | SchemaObjectName.ChildObjectName(baseIdentifier, childIdentifier, count, databaseIdentifier, identifiers, schemaIdentifier, serverIdentifier) -> failwith "Not implemented yet"
    | SchemaObjectName.SchemaObjectNameSnippet(baseIdentifier, count, databaseIdentifier, identifiers, schemaIdentifier, script, serverIdentifier) -> failwith "Not implemented yet"
    | SchemaObjectName.Base(Identifiers=identifiers) -> 
      identifiers |> List.map Ops.GetName 
  
  static member GetName(idOrVal:IdentifierOrValueExpression) : string  =
    match idOrVal with
    | IdentifierOrValueExpression.IdentifierOrValueExpression(Identifier=Some(ident)) ->
      Ops.GetName ident
    | _ -> failwith "Can't get name of expr without identifier"

  static member GetName(so:SchemaObjectNameOrValueExpression) : string list  =
    match so with
    | SchemaObjectNameOrValueExpression.SchemaObjectNameOrValueExpression(SchemaObjectName=Some(son)) ->
      Ops.GetName(son)
    | _ -> failwith "Can't get name, missing schema object"

  static member GetName(tra:TableReferenceWithAlias) : string option * string list =
    match tra with
    | TableReferenceWithAlias.NamedTableReference(Alias=alias; SchemaObject=Some(schemaObject)) -> 
      (alias |> Option.map Ops.GetName), (Ops.GetName(schemaObject))
    | _ -> failwith "Not implemented yet"

let getScalarColRefs (sexpr:ScalarExpression) =
  let colRefs = ResizeArray<_>()
  sexpr.ToCs().Accept(
    { new ScriptDom.TSqlFragmentVisitor() with
            override x.ExplicitVisit(cr:ScriptDom.ColumnReferenceExpression) =
              cr.MultiPartIdentifier 
              |> MultiPartIdentifier.FromCs 
              |> fun x -> 
                match Ops.GetName x with
                | [pfx; _colname] -> colRefs.Add pfx
                | _ -> ()
              })
  colRefs

type JoinAnalyzer() =


  member val tableToAlias = Dictionary<string, string>()
  member val aliasToTable = Dictionary<string, string>()
  //member val mappings = Dictionary<string, string>()
  member val tables = HashSet<string>()
  member val condConnections = HashSet<string*string>()

  member x.AddMapping(tname:string, alias: string option) =
    let tname = normalizeTablename tname
    printfn "Adding %s..." tname
    match alias with
    | Some(alias) -> 
      x.tableToAlias.Add(tname, alias)
      x.aliasToTable.[alias] <- tname
    | None -> ()
    ignore <| x.tables.Add tname

  member x.ResolveTable (t:string) =
    let t = normalizeTablename t
    if x.tables.Contains t then Some t
    else 
      let ok, v = x.aliasToTable.TryGetValue t
      if ok then Some(v) else None

  member x.AddJoinedTablesOrAliases t1 t2 =
    match ((x.ResolveTable t1), (x.ResolveTable t2)) with
    | Some a, Some b -> ignore <| x.condConnections.Add (a, b)
    | _, _ -> ()

  member x.AddConditions(bexpr:BooleanExpression) =
    match bexpr with
    | BooleanExpression.BooleanComparisonExpression(_comparisonType, Some(firstExpression), Some(secondExpression)) ->
      let first = getScalarColRefs firstExpression
      let second = getScalarColRefs secondExpression
      for t1 in first do
        for t2 in second do
          x.AddJoinedTablesOrAliases t1 t2
    | BooleanExpression.BooleanParenthesisExpression(Some(expression)) -> x.AddConditions(expression)
    | BooleanExpression.BooleanBinaryExpression(_binaryExpressionType, Some(firstExpression), Some(secondExpression)) ->
      x.AddConditions firstExpression
      x.AddConditions secondExpression
    | _ -> ()

let rec processJoins (ctx:JoinAnalyzer) (table:TableReference) (depth:int) : unit =
  match table with
  | TableReference.TableReferenceWithAlias
      (TableReferenceWithAlias.NamedTableReference
        (Alias=alias; SchemaObject=Some
          (schemaObject))) ->
          let aliasName = alias |> Option.map (Ops.GetName)
          let name = Ops.GetName schemaObject |> String.concat "."
          ctx.AddMapping (name, aliasName)

  | TableReference.JoinParenthesisTableReference(Some(join)) ->
    processJoins ctx join (depth + 1)
  | TableReference.JoinTableReference(join) ->
    match join with
    | JoinTableReference.UnqualifiedJoin(FirstTableReference=Some(firstTableReference); SecondTableReference=Some(secondTableReference)) ->
      processJoins ctx firstTableReference depth
      processJoins ctx secondTableReference depth
    | JoinTableReference.QualifiedJoin(FirstTableReference=Some(firstTableReference); SecondTableReference=Some(secondTableReference); SearchCondition=searchCond) ->
      processJoins ctx firstTableReference depth
      processJoins ctx secondTableReference depth
      searchCond |> Option.iter (fun searchCond -> ctx.AddConditions searchCond)
    | _ -> ()
  | x ->
    let s = x.ToCs() |> FsSqlDom.Util.renderCs
    failwithf "Don't know how to get table name for %A" s

let findFromClause (frag:ScriptDom.TSqlFragment) =
  let mutable ret = None
  let vis =
      { new ScriptDom.TSqlFragmentVisitor() with
          override x.ExplicitVisit(fromC:ScriptDom.FromClause) =
            ret <- Some(fromC) }
  frag.Accept(vis)
  ret

// Taken from http://visjs.org/examples/network/basicUsage.html
let [<Literal>] html = """
<!doctype html>
<html>
<head>
  <title>Network | Basic usage</title>
  <link href="https://cdnjs.cloudflare.com/ajax/libs/vis/4.19.1/vis.min.css" rel="stylesheet" type="text/css" />

  <style type="text/css">
    #mynetwork {
      width: 600px;
      height: 400px;
      border: 1px solid lightgray;
    }
  </style>
</head>
<body>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/vis/4.19.1/vis.min.js"></script>
<p>
  Create a simple network with some nodes and edges.
</p>

<div id="mynetwork"></div>

<script type="text/javascript">
  %s
  // create a network
  var container = document.getElementById('mynetwork');
  var data = {
    nodes: nodes,
    edges: edges
  };
  var options = {};
  var network = new vis.Network(container, data, options);
</script>
</body>
</html>
  """

let visualize (rels:Set<string*string>) =
  let script =
    let mutable nextId = 0
    let ids = Dictionary<string, int>()
    let mkId tname =
      let ok, id = ids.TryGetValue tname
      if ok then id else
        let id = nextId
        ids.[tname] <- nextId;
        nextId <- nextId + 1
        id

    let w (sb:Text.StringBuilder) s : unit = sb.AppendLine s |> ignore
    let edges = Text.StringBuilder()
    w edges "var edges = new vis.DataSet(["

    let nodes = Text.StringBuilder()
    w nodes "var nodes = new vis.DataSet(["

    for (a, b) in rels do
      let aid = mkId a
      let bid = mkId b
      w edges (sprintf "{from: %d, to: %d}," aid bid)

    for KeyValue(tname, id) in ids do
      w nodes (sprintf "{id: %d, label: '%s'}," id tname)

    w edges "]);"
    w nodes "]);"
    nodes.ToString() + "\n\n" + edges.ToString()
   
  let path = IO.Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".html")
  using (path |> File.OpenWrite) <| fun tmpf ->
    use sr = new StreamWriter(tmpf)
    let fullScript = (sprintf """
  <!doctype html>
  <html>
  <head>
    <title>Network | Basic usage</title>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/vis/4.19.1/vis.min.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
      html, body, #mynetwork {
        width: 100%%;
        height: 100%%;
        border: 1px solid lightgray;
      }
    </style>
  </head>
  <body>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/vis/4.19.1/vis.min.js"></script>
  <div id="mynetwork"></div>

  <script type="text/javascript">
    %s
    // create a network
    var container = document.getElementById('mynetwork');
    var data = {
      nodes: nodes,
      edges: edges
    };
    var options = {};
    var network = new vis.Network(container, data, options);
  </script>
  </body>
  </html>
    """ script)
    sr.Write fullScript
    sr.Flush()
  let _process = System.Diagnostics.Process.Start(path)
  ()


let run() =
  let realTables = fetchTables()
  let relationships = HashSet<_>(HashIdentity.Structural)

  for def in fetchDefs() do
    printfn "Processing %20s %s" def.type_desc def.name
    try
      match parse def.sql with
      | Choice1Of2 sql ->
        match findFromClause sql with
        | Some(fromC) ->
            let ctx = JoinAnalyzer()
            for tRef in fromC.TableReferences do
              let table = tRef |> TableReference.FromCs
              try processJoins ctx table 0
              with ex -> failwithf "Ignoring error %s" ex.Message
            for x in ctx.condConnections do ignore <| relationships.Add x
              //ignore <| relationships.Add (t1name, t2name)
          
        | None -> ()
      | Choice2Of2 errs -> 
        printfn "Could not parse %s" def.name
        for err in errs do printfn "\t%s" (err.ToString())

    with ex -> printfn "Failed on %s:\n\n\t%s\n" def.name ex.Message
  
  printfn "Result: %A" realTables
  let relationships = 
    relationships 
    |> Seq.filter (fun (a, b) -> (realTables.Contains a) && (realTables.Contains b))
    |> Set.ofSeq
  printfn "Result: %A" relationships
  visualize relationships
    
do run()    