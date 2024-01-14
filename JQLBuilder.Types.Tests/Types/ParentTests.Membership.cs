namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;

public partial class ParentTests
{
    #region In

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Parent} {Operators.In} ({ParentId}, {ParentId}, {ParentId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Parent.In(ParentId, ParentId, ParentId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Parent} {Operators.In} ({ParentId}, {ParentId}, {ParentId})";

        var filter = new JqlCollection<ParentExpression> { ParentId, ParentId, ParentId };

        var actual = JqlBuilder.Query
            .Where(f => f.Parent.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Parent} {Operators.In} ({ParentId}, "{ParentName}", {ParentId})
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Parent.In(ParentId, ParentName, ParentId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Parent} {Operators.In} ({ParentId}, "{ParentName}", {ParentId})""";

        var filter = new JqlCollection<ParentExpression> { ParentId, ParentName, ParentId };

        var actual = JqlBuilder.Query
            .Where(f => f.Parent.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Not In

    [TestMethod]
    public void Should_Parses_NotIn_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Parent} {Operators.NotIn} ({ParentId}, {ParentId}, {ParentId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Parent.NotIn(ParentId, ParentId, ParentId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Parent} {Operators.NotIn} ({ParentId}, {ParentId}, {ParentId})";

        var filter = new JqlCollection<ParentExpression> { ParentId, ParentId, ParentId };

        var actual = JqlBuilder.Query
            .Where(f => f.Parent.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_NotIn_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Parent} {Operators.NotIn} ({ParentId}, "{ParentName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Parent.NotIn(ParentId, ParentName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Parent} {Operators.NotIn} ({ParentId}, "{ParentName}", {ParentId})""";

        var filter = new JqlCollection<ParentExpression> { ParentId, ParentName, ParentId };

        var actual = JqlBuilder.Query
            .Where(f => f.Parent.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}