namespace JQLBuilder.Tests;

using Global;

[TestClass]
public class SimpleTests
{
    const int ProjectId = 12345;
    const string Project1 = "CLOVER";
    const string Project2 = "HEARTH";
    const string Project3 = "SPADE";
    const string ProjectLead = "hulk@avengers.world";
    const string Component1 = "Black Bull";
    const string Component2 = "Golder Dawn";

    [TestMethod]
    public void TestMethod1()
    {
        var expected =
            $"""project = "{Project1}" AND project = {ProjectId} AND project in ("{Project1}", {ProjectId}) AND (project in projectsLeadByUser("{ProjectLead}") OR project = "{Project1}") AND project not in projectsWhereUserHasRole("{ProjectLead}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => f.Project == ProjectId)
            .And(f => f.Project.In(Project1, ProjectId))
            .And(f => f.Project.In(functions => functions.LeadByUser(ProjectLead)) | (f.Project == Project1))
            .And(f => f.Project.NotIn(functions => functions.WhereUserHasRole(ProjectLead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod2()
    {
        const string expected =
            $"""project = "{Project1}" OR project = "{Project2}" order by project asc, assignee desc""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .Or(f => f.Project == Project2)
            .OrderBy(f => OrderingFields.Project)
            .ThenByDescending(f => OrderingFields.Assignee)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod3()
    {
        const string expected = "order by project asc, assignee desc, assignee asc";

        var actual = JqlBuilder.Query
            .OrderBy(f => OrderingFields.Project)
            .ThenByDescending(f => OrderingFields.Assignee)
            .ThenBy(f => OrderingFields.Assignee)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod4()
    {
        const string expected = "project = \"CLOVER\" AND (project = 12345 OR project in (\"CLOVER\", 12345))";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => (f.Project == ProjectId) | f.Project.In(Project1, ProjectId))
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