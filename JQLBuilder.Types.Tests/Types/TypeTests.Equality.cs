namespace JQLBuilder.Types.Tests.Types;

using Constants;

public partial class TypeTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"""
                                 {Fields.Type} {Operators.Equals} "{TypeName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Type == TypeName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"{Fields.Type} {Operators.NotEquals} {TypeId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Type != TypeId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"""
                                 {Fields.Type} {Operators.Equals} "{TypeName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => TypeName == f.Type)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"{Fields.Type} {Operators.NotEquals} {TypeId}";

        var actual = JqlBuilder.Query
            .Where(f => TypeId != f.Type)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}