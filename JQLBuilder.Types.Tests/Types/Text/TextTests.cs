namespace JQLBuilder.Types.Tests.Types.Text;

using Support;

[TestClass]
public partial class TextTests
{
    const string CustomFieldName = "Start date";
    const int CustomFieldId = 10421;
    const string Text = "my text";

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Name()
    {
        const string expected = $"""
                                 "{CustomFieldName}" is EMPTY
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Text[CustomFieldName].Is(v => v.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Custom_Date_By_Id()
    {
        var expected = $"cf[{CustomFieldId}] is EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Text[CustomFieldId].Is(v => v.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}