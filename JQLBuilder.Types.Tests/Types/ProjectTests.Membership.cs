namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;

public partial class ProjectTests
{
    #region In

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
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Project} {Operators.In} ({ProjectId}, {ProjectId}, {ProjectId})";
        
        var filter = new JqlCollection<ProjectExpression> { ProjectId, ProjectId, ProjectId };

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Project} {Operators.In} ({ProjectId}, "{ProjectName}", {ProjectId})
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectId, ProjectName, ProjectId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Project} {Operators.In} ({ProjectId}, "{ProjectName}", {ProjectId})""";
        
        var filter = new JqlCollection<ProjectExpression> { ProjectId, ProjectName, ProjectId };

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Not In

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
    public void Should_Parses_NotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Project} {Operators.NotIn} ({ProjectId}, {ProjectId}, {ProjectId})";
        
        var filter = new JqlCollection<ProjectExpression> { ProjectId, ProjectId, ProjectId };

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(filter))
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
    public void Should_Parses_NotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Project} {Operators.NotIn} ({ProjectId}, "{ProjectName}", {ProjectId})""";
        
        var filter = new JqlCollection<ProjectExpression> { ProjectId, ProjectName, ProjectId };

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    #endregion
}