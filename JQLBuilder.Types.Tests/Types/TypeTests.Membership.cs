namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;

public partial class TypeTests
{
    #region In

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Type} {Operators.In} ({TypeId}, {TypeId}, {TypeId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Type.In(TypeId, TypeId, TypeId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Type} {Operators.In} ({TypeId}, {TypeId}, {TypeId})";

        var filter = new JqlCollection<TypeExpression> { TypeId, TypeId, TypeId };

        var actual = JqlBuilder.Query
            .Where(f => f.Type.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Type} {Operators.In} ({TypeId}, "{TypeName}", {TypeId})
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Type.In(TypeId, TypeName, TypeId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Type} {Operators.In} ({TypeId}, "{TypeName}", {TypeId})""";

        var filter = new JqlCollection<TypeExpression> { TypeId, TypeName, TypeId };

        var actual = JqlBuilder.Query
            .Where(f => f.Type.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Not In

    [TestMethod]
    public void Should_Parses_NotIn_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Type} {Operators.NotIn} ({TypeId}, {TypeId}, {TypeId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Type.NotIn(TypeId, TypeId, TypeId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Type} {Operators.NotIn} ({TypeId}, {TypeId}, {TypeId})";

        var filter = new JqlCollection<TypeExpression> { TypeId, TypeId, TypeId };

        var actual = JqlBuilder.Query
            .Where(f => f.Type.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_NotIn_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Type} {Operators.NotIn} ({TypeId}, "{TypeName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Type.NotIn(TypeId, TypeName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Type} {Operators.NotIn} ({TypeId}, "{TypeName}", {TypeId})""";

        var filter = new JqlCollection<TypeExpression> { TypeId, TypeName, TypeId };

        var actual = JqlBuilder.Query
            .Where(f => f.Type.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}