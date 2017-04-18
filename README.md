# FsSqlDom

A library to work with SQL syntax trees in F#. Can be used for:

* Analyzing queries
* Rewriting queries
* Generating scripts from modified sql syntax trees

It covers 100% of TSQL, because it leverages the existing C# library from Microsoft, and is able to convert losslessly* back and forth between Microsofts C# type hierarchy, and a new set of discriminated unions in F#.

* - Stream token positions excluded

Check out the intro [blog post](https://gist.github.com/isaksky/f8c4881bf93c7e57115439af07722ecc) for an example of the first two. For script generation, you could check out the [tests](https://github.com/isaksky/FsSqlDom/blob/4e55f420edf637cef8763fa08b16a35674c4ee23/tests/FsSqlDom.Tests/SqlGenerationTests.fs#L52-L58)


