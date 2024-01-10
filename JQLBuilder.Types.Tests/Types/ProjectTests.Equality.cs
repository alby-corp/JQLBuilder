namespace JQLBuilder.Types.Tests.Types;

public partial class ProjectTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"""
                                 project = "{ProjectName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project == ProjectName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"project != {ProjectId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project != ProjectId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"""
                                 project = "{ProjectName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => ProjectName == f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"project != {ProjectId}";

        var actual = JqlBuilder.Query
            .Where(f => ProjectId != f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}