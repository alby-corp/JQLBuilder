namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Support;

public partial class ProjectTests
{
    #region In

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Project} {Operators.In} ({ProjectId}, "{ProjectName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectId, ProjectName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Project} {Operators.In} ({ProjectId}, {ProjectId}, {ProjectId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectId, ProjectId, ProjectId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Project} {Operators.In} ({ProjectId}, "{ProjectName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectId, ProjectName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Homogeneous()
    {
        const string expected = $"""
                                 {Fields.Project} {Operators.In} ("{ProjectName}", "{ProjectName}", "{ProjectName}")
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectName, ProjectName, ProjectName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Not In

    [TestMethod]
    public void Should_Parses_NotIn_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Project} {Operators.NotIn} ({ProjectId}, "{ProjectName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(ProjectId, ProjectName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Project} {Operators.NotIn} ({ProjectId}, {ProjectId}, {ProjectId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(ProjectId, ProjectId, ProjectId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_NotIn_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Project} {Operators.NotIn} ({ProjectId}, "{ProjectName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(ProjectId, ProjectName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_NotIn_Params_When_Are_Homogeneous()
    {
        const string expected = $"""
                                 {Fields.Project} {Operators.NotIn} ("{ProjectName}", "{ProjectName}", "{ProjectName}")
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(ProjectName, ProjectName, ProjectName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}