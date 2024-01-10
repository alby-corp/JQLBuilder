namespace JQLBuilder.Types.Tests.Types;

using Support;
using Functions = JQLBuilder.Functions;

public partial class VersionTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        fixVersion in ({VersionId}, "{VersionName}", latestReleasedVersion())
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.In(VersionId, VersionName, f.Version.Functions.LatestReleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"fixVersion in ({VersionId}, {VersionId}, {VersionId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.In(VersionId, VersionId, VersionId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        fixVersion not in ({VersionId}, "{VersionName}", latestReleasedVersion())
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.NotIn(VersionId, VersionName, Functions.Version.LatestReleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Homogeneous()
    {
        var expected = $"""
                        fixVersion in ("{VersionName}", "{VersionName}", "{VersionName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.In(VersionName, VersionName, VersionName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}