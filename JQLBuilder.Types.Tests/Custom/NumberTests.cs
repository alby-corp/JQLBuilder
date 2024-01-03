namespace JQLBuilder.Types.Tests.Custom;

[TestClass]
public partial class NumberTests
{
    const string CustomFieldName = "Number";
    const int CustomFieldId = 10421;
    const int Number = 1234;

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Name()
    {
        var expected = $"{CustomFieldName} = {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName] == Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Id()
    {
        var expected = $"cf[{CustomFieldId}] = {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldId] == Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_String()
    {
        var expected = $"{CustomFieldName} = {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName] == Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_String_Reverse()
    {
        var expected = $"{CustomFieldName} = {Number}";

        var actual = JqlBuilder.Query
            .Where(f => Number == f.Custom.Number[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Throw_Exception_When_Custom_Date_Is_Invalid_String()
    {
        Assert.ThrowsException<ArgumentException>(Actual, "Invalid Date Format!");
        return;

        string Actual() => JqlBuilder.Query
            .Where(f => f.Custom.DateTime[CustomFieldName] == "invalid date")
            .ToString();
    }
}