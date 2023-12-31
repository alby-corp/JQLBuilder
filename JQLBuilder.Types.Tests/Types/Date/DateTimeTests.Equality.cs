﻿namespace JQLBuilder.Types.Tests.Types.Date;

public partial class DateTimeTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        var expected = $"""
                        "{CustomFieldName}" = "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] == dateString)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"""
                        "{CustomFieldName}" != "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] != dateString)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression()
    {
        var expected = $"""
                        "{CustomFieldName}" > "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] > dateString)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_Expression()
    {
        var expected = $"""
                        "{CustomFieldName}" >= "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] >= dateString)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression()
    {
        var expected = $"""
                        "{CustomFieldName}" < "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] < dateString)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_Expression()
    {
        var expected = $"""
                        "{CustomFieldName}" <= "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] <= dateString)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #region Reverse

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        var expected = $"""
                        "{CustomFieldName}" = "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => dateString == f.DateTime[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"""
                        "{CustomFieldName}" != "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => dateString != f.DateTime[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression_Reverse()
    {
        var expected = $"""
                        "{CustomFieldName}" > "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => dateString > f.DateTime[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_Expression_Reverse()
    {
        var expected = $"""
                        "{CustomFieldName}" >= "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => dateString >= f.DateTime[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression_Reverse()
    {
        var expected = $"""
                        "{CustomFieldName}" < "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => dateString < f.DateTime[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_Expression_Reverse()
    {
        var expected = $"""
                        "{CustomFieldName}" <= "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => dateString <= f.DateTime[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}