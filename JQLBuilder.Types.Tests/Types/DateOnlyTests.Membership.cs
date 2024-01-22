namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;
using Support;
using Functions = JQLBuilder.Functions;

public partial class DateOnlyTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" in ("{dateString}", "{dateString}", now(), endOfDay("-1M"))
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName].In(dateString, dateOnly, f.Functions.Date.Now, f.Functions.Date.EndOfDay("-1M")))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" in ("{dateString}", "{dateString}", "{dateString}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName].In(dateString, dateString, dateString))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" not in ("{dateString}", "{dateString}", now())
                        """;

        var filter = new JqlCollection<DateExpression> { dateString, dateOnly, Functions.Date.Now };

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName].NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Homogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" not in ("{dateString}", "{dateString}", "{dateString}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName].NotIn(dateString, dateString, dateString))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" in ("{dateString}", "{dateString}", "{dateString}")
                        """;

        var filters = new JqlCollection<DateExpression> { dateString, dateString, dateString };

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName].In(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" in ("{dateString}", "{dateString}", now())
                        """;

        var filters = new JqlCollection<DateExpression> { dateString, dateOnly, Functions.Date.Now };

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName].In(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" not in ("{dateString}", "{dateString}", "{dateString}")
                        """;

        var filters = new JqlCollection<DateExpression> { dateString, dateString, dateString };

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName].NotIn(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" not in ("{dateString}", "{dateString}", now())
                        """;

        var filters = new JqlCollection<DateExpression> { dateString, dateOnly, Functions.Date.Now };

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName].NotIn(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}