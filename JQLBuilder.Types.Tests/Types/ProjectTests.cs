namespace JQLBuilder.Types.Tests.Types;

using Facade.Builders;
using Support;

[TestClass]
public class ProjectTests
{
    const int ProjectId = 12345;
    const string Project1 = "CLOVER";
    const string Project2 = "HEARTH";
    const string Project3 = "SPADE";
    const string ProjectLead = "hulk@avengers.world";

    [TestMethod]
    public void TestMethod1()
    {
        var expected = $"""project = "{Project1}" AND project = {ProjectId} AND project in ("{Project1}", {ProjectId}) AND (project in (projectsLeadByUser()) OR project = "{Project1}") AND project not in (projectsWhereUserHasRole("{ProjectLead}"))""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => f.Project == ProjectId)
            .And(f => f.Project.In(Project1, ProjectId))
            .And(f => f.Project.In(f.Project.Functions.LeadByUser()) | (f.Project == Project1))
            .And(f => f.Project.NotIn(f.Project.Functions.WhereUserHasRole(ProjectLead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod2()
    {
        const string expected = $"""project = "{Project1}" OR project = "{Project2}" order by project asc, affectedVersion desc""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .Or(f => f.Project == Project2)
            .OrderBy(f => f.Project)
            .ThenByDescending(f => f.Version.Affected)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod3()
    {
        const string expected = "order by project asc, project desc, fixVersion asc";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Project)
            .ThenByDescending(f => f.Project)
            .ThenBy(f => f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod4()
    {
        var expected = $"""project = "{Project1}" AND (project = {ProjectId} OR project in ("{Project2}", {ProjectId}))""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => (f.Project == ProjectId) | f.Project.In(Project2, ProjectId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod5()
    {
        var expected =
            $"""project = "{Project1}" AND (project = {ProjectId} OR project = "{Project2}" AND project = "{Project3}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => (f.Project == ProjectId) | ((f.Project == Project2) & (f.Project == Project3)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod6()
    {
        var expected =
            $"""NOT(project = "{Project1}") AND (project = {ProjectId} OR project = "{Project2}" AND project = "{Project3}")""";

        var actual = JqlBuilder.Query
            .Where(f => !(f.Project == Project1))
            .And(f => (f.Project == ProjectId) | ((f.Project == Project2) & (f.Project == Project3)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod7()
    {
        var expected =
            $"""NOT NOT(project = "{Project1}") AND (project = {ProjectId} OR project = "{Project2}" AND project = "{Project3}")""";

        var actual = JqlBuilder.Query
            .Where(f => !!(f.Project == Project1))
            .And(f => (f.Project == ProjectId) | ((f.Project == Project2) & (f.Project == Project3)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod8()
    {
        const string expected = $"""NOT NOT(project = "{Project1}")""";

        var actual = JqlBuilder.Query
            .Where(f => !!(f.Project == Project1))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod9()
    {
        var expected = $"project is NULL AND (project = {ProjectId} OR project is not EMPTY)";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Is(v => v.Null))
            .And(f => (f.Project == ProjectId) | f.Project.IsNot(v => v.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}