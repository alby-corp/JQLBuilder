namespace JQLBuilder.Types.Tests.Types;

using Support;
using Functions = JQLBuilder.Functions;

public partial class ProjectTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        project in ({ProjectId}, "{ProjectName}", projectsLeadByUser("{Lead}"))
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectId, ProjectName, f.Project.Functions.LeadByUser(Lead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"""
                        project in ({ProjectId}, {ProjectId}, {ProjectId})
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectId, ProjectId, ProjectId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        project in ({ProjectId}, "{ProjectName}", projectsLeadByUser("{Lead}"))
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectId, ProjectName, Functions.Project.LeadByUser(Lead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Homogeneous()
    {
        var expected = $"""
                        project in ("{ProjectName}", "{ProjectName}", "{ProjectName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectName, ProjectName, ProjectName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}