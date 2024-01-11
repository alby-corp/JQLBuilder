namespace JQLBuilder.Types.Tests.Types;

using Constants;

public partial class CategoryTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"""
                                 {Fields.Category} {Operators.Equals} "{CategoryName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Category == CategoryName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        const string expected = $"""
                                 {Fields.Category} {Operators.NotEquals} "{CategoryName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Category != CategoryName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"""
                                 {Fields.Category} {Operators.Equals} "{CategoryName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => CategoryName == f.Category)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        const string expected = $"""
                                 {Fields.Category} {Operators.NotEquals} "{CategoryName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => CategoryName != f.Category)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}