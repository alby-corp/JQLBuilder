namespace JQLBuilder.Types.Tests.Types;

using Constants;

public partial class ParentTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"""
                                 {Fields.Parent} {Operators.Equals} "{ParentName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Parent == ParentName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"{Fields.Parent} {Operators.NotEquals} {ParentId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Parent != ParentId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"""
                                 {Fields.Parent} {Operators.Equals} "{ParentName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => ParentName == f.Parent)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"{Fields.Parent} {Operators.NotEquals} {ParentId}";

        var actual = JqlBuilder.Query
            .Where(f => ParentId != f.Parent)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}