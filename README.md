# JQL Builder

![Build Development](https://github.com/alby-corp/JQLBuilder/actions/workflows/build.yml/badge.svg?branch=development)
![Build Production](https://github.com/alby-corp/JQLBuilder/actions/workflows/build.yml/badge.svg?branch=main)
![Test Development](https://github.com/alby-corp/JQLBuilder/actions/workflows/test.yml/badge.svg?branch=development)
![Test Production](https://github.com/alby-corp/JQLBuilder/actions/workflows/test.yml/badge.svg?branch=main)
![Publish Nuget](https://github.com/alby-corp/JQLBuilder/actions/workflows/release.yml/badge.svg)
[![NuGet version (JQLBuilder)](https://img.shields.io/nuget/v/JQLBuilder.svg?style=flat-square)](https://www.nuget.org/packages/JQLBuilder/)

This repository houses a C# library designed to provide a JQL (Jira Query Language) builder, aiding programmers in constructing JQL queries programmatically. 

> **_NOTE:_** At its current stage, the package is considered alpha, implementing only partial functionality for the Project and Version fields.

However, the library's structure is well-defined. While a comprehensive readme is currently deemed excessive, here are some examples demonstrating how the library is intended to be used, with a focus on operators and query production.

## Introduction
The JqlBuilder library provides a fluent interface for constructing Jira Query Language (JQL) queries in a flexible and expressive manner. 
This README serves as a guide to help you understand how to use the library effectively.

## Getting Started
To start building JQL queries, use the ```JqlBuilder.Query``` entry point. The library follows a fluent API design, allowing you to chain methods to construct complex queries.

```csharp
JqlBuilder.Query
    .Where(f => f.Project == "example")
    .And(f => f.Assignee == "john.doe")
    .OrderBy(f => f.Project)
    .ThenByDescending(f => f.Priority)
    .ToString();
```

## Query Construction
The library provides extension methods for constructing various parts of a JQL query:

### Filtering
- **Where:** Start the query with a filter condition.
- **And:** Add an AND condition to the existing filter.
- **Or:** Add an OR condition to the existing filter.

```csharp
JqlBuilder.Query
    .Where(f => f.Project == "example")
    .And(f => f.Assignee == "john.doe")
    .Or(f => f.Status == "In Progress");
```

### Ordering
- **OrderBy:** Specify the primary ordering field.
- **OrderByDescending:** Specify the primary ordering field in descending order.
- **ThenBy:** Add secondary ordering fields.
- **ThenByDescending:** Add secondary ordering fields in descending order.

```csharp
JqlBuilder.Query
    .OrderBy(f => f.Project)
    .ThenByDescending(f => f.Priority)
    .ThenBy(f => f.Assignee);
```

### Building
The ```ToString``` method is used to obtain the final JQL query string.

```csharp
JqlBuilder.Query
    .Where(f => f.Project == "example")
    .And(f => f.Assignee == "john.doe")
    .OrderBy(f => f.Project)
    .ThenByDescending(f => f.Priority)
    .ToString();
```

## Examples:
Below are examples demonstrating the usage of the JqlBuilder library based on the provided test class.

### Example 1: Basic Query Construction
```csharp
JqlBuilder.Query
    .Where(f => f.Project == "CLOVER")
    .And(f => f.Project == 12345)
    .And(f => f.Project.In("CLOVER", 12345))
    .And(f => f.Project.In(func => func.LeadByUser("hulk@avengers.world")) | (f.Project == "CLOVER"))
    .And(f => f.Project.NotIn(func => func.WhereUserHasRole("hulk@avengers.world")))
    .ToString();
```
**Generated JQL:** 
```jql 
    project = "CLOVER" AND project = 12345 AND project in ("CLOVER", 12345) AND (project in projectsLeadByUser("hulk@avengers.world") OR project = "CLOVER") AND project not in projectsWhereUserHasRole("hulk@avengers.world")
```

### Example 2: OR Condition with Ordering
```csharp
JqlBuilder.Query
    .Where(f => f.Project == "CLOVER")
    .Or(f => f.Project == "HEARTH")
    .OrderBy(f => f.Project)
    .ThenByDescending(f => f.Assignee)
    .ToString();
```
**Generated JQL:** 
```jql
    project = "CLOVER" OR project = "HEARTH" order by project asc, assignee desc
```

### Example 3: Ordering Without Filtering
```csharp
JqlBuilder.Query
    .OrderBy(f => f.Project)
    .ThenByDescending(f => f.Assignee)
    .ThenBy(f => f.Assignee)
    .ToString();
```
**Generated JQL:** 
```jql
    order by project asc, assignee desc, assignee asc
```

### Example 4: Complex Nested Conditions
```csharp
JqlBuilder.Query
    .Where(f => f.Project == "CLOVER")
    .And(f => (f.Project == 12345) | f.Project.In("CLOVER", 12345))
    .ToString();
```
**Generated JQL:** 
```jql
    project = "CLOVER" AND (project = 12345 OR project in ("CLOVER", 12345))
```

### Example 5: Nested AND and OR Conditions
```csharp
JqlBuilder.Query
    .Where(f => f.Project == "CLOVER")
    .And(f => (f.Project == 12345) | ((f.Project == "HEARTH") & (f.Project == "SPADE")))
    .ToString();
```
**Generated JQL:** 
```jql
    project = "CLOVER" AND (project = 12345 OR project = "HEARTH" AND project = "SPADE")
```

### Example 6: NOT Conditions
```csharp
JqlBuilder.Query
    .Where(f => !(f.Project == "CLOVER"))
    .And(f => (f.Project == 12345) | ((f.Project == "HEARTH") & (f.Project == "SPADE")))
    .ToString();
```
**Generated JQL:** 
```jql
    NOT(project = "CLOVER") AND (project = 12345 OR project = "HEARTH" AND project = "SPADE")
```

### Example 7: Double NOT Conditions
```csharp
JqlBuilder.Query
    .Where(f => !!(f.Project == "CLOVER"))
    .And(f => (f.Project == 12345) | ((f.Project == "HEARTH") & (f.Project == "SPADE")))
    .ToString();
```
**Generated JQL:** 
```jql
    NOT NOT(project = "CLOVER") AND (project = 12345 OR project = "HEARTH" AND project = "SPADE")
```

### Example 8: Double NOT Condition Only
```csharp
JqlBuilder.Query
    .Where(f => !!(f.Project == "CLOVER"))
    .ToString();
```
**Generated JQL:**

```jql 
    NOT NOT(project = "CLOVER")
```

### Example 9: NULL and NOT EMPTY Conditions
```csharp
JqlBuilder.Query
    .Where(f => f.Project.Is(v => v.Null))
    .And(f => (f.Project == 12345) | f.Project.IsNot(v => v.Empty))
    .ToString();
```
**Generated JQL:**

```jql
    project is NULL AND (project = 12345 OR project is not EMPTY)
```