namespace JQLBuilder.Types.Tests.Types;

using DateOnly = System.DateOnly;
using DateTime = System.DateTime;
using Functions = JQLBuilder.Functions;

[TestClass]
public partial class DateOnlyTests
{
    const string CustomFieldName = "Start date";
    const int CustomFieldId = 10421;
    readonly string dateString = $"{DateTime.Now:yyyy-MM-dd}";
    readonly string relativeDateString = $"2w 1d";
    readonly DateTime dateTime = DateTime.Now;
    readonly DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Name()
    {
        const string expected = $"""
                                 "{CustomFieldName}" = now()
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName] == Functions.Date.Now)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Id()
    {
        var expected = $"cf[{CustomFieldId}] = now()";

        var actual = JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldId] == f.Functions.Date.Now)
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
            .Where(f => f.DateOnly[CustomFieldName] == dateString)
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
            .Where(f => dateString == f.DateOnly[CustomFieldName])
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
            .Where(f => f.DateOnly[CustomFieldName] == relativeDateString)
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
            .Where(f => relativeDateString == f.DateOnly[CustomFieldName])
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
            .Where(f => f.DateOnly[CustomFieldName] == DateOnly.Parse(dateString))
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
            .Where(f => DateOnly.Parse(dateString) == f.DateOnly[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Throw_Exception_When_Custom_Date_Is_Invalid_String()
    {
        Assert.ThrowsException<ArgumentException>(Actual, "Invalid Date Format!");
        return;

        string Actual() => JqlBuilder.Query
            .Where(f => f.DateOnly[CustomFieldName] == "invalid date")
            .ToString();
    }
}
