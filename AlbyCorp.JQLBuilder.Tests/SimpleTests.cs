namespace AlbyCorp.JQLBuilder.Tests;

using Queries;
using Types;

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
            $"""(((((project = "{Project1}") and (project = {ProjectId})) and (project in ("{Project1}", {ProjectId}))) and ((project in projectsLeadByUser("{ProjectLead}")) or (project = "{Project1}"))) and (project not in projectsWhereUserHasRole("{ProjectLead}")))""";

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
        const string expected = $"""((project = "{Project1}") or (project = "{Project2}")) order by project asc, assignee desc""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .Or(f => f.Project == Project2)
            .OrderBy(f => f.Project)
            .ThenByDescending(f => f.Assignee)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod3()
    {
        const string expected = "order by project asc, assignee desc, assignee asc";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Project)
            .ThenByDescending(f => f.Assignee)
            .ThenBy(f => f.Assignee)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void TestMethod4()
    {
        const string expected = "project = \"CLOVER\" and (project = 12345 or project in (\"CLOVER\", 12345))";
        
        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => (f.Project == ProjectId) | f.Project.In(Project1, ProjectId))
            .ToString();
        
        var actual1 = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => (f.Project == ProjectId) | f.Project == "CAZZO" & f.Project == "FIGA")
            .ToString();

        Assert.AreEqual(expected, actual);
    }    
    [TestMethod]
    public void TestMethod5()
    {
        var expected = $"project = {Project1} and (project = {ProjectId} or project = {Project2} and project = {Project3})";
        
        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project1)
            .And(f => (f.Project == ProjectId) | f.Project == Project2 & f.Project == Project3)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}