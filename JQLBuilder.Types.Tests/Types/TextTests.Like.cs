namespace JQLBuilder.Types.Tests.Types;

using Support;

public partial class TextTests
{
    [TestMethod]
    public void Should_Parses_Like()
    {
        const string expected = $"""
                                 "{CustomFieldName}" ~ "{Text}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Text[CustomFieldName].Like(Text))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}