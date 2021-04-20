# FsSqlDom

A library to work with SQL syntax trees in F#. Can be used for:

* Analyzing queries
  * Finding performance problems
  * Checking permissions
* Rewriting queries
  * Optimize poorly written queries
  * Add/remove conditions to `WHERE` clause for security, etc
* Generating scripts from modified SQL syntax trees

It covers 100% of TSQL, because it leverages the existing [TransactSql.ScriptDom](https://msdn.microsoft.com/en-us/library/microsoft.sqlserver.transactsql.scriptdom.aspx) C# library from Microsoft, and is able to convert losslessly* back and forth between Microsofts C# type hierarchy, and a new set of discriminated unions in F#.

`*` Stream token positions excluded, but they can be preserved aside and mapped back.

Check out the intro [blog post](https://gist.github.com/isaksky/f8c4881bf93c7e57115439af07722ecc) for an example of the first two. For script generation, you could check out the [tests](https://github.com/isaksky/FsSqlDom/blob/4e55f420edf637cef8763fa08b16a35674c4ee23/tests/FsSqlDom.Tests/SqlGenerationTests.fs#L52-L58)

## Why use the library?

Usage of discriminated unions allows to lean on exhaustivity check to make sure a new parser version or some other shape of statements your code hasn't handled explicitly will remain consistent/safe, this can't be unforced with open class hierarchy of the base parser library.

## Why not use the library?

Depending the use case, and if you aren't concerned by exhaustive handling of all nodes of the AST, using the underlying parser library with F# object expressions results in simpler code.

# Installation

Install from nuget:

[`Install-Package FsSqlDom`](https://www.nuget.org/packages/FsSqlDom/)

# Gallery WPF App

The main output of this project is a class library, but it also has a windows application with some examples and tools to help use the library (and the C# library from Microsoft).

Features:

- Basic usage
- Syntax Builder (similar to [Roslyn Quoter](http://roslynquoter.azurewebsites.net/)
- Table Relationships vizualizer (based on analysing AST of views, procedures, and functions)

### Screenshots:

![UI](https://raw.githubusercontent.com/isaksky/FsSqlDom/master/docs/files/img/gallery.png)

![Syntax Builder](https://raw.githubusercontent.com/isaksky/FsSqlDom/master/docs/files/img/syntax_view.png)

# Design questions

* Q: Why generate only discriminated unions (DUs) with many fields, instead of DUs with a single record value?
  * A: In this case, it would result it way too many types, which creates a compiler (and tooling) performance problem.
