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
  static member parse(tr:TextReader, initialQuotedIdentifiers:bool, ?fragmentMapping:FragmentMapping) =
    let parser = ScriptDom.TSql150Parser(initialQuotedIdentifiers)
    let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
    let res = parser.Parse(tr, &errs)
    let fragmentMapping = defaultArg fragmentMapping (Unchecked.defaultof<_>)

    if errs.Count = 0 then
      let converted = TSqlFragment.FromCs(res, fragmentMapping)
      ParseFragmentResult.Success(converted)
    else
      ParseFragmentResult.Failure(errs)
    
  static member parse(s:string, ?initialQuotedIdentifiers:bool, ?fragmentMapping:FragmentMapping) : ParseFragmentResult =
    let initialQuotedIdentifiers = defaultArg initialQuotedIdentifiers false
    let fragmentMapping = defaultArg fragmentMapping (Unchecked.defaultof<_>)
    use tr = new StringReader(s) :> TextReader
    Util.parse(tr, initialQuotedIdentifiers, fragmentMapping)

  static member parseExpr(s:string, ?initialQuotedIdentifiers:bool, ?fragmentMapping:FragmentMapping) : Choice<ScalarExpression, IList<ScriptDom.ParseError>> =
    let initialQuotedIdentifiers = defaultArg initialQuotedIdentifiers false
    let fragmentMapping = defaultArg fragmentMapping (Unchecked.defaultof<_>)
    let parser = ScriptDom.TSql150Parser(initialQuotedIdentifiers)
    let mutable errs : IList<_> = Unchecked.defaultof<IList<_>>
    use tr = new StringReader(s) :> TextReader
    let res = parser.ParseExpression(tr, &errs)

    if errs.Count = 0 then
      let converted = ScalarExpression.FromCs(res, fragmentMapping)
      Choice1Of2(converted)
    else
      Choice2Of2(errs)

  static member getQueryExpr(frag: TSqlFragment) : QueryExpression option =
    match frag with
    | TSqlFragment.TSqlScript(script::_) ->
      match script with
      | TSqlBatch.TSqlBatch(statement::_) ->
        match statement with
        | TSqlStatement.StatementWithCtesAndXmlNamespaces(StatementWithCtesAndXmlNamespaces.SelectStatement(SelectStatement.Base(QueryExpression = qexpr))) ->
          qexpr
        | _ -> None
      | _ -> None
    | _ -> None

  static member renderCs(frag:ScriptDom.TSqlFragment, ?opts:ScriptDom.SqlScriptGeneratorOptions) : string =
    let opts = defaultArg opts (ScriptDom.SqlScriptGeneratorOptions())
    let gen = ScriptDom.Sql150ScriptGenerator(opts)
    use tr = new StringWriter()
    gen.GenerateScript(frag, (tr :> TextWriter))
    tr.ToString()

  static member render(frag:TSqlFragment, ?opts:ScriptDom.SqlScriptGeneratorOptions) : string =
    let frag = frag.ToCs()
    let opts = defaultArg opts (ScriptDom.SqlScriptGeneratorOptions())
    Util.renderCs(frag, opts=opts)

