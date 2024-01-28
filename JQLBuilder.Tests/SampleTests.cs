namespace JQLBuilder.Tests;

using JQLBuilder.Types.Support;
using Functions = Functions;

[TestClass]
public class SampleTests
{
    const int ProjectId = 12345;
    const string Project1 = "CLOVER";
    const string Project2 = "HEARTH";
    const string Project3 = "SPADE";
    const string ProjectLead = "hulk@avengers.world";

    [TestMethod]
    public void Change()
    {
        const string expected = $"""project = project AND priority CHANGED AFTER now() BEFORE "2000-01-01" DURING ("2000-01-01 13:00", now()) BY ("{ProjectLead}", "{ProjectLead}")""";

        var actual = JqlBuilder.Query.Where(f =>
                (f.Project == "project") &
                f.Priority.Changed(c => c
                    .After(f.Functions.Date.Now)
                    .Before("2000-01-01")
                    .During("2000-01-01 13:00", f.Functions.Date.Now)
                    .By(ProjectLead, ProjectLead)
                ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod1()
    {
        var expected = $"""project = {Project1} AND project = {ProjectId} AND project in ({Project1}, {ProjectId}) AND (project in projectsLeadByUser("{ProjectLead}") OR project = {Project1}) AND project not in projectsWhereUserHasRole("{ProjectLead}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => f.Project == ProjectId)
            .And(f => f.Project.In(Project1, ProjectId))
            .And(f => f.Project.In(f.Functions.Project.LeadByUser(ProjectLead)) | (f.Project == Project1))
            .And(f => f.Project.NotIn(Functions.Project.WhereUserHasRole(ProjectLead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod2()
    {
        const string expected = $"project = {Project1} OR project = {Project2} order by project asc, affectedVersion desc";

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
        var expected = $"project = {Project1} AND (project = {ProjectId} OR project in ({Project2}, {ProjectId}))";

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
            $"project = {Project1} AND (project = {ProjectId} OR project = {Project2} AND project = {Project3})";

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
            $"NOT(project = {Project1}) AND (project = {ProjectId} OR project = {Project2} AND project = {Project3})";

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
            $"NOT NOT(project = {Project1}) AND (project = {ProjectId} OR project = {Project2} AND project = {Project3})";

        var actual = JqlBuilder.Query
            .Where(f => !!(f.Project == Project1))
            .And(f => (f.Project == ProjectId) | ((f.Project == Project2) & (f.Project == Project3)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod8()
    {
        const string expected = $"NOT NOT(project = {Project1})";

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

    [TestMethod]
    public void TestMethod10()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.Version.Affected == f.Functions.Version.LatestReleased).ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod11()
    {
        const string expected = "affectedVersion in releasedVersions()";

        var actual = JqlBuilder.Query.Where(f => f.Version.Affected.In(f.Functions.Version.Released)).ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod12()
    {
        const string expected = """affectedVersion in ("12121", latestReleasedVersion(), 123)""";

        var actual = JqlBuilder.Query.Where(f => f.Version.Affected.In("12121", f.Functions.Version.LatestReleased, 123)).ToString();

        Assert.AreEqual(expected, actual);
    }
}