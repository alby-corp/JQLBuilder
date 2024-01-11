namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;
using Support;

public partial class CategoryTests
{
    [TestMethod]
    public void Should_Parses_Is_Empty()
    {
        const string expected = $"{Fields.Category} {Operators.Is} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Category.Is(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Null()
    {
        const string expected = $"{Fields.Category} {Operators.Is} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Category.Is(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Empty()
    {
        const string expected = $"{Fields.Category} {Operators.IsNot} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Category.IsNot(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Null()
    {
        const string expected = $"{Fields.Category} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Category.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}