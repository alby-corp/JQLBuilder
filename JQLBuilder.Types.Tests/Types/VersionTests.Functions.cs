namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Support;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

// VALID:
// project = MyProject AND fixVersion {Operators.In} (0.1, "Version1", latestReleasedVersion())
// project = MyProject AND fixVersion = latestReleasedVersion()
// project = MyProject AND fixVersion {Operators.In} releasedVersions()
//
// INVALID:
// project = MyProject AND fixVersion = releasedVersions()

public partial class VersionTests
{
    #region Equals NotEquals

    [TestMethod]
    public void Should_Parses_Equals_LatestReleasedVersion()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.Equals} {FunctionsConstants.LatestReleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected == f.Version.Functions.LatestReleased)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotEquals_LatestUnreleasedVersion()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotEquals} {FunctionsConstants.LatestUnreleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected != f.Version.Functions.LatestUnreleased)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Equals NotEquals Static

    [TestMethod]
    public void Should_Parses_Equals_LatestReleasedVersion_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.Equals} {FunctionsConstants.LatestReleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected == Functions.Version.LatestReleased)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotEquals_LatestUnreleasedVersion_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotEquals} {FunctionsConstants.LatestUnreleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected != Functions.Version.LatestUnreleased)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region In NotIn

    [TestMethod]
    public void Should_Parses_In_LatestReleasedVersion()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.In} ({FunctionsConstants.LatestReleased}())";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(f.Version.Functions.LatestReleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_LatestUnreleasedVersion()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.In} ({FunctionsConstants.LatestUnreleased}())";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(f.Version.Functions.LatestUnreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_ReleasedVersions()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.In} {FunctionsConstants.Released}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(f.Version.Functions.Released))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_UnreleasedVersion()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.In} {FunctionsConstants.Unreleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(f.Version.Functions.Unreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_LatestReleasedVersion()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotIn} ({FunctionsConstants.LatestReleased}())";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.NotIn(f.Version.Functions.LatestReleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_LatestUnreleasedVersion()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotIn} ({FunctionsConstants.LatestUnreleased}())";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.NotIn(f.Version.Functions.LatestUnreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_ReleasedVersions()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotIn} {FunctionsConstants.Released}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.NotIn(f.Version.Functions.Released))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_UnreleasedVersion()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotIn} {FunctionsConstants.Unreleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.NotIn(f.Version.Functions.Unreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region In NotIn Static

    [TestMethod]
    public void Should_Parses_In_LatestReleasedVersion_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.In} ({FunctionsConstants.LatestReleased}())";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(Functions.Version.LatestReleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_LatestUnreleasedVersion_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.In} ({FunctionsConstants.LatestUnreleased}())";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(Functions.Version.LatestUnreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_ReleasedVersions_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.In} {FunctionsConstants.Released}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(Functions.Version.Released))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_UnreleasedVersion_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.In} {FunctionsConstants.Unreleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(Functions.Version.Unreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_LatestReleasedVersion_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotIn} ({FunctionsConstants.LatestReleased}())";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.NotIn(Functions.Version.LatestReleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_LatestUnreleasedVersion_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotIn} ({FunctionsConstants.LatestUnreleased}())";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.NotIn(Functions.Version.LatestUnreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_ReleasedVersions_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotIn} {FunctionsConstants.Released}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.NotIn(Functions.Version.Released))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_UnreleasedVersion_Static()
    {
        const string expected = $"{Fields.AffectedVersion} {Operators.NotIn} {FunctionsConstants.Unreleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.NotIn(Functions.Version.Unreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}
