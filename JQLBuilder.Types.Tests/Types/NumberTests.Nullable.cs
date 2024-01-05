namespace JQLBuilder.Types.Tests.Types;

using Facade.Builders;
using Support;

public partial class NumberTests
{
    [TestMethod]
    public void Should_Parses_Is_Empty()
    {
        const string expected = $"{CustomFieldName} is EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Number[CustomFieldName].Is(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Null()
    {
        const string expected = $"{CustomFieldName} is NULL";

        var actual = JqlBuilder.Query
            .Where(f => f.Number[CustomFieldName].Is(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Default()
    {
        const string expected = $"{CustomFieldName} is EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Number[CustomFieldName].Is(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_IsNot_Empty()
    {
        const string expected = $"{CustomFieldName} is not EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Number[CustomFieldName].IsNot(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_IsNot_Null()
    {
        const string expected = $"{CustomFieldName} is not NULL";

        var actual = JqlBuilder.Query
            .Where(f => f.Number[CustomFieldName].IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_IsNot_Default()
    {
        const string expected = $"{CustomFieldName} is not EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Number[CustomFieldName].IsNot(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}