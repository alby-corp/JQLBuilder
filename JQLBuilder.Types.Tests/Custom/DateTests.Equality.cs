namespace JQLBuilder.Types.Tests.Custom;

public partial class DateTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        var expected = $"""
                        "{CustomFieldName}" = "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName] == dateString)
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
            .Where(f => f.Custom.Date[CustomFieldName] != dateString )
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
            .Where(f => f.Custom.Date[CustomFieldName] > dateString)
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
            .Where(f => f.Custom.Date[CustomFieldName] >= dateString)
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
            .Where(f => f.Custom.Date[CustomFieldName] < dateString)
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
            .Where(f => f.Custom.Date[CustomFieldName] <= dateString)
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
            .Where(f => dateString == f.Custom.Date[CustomFieldName])
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
            .Where(f => f.Custom.Date[CustomFieldName] != dateString)
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
            .Where(f => dateString > f.Custom.Date[CustomFieldName])
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
            .Where(f => dateString >= f.Custom.Date[CustomFieldName])
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
            .Where(f => dateString < f.Custom.Date[CustomFieldName])
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
            .Where(f => dateString <= f.Custom.Date[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    #endregion
}