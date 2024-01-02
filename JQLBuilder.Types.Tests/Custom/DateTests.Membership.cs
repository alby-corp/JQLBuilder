namespace JQLBuilder.Types.Tests.Custom;

using Fields.BuildIn;
using Primitive;
using Types.Custom;
using Types.Support;

public partial class DateTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        "{CustomFieldName}" in ("{dateString}", "{dateString}", now())
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName].In(dateString, dateTime, f.Date.Now))
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

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName].NotIn(dateString, dateTime, f.Date.Now))
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

        var filters = new List<DateExpression> { dateString, dateString, dateString }.ToJqlCollection();

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

        var filters = new List<DateExpression> { dateString, dateTime, Date.DateOnly.Now  }.ToJqlCollection();
        
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

        var filters = new List<DateExpression> { dateString, dateString, dateString }.ToJqlCollection();

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

        var filters = new List<DateExpression> { dateString, dateTime, Date.DateOnly.Now }.ToJqlCollection();

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName].NotIn(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}