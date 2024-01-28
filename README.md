# JQL Builder

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](./LICENSE)
[![Tests](https://github.com/alby-corp/JQLBuilder/actions/workflows/test.yml/badge.svg?event=push)](https://github.com/alby-corp/JQLBuilder/actions/workflows/test.yml)
[![Build](https://github.com/alby-corp/JQLBuilder/actions/workflows/build.yml/badge.svg?event=push)](https://github.com/alby-corp/JQLBuilder/actions/workflows/build.yml)
[![Publish Pre-Release](https://github.com/alby-corp/JQLBuilder/actions/workflows/pre-release.yml/badge.svg)](https://github.com/alby-corp/JQLBuilder/actions/workflows/pre-release.yml)
[![NuGet Version](https://img.shields.io/nuget/vpre/JQLBuilder.svg?style=flat-square)](https://www.nuget.org/packages/JQLBuilder/)
[![Publish](https://github.com/alby-corp/JQLBuilder/actions/workflows/release.yml/badge.svg)](https://github.com/alby-corp/JQLBuilder/actions/workflows/release.yml)
[![NuGet Version](https://img.shields.io/nuget/v/JQLBuilder.svg?style=flat-square)](https://www.nuget.org/packages/JQLBuilder/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/JQLBuilder.svg)](https://www.nuget.org/packages/JQLBuilder/)

> **_NOTE:_** In its current state, the package is in the **RELEASE CANDIDATE** phase, offering partial implementation for specified fields, along with support for all functions and operators.

## Introduction

This repository houses a C# library designed to provide a JQL (Jira Query Language) builder, aiding programmers in
constructing JQL queries programmatically.

The JqlBuilder library provides a fluent interface for constructing Jira Query Language (JQL) queries in a flexible and
expressive manner.

For more details about JQL, please refer to the [wiki](https://github.com/alby-corp/JQLBuilder/wiki).

## Installation

You should install JqlBuilder with [NuGet](https://www.nuget.org/packages/JqlBuilder):

```
NuGet\Install-Package JQLBuilder
```

Or via the .NET Core command line interface:

```
dotnet add package JQLBuilder
```

Either commands, from Package Manager Console or .NET Core CLI, will download and install JqlBuilder and all required dependencies.

## Getting Started

To start building JQL queries, use the ```JqlBuilder.Query``` entry point. The library follows a fluent API design,
allowing you to chain methods to construct complex queries.

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

## Supported JQL

The following table lists the supported fields and their corresponding types, along with the supported functions and operations grouped by type

### Supported Fields

| Fields          | TYPE            |
|-----------------|-----------------|
| AffectedVersion | VERSION         |
| Assignee        | HISTORICAL_USER |
| Attachment      | ATTACHMENT      |
| Category        | CATEGORY        |
| Component       | COMPONENT       |
| Creator         | USER            |
| Due             | DATE            |
| DueDate         | DATE            |
| FixVersion      | VERSION         |
| Id              | ISSUE           |
| Issue           | ISSUE           |
| IssueKey        | ISSUE           |
| IssueType       | TYPE            |
| Key             | ISSUE           |
| Labels          | LABELS          |
| Parent          | PARENT          |
| Priority        | PRIORITY        |
| Project         | PROJECT         |
| Reporter        | HISTORICAL_USER |
| Sprint          | SPRINT          |
| Status          | STATUS          |
| Summary         | TEXT            |
| Type            | TYPE            |
| Voter           | USER            |
| Watcher         | USER            |

### Supported Operators

| Fields          | TYPE                                                                                           |
|-----------------|------------------------------------------------------------------------------------------------|
| VERSION         | = , != , > , >= , < , <=, IS, IS NOT, IN, NOT IN                                               |
| HISTORICAL_USER | = , !=, IS, IS NOT, IN, NOT IN, WAS, WAS IN, WAS NOT, WAS NOT IN, CHANGED                      |
| ATTACHMENT      | IS, IS NOT                                                                                     |
| CATEGORY        | =, !=, IS, IS NOT, IN, NOT IN                                                                  |
| TEXT            | ~ , !~                                                                                         |
| COMPONENT       | = , !=, IS , IS NOT , IN , NOT IN                                                              |
| DATE            | = , != , > , >= , < , <= IS , IS NOT , IN , NOT IN                                             |
| USER            | ~ , !~ , > , >= , < , <= CHANGED, WAS, WAS IN, WAS NOT, WAS NOT IN                             |
| ISSUE           | = , != , > , >= , < , <=, IN, NOT IN                                                           |
| LABELS          | = , !=, IS, IS NOT, IN, NOT IN                                                                 |
| PARENT          | =, !=, IN, NOT IN                                                                              |
| PRIORITY        | = , != , > , >= , < , <= IS , IS NOT, IN , NOT IN , WAS, WAS IN, WAS NOT, WAS NOT IN , CHANGED |
| PROJECT         | = , !=, IS , IS NOT, IN , NOT IN                                                               |
| SPRINT          | = , !=, IS , IS NOT, IN , NOT IN                                                               |
| STATUS          | = , != , > , >= , < , <= IS , IS NOT, IN , NOT IN , WAS, WAS IN, WAS NOT, WAS NOT IN , CHANGED |
| Type            | = , !=, IS , IS NOT , IN , NOT IN                                                              |

### Supported Functions

| Type            | Functions                                                                                                                    |
|-----------------|------------------------------------------------------------------------------------------------------------------------------|
| DATE            | now, currentLogin, lastLogin, startOfDay, startOfWeek, startOfMonth, startOfYear, endOfDay, endOfWeek, endOfMonth, endOfYear |
| PROJECT         | projectsLeadByUser, projectsWhereUserHasPermission, projectsWhereUserHasRole                                                 |
| VERSION         | latestReleasedVersion, latestUnreleasedVersion, releasedVersions, unreleasedVersions                                         |
| ISSUE           | issueHistory, votedIssues, watchedIssues, linkedIssues                                                                       |
| USER            | membersOf, currentUser                                                                                                       |
| HISTORICAL_USER | membersOf, currentUser                                                                                                       |
| SPRINT          | openSprints, closedSprints                                                                                                   |
| COMPONENT       | componentsLeadByUser                                                                                                         |
