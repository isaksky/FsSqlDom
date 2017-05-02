namespace FsSqlDom

open System
open System.Collections.Generic
open System.IO
open Microsoft.SqlServer.TransactSql
open FsSqlDom.Dom

type ParseFragmentResult =
  | Success of TSqlFragment
  | Failure of IList<ScriptDom.ParseError>

type Util =
  static member parse(tr:TextReader, initialQuotedIdentifiers:bool) =
    let parser = ScriptDom.TSql130Parser(initialQuotedIdentifiers)
    let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
    let res = parser.Parse(tr, &errs)

    if errs.Count = 0 then
      let converted = TSqlFragment.FromCs(res)
      ParseFragmentResult.Success(converted)
    else
      ParseFragmentResult.Failure(errs)
    
  static member parse(s:string, ?initialQuotedIdentifiers:bool) : ParseFragmentResult =
    let initialQuotedIdentifiers = defaultArg initialQuotedIdentifiers false
    use tr = new StringReader(s) :> TextReader
    Util.parse(tr, initialQuotedIdentifiers)

  static member parseExpr(s:string, ?initialQuotedIdentifiers:bool) : Choice<ScalarExpression, IList<ScriptDom.ParseError>> =
    let initialQuotedIdentifiers = defaultArg initialQuotedIdentifiers false
    let parser = ScriptDom.TSql130Parser(initialQuotedIdentifiers)
    let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
    use tr = new StringReader(s) :> TextReader
    let res = parser.ParseExpression(tr, &errs)

    if errs.Count = 0 then
      let converted = ScalarExpression.FromCs(res)
      Choice1Of2(converted)
    else
      Choice2Of2(errs)

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

  static member renderCs(frag:ScriptDom.TSqlFragment, ?opts:ScriptDom.SqlScriptGeneratorOptions) : string =
    let opts = defaultArg opts (ScriptDom.SqlScriptGeneratorOptions())
    let gen = ScriptDom.Sql130ScriptGenerator(opts)
    use tr = new StringWriter()
    gen.GenerateScript(frag, (tr :> TextWriter))
    tr.ToString()

  static member render(frag:TSqlFragment, ?opts:ScriptDom.SqlScriptGeneratorOptions) : string =
    let frag = frag.ToCs()
    let opts = defaultArg opts (ScriptDom.SqlScriptGeneratorOptions())
    Util.renderCs(frag, opts=opts)

