namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Support;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

public partial class VersionTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.FixVersion} {Operators.In} ({VersionId}, "{VersionName}", {FunctionsConstants.LatestReleased})""";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.In(VersionId, VersionName, f.Version.Functions.LatestReleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

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
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.FixVersion} {Operators.NotIn} ({VersionId}, "{VersionName}", {FunctionsConstants.LatestReleased})""";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.NotIn(VersionId, VersionName, Functions.Version.LatestReleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.FixVersion} {Operators.NotIn} ("{VersionName}", "{VersionName}", "{VersionName}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.NotIn(VersionName, VersionName, VersionName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}