namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Support;

public partial class CategoryTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        const string expected = $"""
                                 {Fields.Category} {Operators.In} ("{CategoryName}", "{CategoryName}")
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Category.In(CategoryName, CategoryName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Params_When_Are_Heterogeneous()
    {
        const string expected = $"""
                                 {Fields.Category} {Operators.NotIn} ("{CategoryName}", "{CategoryName}")
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Category.NotIn(CategoryName, CategoryName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}