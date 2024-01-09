namespace JQLBuilder.Types.Tests.Types;

using Support;
using Functions = JQLBuilder.Functions;

public partial class ProjectTests
{
    [TestMethod]
    public void Should_Parses_ProjectLeadByUser()
    {
        const string expected = $"""
                                 project in (projectsLeadByUser("{Lead}"))
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Project.Functions.LeadByUser(Lead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_ProjectLeadByUser_Static()
    {
        const string expected = $"""
                                 project in (projectsLeadByUser("{Lead}"))
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(Functions.Project.LeadByUser(Lead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WhereUserHasPermission()
    {
        const string expected = $"""
                                 project in (projectsWhereUserHasPermission("{Role}"))
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Project.Functions.WhereUserHasPermission(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WhereUserHasPermission_Static()
    {
        const string expected = $"""
                                 project in (projectsWhereUserHasPermission("{Role}"))
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(Functions.Project.WhereUserHasPermission(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WhereUserHasRole()
    {
        const string expected = $"""
                                 project in (projectsWhereUserHasRole("{Role}"))
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Project.Functions.WhereUserHasRole(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WhereUserHasRole_Static()
    {
        const string expected = $"""
                                 project in (projectsWhereUserHasRole("{Role}"))
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(Functions.Project.WhereUserHasRole(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}