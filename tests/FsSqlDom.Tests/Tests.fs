module FsSqlDom.Tests

// Turn off missing pattern match cases for tests
#nowarn "25"
open FsSqlDom
open FsSqlDom.Dom
open Xunit

[<Fact>]
let ``converting parsed result`` () =
  let sql = "select * from foo"

  match Util.parse(sql) with
  | Success(sqlFrag) ->
    match Util.getQueryExpr(sqlFrag) with
    | Some(QueryExpression.QuerySpecification (FromClause = Some(FromClause.FromClause(TableReferences = [tref])))) -> 
      match tref with
      | TableReference.TableReferenceWithAlias(
          TableReferenceWithAlias.NamedTableReference(
            SchemaObject=Some(SchemaObjectName.Base(BaseIdentifier = Some(a))))) ->
          match a with
          | Identifier.Base(Value=Some(v)) -> 
            Assert.Equal(v, "foo")
