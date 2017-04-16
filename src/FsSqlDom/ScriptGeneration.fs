namespace FsSqlDom
open System
open System.Text
open Microsoft.SqlServer.TransactSql
open FsSqlDom.Dom

// Turn off unused variables warning
#nowarn "1182"

type SqlWriterOptions =
  { capitalizedKeywords: bool }

type SqlHelper() =
  static member sym(op:ScriptDom.BooleanComparisonType) =
    match op with
    | ScriptDom.BooleanComparisonType.Equals -> "="
    | ScriptDom.BooleanComparisonType.GreaterThan -> ">"
    | ScriptDom.BooleanComparisonType.GreaterThanOrEqualTo ">="
    | ScriptDom.BooleanComparisonType.LessThan -> "<"
    | ScriptDom.BooleanComparisonType.LessThanOrEqualTo -> "<="
    | _ -> failwith "Not implemented yet"

type SqlWriter(opts:SqlWriterOptions) =
  let mutable _indent = 0
  let mutable _lastWs = true
  let mutable _lastNl = true
  let mutable _lastOpenPar = false
  let _sb = StringBuilder()

  let ws (s:string) = // abbr: write string
    System.Diagnostics.Trace.WriteLine(sprintf "Write: \"%s\"" s)
    if s.Length > 0 then
      _sb.Append(s) |> ignore
      let c = s.[s.Length - 1]
      _lastWs <- Char.IsWhiteSpace(c)
      _lastNl <- '\n' = c
      _lastOpenPar <- '(' = c

  let wc (c:char) = // abbr: write char
    System.Diagnostics.Trace.WriteLine(sprintf "Write: '%c'" c)
    _sb.Append(c) |> ignore
    _lastWs <- Char.IsWhiteSpace(c)
    _lastNl <- '\n' = c
    _lastOpenPar <- '(' = c

  let space() = if not _lastWs then wc ' '
  let newline() = if not _lastNl then wc '\n'
  let spaceOrPar() = if not _lastWs && not _lastOpenPar then wc ' '

  let sws (s:string) = // abbr: space write string
    if s <> "" then
      space()
      ws s

  let swc (c:char) = //abbr: space write char
    space()
    wc c

  let swk (s:string) = // abbr: space write keyword
    if s <> "" then
      spaceOrPar()
      if opts.capitalizedKeywords then ws (s.ToUpper())
      else ws s

  member x.sepw(sep:string) (items:'e list) (iwriter:'e->unit) =
    let rec loop (els:'e list) =
      match els with
      | [] -> ()
      | el::[] -> iwriter el
      | el::els ->
        iwriter el
        ws sep
        loop els
    spaceOrPar()
    loop items

  member x.write(queryExpr: QueryExpression) =
    match queryExpr with
    | QueryExpression.QueryParenthesisExpression(_forClause, _offsetClause, _orderByClause, _queryExpression) -> failwith "Not implemented yet"
    | QueryExpression.QuerySpecification(forClause, fromClause, groupByClause, havingClause, offsetClause, orderByClause, selectElements, topRowFilter, uniqueRowFilter, whereClause) ->
      swk "select " 
      x.write topRowFilter
      x.write uniqueRowFilter
      x.sepw ", " selectElements x.write
      match fromClause with
      | Some(fromClause) ->
        swk "from "
        x.write fromClause
      | None -> ()

      match whereClause with
      | Some(whereClause) ->
        swk "where "
        x.write whereClause
      | None -> ()

    | QueryExpression.BinaryQueryExpression(all, binaryQueryExpressionType, firstQueryExpression, forClause, offsetClause, orderByClause, secondQueryExpression) ->
      x.write firstQueryExpression.Value 

      match binaryQueryExpressionType with
      | ScriptDom.BinaryQueryExpressionType.Union -> swk "union"
      | ScriptDom.BinaryQueryExpressionType.Except -> swk "except"
      | ScriptDom.BinaryQueryExpressionType.Intersect -> swk "intersect"
      | _ -> failwith "Not implemented yet"

      if all then swk "all"

      x.write secondQueryExpression.Value

      match orderByClause with
      | Some(orderByClause) -> x.write orderByClause
      | None -> ()

  member x.write(orderByClause:OrderByClause) =
    match orderByClause with
    | OrderByClause.OrderByClause(orderEls) ->
      x.sepw ", " orderEls x.write

  member x.write(exprWithSortOrder:ExpressionWithSortOrder) =
    match exprWithSortOrder with
    | ExpressionWithSortOrder.ExpressionWithSortOrder(expr, sortOrder) ->
      x.write expr.Value
      x.write sortOrder

  member x.write(sortOrder:ScriptDom.SortOrder) =
    match sortOrder with
    | ScriptDom.SortOrder.Ascending -> swk "asc"
    | ScriptDom.SortOrder.Descending -> swk "desc"
    | ScriptDom.SortOrder.NotSpecified -> ()
    | _ -> failwith "Not implemented yet"

  member x.write(topFilt:TopRowFilter option) =
    match topFilt with
    | Some(TopRowFilter.TopRowFilter
          (Some(ScalarExpression.PrimaryExpression
            (PrimaryExpression.ValueExpression(ValueExpression.Literal
              (Literal.IntegerLiteral(None,ScriptDom.LiteralType.Integer,Some(n)))))), 
            pct, ties)) ->
        swk "top"
        sws n
        if pct then swk "percent"
        if ties then swk "with ties"
    | None -> ()
    | _ -> 
      failwith "Not implemented yet"

  member x.write(uniqFilt:ScriptDom.UniqueRowFilter) =
    match uniqFilt with
    | ScriptDom.UniqueRowFilter.NotSpecified -> ()
    | ScriptDom.UniqueRowFilter.Distinct -> swk "distinct"
    | _ -> failwith "Not implemented yet"

  member x.write(selectEl:SelectElement) =
    match selectEl with
    | SelectElement.SelectScalarExpression(columnName, expression) ->
      match columnName, expression with
      | Some(columnName), Some(expr) ->
        x.write expr
        swk "as"
        x.write columnName
      | None, Some(expr) ->
        x.write expr
      | Some(columnName), None ->
        x.write columnName
      | _ -> failwith "Logic error"
    | SelectElement.SelectSetVariable(_assignmentKind, _expression, _variable) -> failwith "Not implemented yet"
    | SelectElement.SelectStarExpression(qualifier) -> 
      match qualifier with
      | Some(qualifier) -> x.write(qualifier); wc '.'
      | None -> ()
      swc '*'

  member x.write(mident:MultiPartIdentifier) =
    match mident with
    | MultiPartIdentifier.Base(_count, identifiers) -> x.sepw "." identifiers x.write
    | MultiPartIdentifier.SchemaObjectName(so) -> x.write(so)

  member x.write(ident:Identifier) =
    match ident with
    | Identifier.Base(ScriptDom.QuoteType.NotQuoted, Some(v)) -> ws v
    | Identifier.Base(ScriptDom.QuoteType.SquareBracket, Some(v)) ->
      wc '['; ws v; wc ']'
    | _ -> failwithf "Unexpected Identifier %A" ident

  member x.write(so:SchemaObjectName) =
    match so with
    | SchemaObjectName.Base(baseIdentifier, count, databaseIdentifier, identifiers, schemaIdentifier, serverIdentifier) ->
      x.sepw "." identifiers x.write
    | SchemaObjectName.SchemaObjectNameSnippet(baseIdentifier, count, databaseIdentifier, identifiers, schemaIdentifier, script, serverIdentifier) -> failwith "Not implemented yet"
    | SchemaObjectName.ChildObjectName(baseIdentifier, childIdentifier, count, databaseIdentifier, identifiers, schemaIdentifier, serverIdentifier) -> failwith "Not implemented yet"
    
  member x.write(expr: ScalarExpression) =
    match expr with
    | ScalarExpression.PrimaryExpression(pexpr) ->
      x.write(pexpr)
    | _ -> failwith "Not implemented yet"

  member x.write(idOrVal:IdentifierOrValueExpression) =
    match idOrVal with
    | IdentifierOrValueExpression.IdentifierOrValueExpression(_, Some(v), _) ->
      sws v
    | _ -> failwith "Not implemented yet"

  member x.write(pexpr:PrimaryExpression) =
    match pexpr with
    | PrimaryExpression.CaseExpression(_) -> failwith "Not implemented yet"
    | PrimaryExpression.CastCall(collation, dataType, parameter) -> failwith "Not implemented yet"
    | PrimaryExpression.CoalesceExpression(collation, expressions) -> failwith "Not implemented yet"
    | PrimaryExpression.ColumnReferenceExpression(collation, columnType, multiPartIdentifier) ->
      match multiPartIdentifier with
      | Some(mid) -> x.write mid
      | None -> failwith "Not implemented yet"
    | PrimaryExpression.ConvertCall(collation, dataType, parameter, style) -> failwith "Not implemented yet"
    | PrimaryExpression.FunctionCall(callTarget, collation, functionName, overClause, parameters, uniqueRowFilter, withinGroupClause) ->
      match callTarget with
      | Some(callTarget) -> 
        x.write callTarget
        wc '.'
      x.write functionName.Value
      wc '('; x.sepw ", " parameters x.write; wc ')'
    | PrimaryExpression.IIfCall(collation, elseExpression, predicate, thenExpression) -> failwith "Not implemented yet"
    | PrimaryExpression.LeftFunctionCall(collation, parameters) -> failwith "Not implemented yet"
    | PrimaryExpression.NextValueForExpression(collation, overClause, sequenceName) -> failwith "Not implemented yet"
    | PrimaryExpression.NullIfExpression(collation, firstExpression, secondExpression) -> failwith "Not implemented yet"
    | PrimaryExpression.OdbcFunctionCall(collation, name, parameters, parametersUsed) -> failwith "Not implemented yet"
    | PrimaryExpression.ParameterlessCall(collation, parameterlessCallType) -> failwith "Not implemented yet"
    | PrimaryExpression.ParenthesisExpression(collation, expression) -> failwith "Not implemented yet"
    | PrimaryExpression.ParseCall(collation, culture, dataType, stringValue) -> failwith "Not implemented yet"
    | PrimaryExpression.PartitionFunctionCall(collation, databaseName, functionName, parameters) -> failwith "Not implemented yet"
    | PrimaryExpression.RightFunctionCall(collation, parameters) -> failwith "Not implemented yet"
    | PrimaryExpression.ScalarSubquery(None, Some(queryExpression)) -> 
      swc '('; x.write(queryExpression); wc ')'
    | PrimaryExpression.ScalarSubquery(_, _) -> failwith "Not implemented yet"
    | PrimaryExpression.TryCastCall(collation, dataType, parameter) -> failwith "Not implemented yet"
    | PrimaryExpression.TryConvertCall(collation, dataType, parameter, style) -> failwith "Not implemented yet"
    | PrimaryExpression.TryParseCall(collation, culture, dataType, stringValue) -> failwith "Not implemented yet"
    | PrimaryExpression.UserDefinedTypePropertyAccess(callTarget, collation, propertyName) -> failwith "Not implemented yet"
    | PrimaryExpression.ValueExpression(v) -> x.write v
    | PrimaryExpression.AtTimeZoneCall(collation, dateValue, timeZone) -> failwith "Not implemented yet"

  member x.write(callTarget:CallTarget) =
    match callTarget with
    | CallTarget.ExpressionCallTarget(expression) -> failwith "Not implemented yet"
    | CallTarget.UserDefinedTypeCallTarget(schemaObjectName) -> failwith "Not implemented yet"
    | CallTarget.MultiPartIdentifierCallTarget(multiPartIdentifier) -> x.write multiPartIdentifier.Value

  member x.write(v:ValueExpression) =
    match v with
    | ValueExpression.VariableReference(collation, name) ->
      ws name.Value
    | ValueExpression.GlobalVariableExpression(collation, name) -> failwith "Not implemented yet"
    | ValueExpression.Literal(lit) -> x.write lit

  member x.write(lit:Literal) =
    match lit with
    | Literal.IdentifierLiteral(_) -> ()
    | Literal.BinaryLiteral(collation, isLargeObject, literalType, value) -> failwith "Not implemented yet"
    | Literal.DefaultLiteral(collation, literalType, value) -> failwith "Not implemented yet"
    | Literal.IntegerLiteral(collation, literalType, value) -> ws value.Value
    | Literal.MaxLiteral(collation, literalType, value) -> failwith "Not implemented yet"
    | Literal.MoneyLiteral(collation, literalType, value) -> failwith "Not implemented yet"
    | Literal.NullLiteral(collation, literalType, value) -> failwith "Not implemented yet"
    | Literal.NumericLiteral(collation, literalType, value) -> failwith "Not implemented yet"
    | Literal.OdbcLiteral(collation, isNational, literalType, odbcLiteralType, value) -> failwith "Not implemented yet"
    | Literal.RealLiteral(collation, literalType, value) -> failwith "Not implemented yet"
    | Literal.StringLiteral(collation, isLargeObject, isNational, literalType, value) ->
      if isNational then wc 'N'
      wc '''
      for c in value.Value do
        if c = ''' then
          ws "''"
        else
          wc c
      wc '''

  member x.write(fromC:FromClause) =
    match fromC with
    | FromClause.FromClause(trefs) ->
      for tref in trefs do x.write tref

  member x.write(tref:TableReference) =
    match tref with
    | TableReference.JoinParenthesisTableReference(join) -> 
      failwith "Not implemented yet"
    | TableReference.JoinTableReference(_) -> 
      failwith "Not implemented yet"
    | TableReference.OdbcQualifiedJoinTableReference(tableReference) -> 
      failwith "Not implemented yet"
    | TableReference.TableReferenceWithAlias(tr) ->
      x.write tr

  member x.write(tra:TableReferenceWithAlias) =
    match tra with
    | TableReferenceWithAlias.AdHocTableReference(alias, dataSource, object) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.BuiltInFunctionTableReference(alias, name, parameters) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.FullTextTableReference(alias, columns, fullTextFunctionType, language, propertyName, searchCondition, tableName, topN) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.InternalOpenRowset(alias, identifier, varArgs) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.OpenJsonTableReference(alias, rowPattern, schemaDeclarationItems, variable) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.OpenQueryTableReference(alias, linkedServer, query) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.OpenRowsetTableReference(alias, dataSource, object, password, providerName, providerString, query, userId) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.OpenXmlTableReference(alias, flags, rowPattern, schemaDeclarationItems, tableName, variable) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.PivotedTableReference(aggregateFunctionIdentifier, alias, inColumns, pivotColumn, tableReference, valueColumns) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.SemanticTableReference(alias, columns, matchedColumn, matchedKey, semanticFunctionType, sourceKey, tableName) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.TableReferenceWithAliasAndColumns(tac) ->
      x.write tac
    | TableReferenceWithAlias.UnpivotedTableReference(alias, inColumns, pivotColumn, tableReference, valueColumn) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.VariableTableReference(alias, variable) -> failwith "Not implemented yet"
    | TableReferenceWithAlias.NamedTableReference(alias, schemaObject, tableHints, tableSampleClause, temporalClause) ->
      x.write schemaObject.Value

  member x.write(tac:TableReferenceWithAliasAndColumns) =
    match tac with
    | TableReferenceWithAliasAndColumns.BulkOpenRowset(alias, columns, dataFile, options) -> failwith "Not implemented yet"
    | TableReferenceWithAliasAndColumns.ChangeTableChangesTableReference(alias, columns, sinceVersion, target) -> failwith "Not implemented yet"
    | TableReferenceWithAliasAndColumns.ChangeTableVersionTableReference(alias, columns, primaryKeyColumns, primaryKeyValues, target) -> failwith "Not implemented yet"
    | TableReferenceWithAliasAndColumns.DataModificationTableReference(alias, columns, dataModificationSpecification) -> failwith "Not implemented yet"
    | TableReferenceWithAliasAndColumns.QueryDerivedTable(alias, columns, queryExpression) ->
      wc '('; x.write queryExpression.Value; wc ')'
      if alias.IsSome then wc ' '; x.write alias.Value
    | TableReferenceWithAliasAndColumns.SchemaObjectFunctionTableReference(alias, columns, parameters, schemaObject) -> failwith "Not implemented yet"
    | TableReferenceWithAliasAndColumns.VariableMethodCallTableReference(alias, columns, methodName, parameters, variable) -> failwith "Not implemented yet"
    | TableReferenceWithAliasAndColumns.InlineDerivedTable(alias, columns, rowValues) -> failwith "Not implemented yet"

  member x.write(whereC:WhereClause) =
    match whereC with
    | WhereClause.WhereClause(None, Some(booleanExpression)) ->
      x.write booleanExpression
    | _ -> failwith "Not implemented yet"

  member x.write(bexpr:BooleanExpression) =
    match bexpr with
    | BooleanExpression.BooleanComparisonExpression(comparisonType, Some(firstExpression), Some(secondExpression)) ->
      let sym = SqlHelper.sym comparisonType
      x.write firstExpression
      wc ' '
      ws sym
      wc ' '
      x.write secondExpression
    | BooleanExpression.BooleanComparisonExpression(_) -> failwith "Not implemented yet"
    | BooleanExpression.BooleanExpressionSnippet(script) -> failwith "Not implemented yet"
    | BooleanExpression.BooleanIsNullExpression(expression, isNot) -> 
      x.write expression.Value
      if isNot then swk "is not null"
      else swk "is null"
    | BooleanExpression.BooleanNotExpression(expression) -> failwith "Not implemented yet"
    | BooleanExpression.BooleanParenthesisExpression(expression) -> failwith "Not implemented yet"
    | BooleanExpression.BooleanTernaryExpression(firstExpression, secondExpression, ternaryExpressionType, thirdExpression) -> failwith "Not implemented yet"
    | BooleanExpression.EventDeclarationCompareFunctionParameter(eventValue, name, sourceDeclaration) -> failwith "Not implemented yet"
    | BooleanExpression.ExistsPredicate(subquery) -> failwith "Not implemented yet"
    | BooleanExpression.FullTextPredicate(columns, fullTextFunctionType, languageTerm, propertyName, value) -> failwith "Not implemented yet"
    | BooleanExpression.InPredicate(expression, notDefined, subquery, values) -> 
      x.write expression.Value
      swk " in ("
      match subquery, values with
      | Some(subquery), _ ->
        x.write subquery
      | _, vals ->
        x.sepw ", " values x.write
      wc ')'
    | BooleanExpression.LikePredicate(escapeExpression, firstExpression, notDefined, odbcEscape, secondExpression) -> failwith "Not implemented yet"
    | BooleanExpression.SubqueryComparisonPredicate(comparisonType, expression, subquery, subqueryComparisonPredicateType) -> failwith "Not implemented yet"
    | BooleanExpression.TSEqualCall(firstExpression, secondExpression) -> failwith "Not implemented yet"
    | BooleanExpression.UpdateCall(identifier) -> failwith "Not implemented yet"
    | BooleanExpression.BooleanBinaryExpression(binaryExpressionType, firstExpression, secondExpression) ->
      x.write firstExpression.Value
      x.write binaryExpressionType
      space()
      x.write secondExpression.Value

  member x.write(bexprt:ScriptDom.BooleanBinaryExpressionType) =
    match bexprt with
    | ScriptDom.BooleanBinaryExpressionType.And -> swk "and"
    | ScriptDom.BooleanBinaryExpressionType.Or -> swk "or"
    | _ -> failwith "Not implemented yet"

  member x.write(subQ:ScalarSubquery) =
    match subQ with
    | ScalarSubquery.ScalarSubquery(_, queryExpression) ->
      x.write queryExpression.Value

  override x.ToString() = _sb.ToString()
