# FsSqlDom

A library to work with SQL syntax trees in F#. Can be used for:

* Analyzing queries
* Rewriting queries
* Generating scripts from modified sql syntax trees

It covers 100% of TSQL, because it leverages the existing [TransactSql.ScriptDom](https://msdn.microsoft.com/en-us/library/microsoft.sqlserver.transactsql.scriptdom.aspx) C# library from Microsoft, and is able to convert losslessly* back and forth between Microsofts C# type hierarchy, and a new set of discriminated unions in F#.

* - Stream token positions excluded

Check out the intro [blog post](https://gist.github.com/isaksky/f8c4881bf93c7e57115439af07722ecc) for an example of the first two. For script generation, you could check out the [tests](https://github.com/isaksky/FsSqlDom/blob/4e55f420edf637cef8763fa08b16a35674c4ee23/tests/FsSqlDom.Tests/SqlGenerationTests.fs#L52-L58)

# Project roadmap

It is mostly feature complete, though there are a couple of small things I'm considering:

- [ ] Currently, properties are exposed only of "leaf" types - one must destructure a type to the end of the type hierarchy in order to get the properties. But it may make sense to expose properties earlier, if the size of the generated code does not blow up too much.
- [ ] Maybe add a set of active patterns, in order to make analysis easier

# Design questions

* Why generate only discriminated unions (DUs) with many fields, instead of DUs with a single record value?
** I agree that this is generally better, but when you are already dealing with thousands of types, adding even more is not an obvious win. The set of types is already quite big, and with records it would get much bigger. VS 2015 struggles with it as it is.


