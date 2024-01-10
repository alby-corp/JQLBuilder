namespace JQLBuilder.Types.Tests.Types;

using Constants;

public partial class ProjectTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"""
                                 {Fields.Project} {Operators.Equals} "{ProjectName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project == ProjectName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"{Fields.Project} {Operators.NotEquals} {ProjectId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project != ProjectId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"""
                                 {Fields.Project} {Operators.Equals} "{ProjectName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => ProjectName == f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"{Fields.Project} {Operators.NotEquals} {ProjectId}";

        var actual = JqlBuilder.Query
            .Where(f => ProjectId != f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}