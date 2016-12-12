namespace FsSqlDom

open System
open System.Collections.Generic
open System.IO
open Microsoft.SqlServer.TransactSql

type ParseFragmentResult =
  | Success of TSqlFragment
  | Failure of IList<ScriptDom.ParseError>

type Util =
  static member parse(tr:TextReader, initialQuotedIdentifiers:bool) =
    let parser = ScriptDom.TSql130Parser(initialQuotedIdentifiers)
    let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
    let res = parser.Parse(tr, &errs)

    if errs.Count = 0 then
      let converted = FsSqlDom.TSqlFragment.FromTs(res)
      ParseFragmentResult.Success(converted)
    else
      ParseFragmentResult.Failure(errs)
    
  static member parse(s:string, ?initialQuotedIdentifiers:bool) : ParseFragmentResult =
    let initialQuotedIdentifiers = defaultArg initialQuotedIdentifiers false
    use tr = new StringReader(s) :> TextReader
    Util.parse(tr, initialQuotedIdentifiers)

  static member getQueryExpr(frag: TSqlFragment) : QueryExpression option =
    match frag with
    | TSqlFragment.TSqlScript(script::_) ->
      match script with
      | TSqlBatch.TSqlBatch(statement::_) ->
        match statement with
        | TSqlStatement.StatementWithCtesAndXmlNamespaces(StatementWithCtesAndXmlNamespaces.SelectStatement(SelectStatement.Base(_,_,_,qexpr,_))) ->
          qexpr
        | _ -> None
      | _ -> None
    | _ -> None