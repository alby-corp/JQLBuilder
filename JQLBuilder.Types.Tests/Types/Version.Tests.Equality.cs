namespace JQLBuilder.Types.Tests.Types;

using Constants;

public partial class VersionTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"""
                                 {Fields.AffectedVersion} {Operators.Equals} "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected == VersionName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"{Fields.AffectedVersion} {Operators.NotEquals} {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected != VersionId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression()
    {
        const string expected = $"""
                                 {Fields.AffectedVersion} {Operators.GreaterThan} "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected > VersionName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_To_Expression()
    {
        var expected = $"{Fields.AffectedVersion} {Operators.GreaterThanOrEqual} {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected >= VersionId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression()
    {
        const string expected = $"""
                                 {Fields.AffectedVersion} {Operators.LessThan} "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected < VersionName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_To_Expression()
    {
        var expected = $"{Fields.AffectedVersion} {Operators.LessThanOrEqual} {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected <= VersionId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #region Reverse

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"""
                                 {Fields.FixVersion} {Operators.Equals} "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => VersionName == f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"{Fields.FixVersion} {Operators.NotEquals} {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => VersionId != f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression_Reverse()
    {
        const string expected = $"""
                                 {Fields.FixVersion} {Operators.GreaterThan} "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => VersionName < f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_To_Expression_Reverse()
    {
        var expected = $"{Fields.FixVersion} {Operators.GreaterThanOrEqual} {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => VersionId <= f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression_Reverse()
    {
        const string expected = $"""
                                 {Fields.FixVersion} {Operators.LessThan} "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => VersionName > f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_To_Expression_Reverse()
    {
        var expected = $"{Fields.FixVersion} {Operators.LessThanOrEqual} {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => VersionId >= f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}