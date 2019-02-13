open System
open System.IO
open System.Data
open System.Data.SqlClient
open System.Collections.Generic

#r "../lib/Microsoft.SqlServer.TransactSql.ScriptDom.dll"
open Microsoft.SqlServer.TransactSql.ScriptDom
open Microsoft.SqlServer.TransactSql

type ParseFragmentResult =
  | Success of TSqlFragment
  | Failure of IList<ScriptDom.ParseError>

type Util =
  static member parse(tr:TextReader, initialQuotedIdentifiers:bool) =
    let parser = ScriptDom.TSql140Parser(initialQuotedIdentifiers)
    let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
    let res = parser.Parse(tr, &errs)

    if errs.Count = 0 then
      ParseFragmentResult.Success(res)
    else
      ParseFragmentResult.Failure(errs)
    
  static member parse(s:string, ?initialQuotedIdentifiers:bool) : ParseFragmentResult =
    let initialQuotedIdentifiers = defaultArg initialQuotedIdentifiers false
    use tr = new StringReader(s) :> TextReader
    Util.parse(tr, initialQuotedIdentifiers)

let foo (x:int) = 
  for _ in [0..10] do
    let d = 
      match Util.parse "select * from foo" with
      | Success(frag) ->
        match frag with
        | :? QueryExpression as qe ->
          qe.StartOffset
        | :? QueryExpression as fo ->
          1
      | Failure(_) -> 2
    printfn "%d" d