namespace JQLBuilder.Types.Tests.Types;

public partial class VersionTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"""
                                 affectedVersion = "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected == VersionName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"affectedVersion != {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected != VersionId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Greater_Than_Expression()
    {
        const string expected = $"""
                                 affectedVersion > "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected > VersionName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_To_Expression()
    {
        var expected = $"affectedVersion >= {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected >= VersionId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Less_Than_Expression()
    {
        const string expected = $"""
                                 affectedVersion < "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected < VersionName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_To_Expression()
    {
        var expected = $"affectedVersion <= {VersionId}";

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
                                 fixVersion = "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => VersionName == f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"fixVersion != {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => VersionId != f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Greater_Than_Expression_Reverse()
    {
        const string expected = $"""
                                 fixVersion > "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f =>  VersionName < f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_To_Expression_Reverse()
    {
        var expected = $"fixVersion >= {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => VersionId <= f.Version.Fix )
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Less_Than_Expression_Reverse()
    {
        const string expected = $"""
                                 fixVersion < "{VersionName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f =>  VersionName > f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_To_Expression_Reverse()
    {
        var expected = $"fixVersion <= {VersionId}";

        var actual = JqlBuilder.Query
            .Where(f => VersionId >= f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    #endregion    
}