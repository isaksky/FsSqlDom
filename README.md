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

`*` Stream token positions are excluded, but they can be preserved and mapped back.

Check out the intro [blog post](https://gist.github.com/isaksky/f8c4881bf93c7e57115439af07722ecc) for an example of the first two. For script generation, you could check out the [tests](https://github.com/isaksky/FsSqlDom/blob/4e55f420edf637cef8763fa08b16a35674c4ee23/tests/FsSqlDom.Tests/SqlGenerationTests.fs#L52-L58)

## Why use this instead of ScriptDom?

Usage of discriminated unions allows leaning on exhaustivity checks to ensure cases your code hasn't handled will yield warnings at compile time, which can make it easier to write correct code, especially if the cases change over time (e.g., new types of sql expressions). Such safety can't be enforced with the open class hierarchy of the base parser library.

The types are also all immutable, which make them safe to pass around, store in global variables, etc. The types in ScriptDom are mutable, so you have to be careful with them.

## When does using plain ScriptDom make sense instead?

If you are not concerned with mattern matching, exhaustive handling of all nodes of the AST, or immutability, using the underlying parser library with vistor F# object expressions can result in simpler code. In general, very simple tasks (e.g., find all column references in a query) can usually be handled very well by using ScriptDom.

You can also do part of the work with one, convert the AST using the included (".ToCs / .FromCs) functions, and then use the other (I often end up doing this).

## How the library is made?

Check docs/tools/build_lib.fsx, this code can serve the same purpose for any other ANTLR generated parser library targetting dotnet.

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

* Q: Why not embed token data (e.g., StartToken, EndToken) directly on the objects, like ScriptDom?
  * A: For some use cases, adding that information there would be a step backwards. For example, when doing advanced analysis/rewrites of scripts, you often want to put nodes in maps/sets, compare nodes for equality, etc. All of these use cases would be harmed by also having the token data there. Having a mapping back to the complete mutable C# type gives a lot of additional flexibility not possible with the direct-embed approach too. 
