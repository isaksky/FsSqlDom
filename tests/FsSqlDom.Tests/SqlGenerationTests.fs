module SqlGenerationTests

// Turn off missing pattern match cases for tests
#nowarn "25"

open FsSqlDom
open Microsoft.SqlServer.TransactSql
open NUnit.Framework

let roundtrip (sql:string) =
  match Util.parse sql with
  | ParseFragmentResult.Success(frag) ->
    match Util.getQueryExpr(frag) with
    | Some(qexpr) ->
      let sql' = Util.render(qexpr)
      Assert.AreEqual(sql, sql')

[<Test>]
let ``basic queries``() =
  roundtrip "select * from foo"
  roundtrip "select foo from bar"

[<Test>]
let ``query with subquery``() =
  roundtrip "select (select a from b)"

[<Test>]
let ``basic query with where``() = roundtrip "select a, b from foo where 1 = 1"
  
[<Test>]
let ``db func call arity 1``() = roundtrip "select a, dbo.myfun(a)"

[<Test>]
let ``db func call arity 2``() = roundtrip "select a, dbo.myfun(a, b)"

[<Test>]
let ``query with parameters``() = roundtrip "select a from b where c = @d"

[<Test>]
let ``db func call with literal arguments``() = roundtrip "select dbo.myfun(1, 'foo', N'conan o''brien')"