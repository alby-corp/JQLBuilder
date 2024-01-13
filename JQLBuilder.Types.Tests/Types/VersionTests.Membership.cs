namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;

public partial class VersionTests
{
    #region In

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.FixVersion} {Operators.In} ({VersionId}, {VersionId}, {VersionId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.In(VersionId, VersionId, VersionId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.FixVersion} {Operators.In} ({VersionId}, {VersionId}, {VersionId})";

        var filter = new JqlCollection<VersionExpression> { VersionId, VersionId, VersionId };

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.FixVersion} {Operators.In} ({VersionId}, "{VersionName}", {VersionId})
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.In(VersionId, VersionName, VersionId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.FixVersion} {Operators.In} ({VersionId}, "{VersionName}", {VersionId})""";

        var filter = new JqlCollection<VersionExpression> { VersionId, VersionName, VersionId };

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Not In

    [TestMethod]
    public void Should_Parses_NotIn_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.FixVersion} {Operators.NotIn} ({VersionId}, {VersionId}, {VersionId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.NotIn(VersionId, VersionId, VersionId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.FixVersion} {Operators.NotIn} ({VersionId}, {VersionId}, {VersionId})";

        var filter = new JqlCollection<VersionExpression> { VersionId, VersionId, VersionId };

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_NotIn_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.FixVersion} {Operators.NotIn} ({VersionId}, "{VersionName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.NotIn(VersionId, VersionName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.FixVersion} {Operators.NotIn} ({VersionId}, "{VersionName}", {VersionId})""";

        var filter = new JqlCollection<VersionExpression> { VersionId, VersionName, VersionId };

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}