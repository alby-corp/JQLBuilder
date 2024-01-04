namespace JQLBuilder.Types.Tests.Types;

using Fields;

[TestClass]
public partial class DateTests
{
    const string CustomFieldName = "Start date";
    const int CustomFieldId = 10421;
    readonly string dateString = $"{DateTime.Now:yyyy-MM-dd}";
    readonly DateTime dateTime = DateTime.Now;

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Name()
    {
        const string expected = $"""
                                 "{CustomFieldName}" = now()
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName] == f.DateOnly.Now)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Id()
    {
        var expected = $"cf[{CustomFieldId}] = now()";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldId] == f.DateOnly.Now)
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
            .Where(f => f.Custom.Date[CustomFieldName] == dateString)
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
            .Where(f => dateString == f.Custom.Date[CustomFieldName])
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
            .Where(f => f.Custom.Date[CustomFieldName] == DateTime.Parse(dateString))
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
            .Where(f => DateTime.Parse(dateString) == f.Custom.Date[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Throw_Exception_When_Custom_Date_Is_Invalid_String()
    {
        Assert.ThrowsException<ArgumentException>(Actual, "Invalid Date Format!");
        return;

        string Actual() => JqlBuilder.Query
            .Where(f => f.Custom.Date[CustomFieldName] == "invalid date")
            .ToString();
    }
}