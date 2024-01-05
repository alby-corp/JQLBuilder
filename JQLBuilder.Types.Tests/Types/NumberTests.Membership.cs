namespace JQLBuilder.Types.Tests.Types;

using Facade;
using Infrastructure;
using JqlTypes;

public partial class NumberTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"{CustomFieldName} in ({Number}, {Number})";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName].In(Number, Number))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"{CustomFieldName} in ({Number}, {Number}, {Number})";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName].In(Number, Number, Number))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"{CustomFieldName} not in ({Number}, {Number})";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName].NotIn(Number, Number))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Homogeneous()
    {
        var expected = $"{CustomFieldName} not in ({Number}, {Number}, {Number})";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName].NotIn(Number, Number, Number))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        var expected = $"{CustomFieldName} in ({Number}, {Number}, {Number})";

        var filters = new JqlCollection<NumberExpression> { Number, Number, Number };

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName].In(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"{CustomFieldName} in ({Number}, {Number})";

        var filters = new JqlCollection<NumberExpression> { Number, Number };

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName].In(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{CustomFieldName} not in ({Number}, {Number}, {Number})";

        var filters = new JqlCollection<NumberExpression> { Number, Number, Number };

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName].NotIn(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"{CustomFieldName} not in ({Number}, {Number})";

        var filters = new JqlCollection<NumberExpression> { Number, Number };

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName].NotIn(filters))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}