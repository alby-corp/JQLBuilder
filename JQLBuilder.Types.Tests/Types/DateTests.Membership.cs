namespace JQLBuilder.Types.Tests.Types;

using Fields;
using Functions;
using Infrastructure;
using JqlTypes;

public partial class DateTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" in ("{dateString}", "{dateString}", now())
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName].In(dateString, dateTime, f.DateOnly.Now))
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
            .Where(f => f.Custom.Date[CustomFieldName].In(dateString, dateString, dateString))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" not in ("{dateString}", "{dateString}", now())
                        """;

        var filter = new JqlCollection<DateExpression> { dateString, dateTime, Date.Only.Now };
        
        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName].NotIn(filter))
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
            .Where(f => f.Custom.Date[CustomFieldName].NotIn(dateString, dateString, dateString))
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
            .Where(f => f.Custom.Date[CustomFieldName].In(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" in ("{dateString}", "{dateString}", now())
                        """;

        var filters = new JqlCollection<DateExpression> { dateString, dateTime, Date.Only.Now };

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName].In(filters))
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
            .Where(f => f.Custom.Date[CustomFieldName].NotIn(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" not in ("{dateString}", "{dateString}", now())
                        """;

        var filters = new JqlCollection<DateExpression> { dateString, dateTime, Date.Only.Now };

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName].NotIn(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}