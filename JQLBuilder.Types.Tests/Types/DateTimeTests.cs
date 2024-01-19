namespace JQLBuilder.Types.Tests.Types;

using DateTime = System.DateTime;
using Functions = JQLBuilder.Functions;

[TestClass]
public partial class DateTimeTests
{
    const string CustomFieldName = "Start date";
    const int CustomFieldId = 10421;
    readonly string dateString = $"{DateTime.Now:yyyy-MM-dd HH:mm}";
    readonly string relativeDateString = $"2w 1d";
    readonly DateTime dateTime = DateTime.Now;

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Name()
    {
        const string expected = $"""
                                 "{CustomFieldName}" = now()
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] == f.Functions.Date.Now)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Id()
    {
        var expected = $"cf[{CustomFieldId}] = now()";

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldId] == Functions.Date.Now)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_String()
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
    public void Should_Parses_Custom_Date_String_Reverse()
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
    public void Should_Parses_Custom_Date_String_RelativeDate()
    {
        var expected = $"""
                        "{CustomFieldName}" = "{relativeDateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] == relativeDateString)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Custom_Date_String_RelativeDate_Reverse()
    {
        var expected = $"""
                        "{CustomFieldName}" = "{relativeDateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => relativeDateString == f.DateTime[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_DateTime()
    {
        var expected = $"""
                        "{CustomFieldName}" = "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] == DateTime.Parse(dateString))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_DateTime_Reverse()
    {
        var expected = $"""
                        "{CustomFieldName}" = "{dateString}"
                        """;

        var actual = JqlBuilder.Query
            .Where(f => DateTime.Parse(dateString) == f.DateTime[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Throw_Exception_When_Custom_Date_Is_Invalid_String()
    {
        Assert.ThrowsException<ArgumentException>(Actual, "Invalid Date Format!");
        return;

        string Actual() => JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] == "invalid date")
            .ToString();
    }
}
