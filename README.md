# JQL Builder

This repository houses a C# library designed to provide a JQL (Jira Query Language) builder, aiding programmers in constructing JQL queries programmatically. At its current stage, the package is considered alpha, implementing only partial functionality for the Project and Version fields. However, the library's structure is well-defined.

While a comprehensive readme is currently deemed excessive, here are some examples demonstrating how the library is intended to be used, with a focus on operators and query production.

## Example Usage:

### Example 1:

```csharp
const string expected = """project = "CLOVER" AND project = 12345 AND project in ("HEARTH", 54321) AND (project in projectsLeadByUser("Yami") OR project = "Black Bull") AND project not in projectsWhereUserHasRole("Yuno")""";

var actual = JqlBuilder.Query
    .Where(f => f.Project == "CLOVER")
    .And(f => f.Project == 12345)
    .And(f => f.Project.In("HEARTH", 54321))
    .And(f => f.Project.In(functions => functions.LeadByUser("Yami")) | (f.Project == "Black Bull"))
    .And(f => f.Project.NotIn(functions => functions.WhereUserHasRole("Yuno")))
    .ToString();

Assert.AreEqual(expected, actual);
```

### Example 2:

```csharp
[TestMethod]
public void TestMethod2()
{
    const string expected = """project = "CLOVER" OR project = "HEARTH" order by project asc, assignee desc""";

    var actual = JqlBuilder.Query
        .Where(f => f.Project == "CLOVER")
        .Or(f => f.Project == "HEARTH")
        .OrderBy(f => OrderingFields.Project)
        .ThenByDescending(f => OrderingFields.Assignee)
        .ToString();

    Assert.AreEqual(expected, actual);
}
```

### Example 3:

```csharp
[TestMethod]
public void TestMethod3()
{
    const string expected = """order by project asc, assignee desc, assignee asc""";

    var actual = JqlBuilder.Query
        .OrderBy(f => OrderingFields.Project)
        .ThenByDescending(f => OrderingFields.Assignee)
        .ThenBy(f => OrderingFields.Assignee)
        .ToString();

    Assert.AreEqual(expected, actual);
}
```

### Example 4:

```csharp
[TestMethod]
public void TestMethod4()
{
    const string expected = """project = "CLOVER" AND (project = 12345 OR project in ("HEARTH", 54321))""";

    var actual = JqlBuilder.Query
        .Where(f => f.Project == "CLOVER")
        .And(f => (f.Project == 12345) | f.Project.In("HEARTH", 54321))
        .ToString();

    Assert.AreEqual(expected, actual);
}
```

### Example 5:

```csharp
[TestMethod]
public void TestMethod5()
{
    const string expected = """project = "CLOVER" AND (project = 12345 OR project = "HEARTH" AND project = "SPADE")""";

    var actual = JqlBuilder.Query
        .Where(f => f.Project == "CLOVER")
        .And(f => (f.Project == 12345) | ((f.Project == "HEARTH") & (f.Project == "SPADE")))
        .ToString();

    Assert.AreEqual(expected, actual);
}
```

### Example 6:

```csharp
[TestMethod]
public void TestMethod6()
{
    const string expected = """NOT(project = "CLOVER") AND (project = {12345} OR project = "HEARTH" AND project = "SPADE")""";

    var actual = JqlBuilder.Query
        .Where(f => !(f.Project == "CLOVER"))
        .And(f => (f.Project == 12345) | ((f.Project == "HEARTH") & (f.Project == "SPADE")))
        .ToString();

    Assert.AreEqual(expected, actual);
}
```

### Example 7:

```csharp
[TestMethod]
public void TestMethod7()
{
    const string expected = """NOT(NOT(project = "CLOVER")) AND (project = 12345 OR project = "HEARTH" AND project = "SPADE}")""";

    var actual = JqlBuilder.Query
        .Where(f => !!(f.Project == "CLOVER"))
        .And(f => (f.Project == 12345) | ((f.Project == "HEARTH") & (f.Project == "SPADE")))
        .ToString();

    Assert.AreEqual(expected, actual);
}
```

### Example 8:

```csharp
[TestMethod]
public void TestMethod8()
{
    const string expected = "project is NULL AND (project = 12345 OR project is not EMPTY)";

    var actual = JqlBuilder.Query
        .Where(f => f.Project.Is(v => v.Null))
        .And(f => (f.Project == 12345) | f.Project.IsNot(v => v.Empty))
        .ToString();

    Assert.AreEqual(expected, actual);
}
```
