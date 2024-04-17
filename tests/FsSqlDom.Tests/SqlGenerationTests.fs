module SqlGenerationTests


// Turn off missing pattern match cases for tests
#nowarn "25"

open FsSqlDom
open Microsoft.SqlServer.TransactSql
open System.Text
open Xunit

let whitespaceRE = RegularExpressions.Regex("\s+", RegularExpressions.RegexOptions.Compiled)
let normSQL (s:string) = 
  let s = whitespaceRE.Replace(s, " ")
  s.Trim(' ').TrimEnd(';', ' ') 

let assertEQ_sql (s1:string) (s2:string) =
  let s1 = (normSQL s1).ToLower()
  let s2 = (normSQL s2).ToLower()
  Assert.Equal(s1, s2)

let opts =
  let ret = ScriptDom.SqlScriptGeneratorOptions()
  ret.AlignClauseBodies <- true
  ret.AlignColumnDefinitionFields <- true
  ret.AlignSetClauseItem <- true
  ret.AsKeywordOnOwnLine <- true
  ret.IncludeSemicolons <- false
  ret.IndentationSize <- 4
  ret.IndentSetClause <- false
  ret.IndentViewBody <- true
  ret.KeywordCasing <- ScriptDom.KeywordCasing.Lowercase
  //  opts.MultilineInsertSourcesList : bool with get, set
  //  opts.MultilineInsertTargetsList : bool with get, set
  //  opts.MultilineSelectElementsList : bool with get, set
  //  opts.MultilineSetClauseItems : bool with get, set
  //  opts.MultilineViewColumnsList : bool with get, set
  //  opts.MultilineWherePredicatesList : bool with get, set
  //  opts.NewLineBeforeCloseParenthesisInMultilineList : bool with get, set
  //  opts.NewLineBeforeFromClause : bool with get, set
  //  opts.NewLineBeforeGroupByClause : bool with get, set
  //  opts.NewLineBeforeHavingClause : bool with get, set
  //  opts.NewLineBeforeJoinClause : bool with get, set
  //  opts.NewLineBeforeOffsetClause : bool with get, set
  //  opts.NewLineBeforeOpenParenthesisInMultilineList : bool with get, set
  //  opts.NewLineBeforeOrderByClause : bool with get, set
  //  opts.NewLineBeforeOutputClause : bool with get, set
  //  opts.NewLineBeforeWhereClause : bool with get, set
  //  opts.Reset : unit -> unit
  //  opts.SqlVersion : ScriptDom.SqlVersion with get, set
  ret

let roundtrip (sql:string) =
  match Util.parse sql with
  | ParseFragmentResult.Success(frag) ->
    let sql' = Util.render(frag, opts)
    assertEQ_sql sql sql'
  | ParseFragmentResult.Failure(errs) ->
    failwith (errs |> Seq.map (fun err -> err.Message) |> String.concat ";")

[<Fact>]
let ``basic queries``() =
  roundtrip "select * from foo"
  roundtrip "select foo from bar"

[<Fact>]
let ``query with subquery``() =
  roundtrip "select (select a from b)"

[<Fact>]
let ``basic query with where``() = roundtrip "select a, b from foo where 1 = 1"
  
[<Fact>]
let ``db func call arity 1``() = roundtrip "select a, dbo.myfun(a)"

[<Fact>]
let ``db func call arity 2``() = roundtrip "select a, dbo.myfun(a, b)"

[<Fact>]
let ``query with parameters``() = roundtrip "select a from b where c = @d"

[<Fact>]
let ``db func call with literal arguments``() = roundtrip "select dbo.myfun(1, 'foo', N'conan o''brien')"

[<Fact>]
let ``create view statement``() = roundtrip """
create view dbo.my_view as (select * from baz where bar = z)
"""

/// From http://stackoverflow.com/a/7892349/371698
[<Fact>]
let ``table size query``() = roundtrip """
select 
    t.NAME as TableName,
    s.Name as SchemaName,
    p.rows as RowCounts,
    SUM(a.total_pages) * 8 as TotalSpaceKB, 
    SUM(a.used_pages) * 8 as UsedSpaceKB, 
    (SUM(a.total_pages) - SUM(a.used_pages)) * 8 as UnusedSpaceKB
from sys.tables as t
inner join sys.indexes as i ON t.OBJECT_ID = i.object_id
inner join sys.partitions as p ON i.object_id = p.OBJECT_ID and i.index_id = p.index_id
inner join sys.allocation_units as a ON p.partition_id = a.container_id
left outer join sys.schemas as s ON t.schema_id = s.schema_id
where t.NAME not like 'dt%' 
and t.is_ms_shipped = 0
and i.OBJECT_ID > 255 
group by t.Name, s.Name, p.Rows
order by t.Name
"""