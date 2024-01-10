namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Support;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

public partial class ProjectTests
{
    #region In

    [TestMethod]
    public void Should_Parses_In_ProjectLeadByUser()
    {
        var expected = $"{Fields.Project} {Operators.In} {FunctionsConstants.LeadByUser(Lead)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Project.Functions.LeadByUser(Lead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_ProjectLeadByUser_Static()
    {
        var expected = $"{Fields.Project} {Operators.In} {FunctionsConstants.LeadByUser(Lead)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(Functions.Project.LeadByUser(Lead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_WhereUserHasPermission()
    {
        var expected = $"{Fields.Project} {Operators.In} {FunctionsConstants.WhereUserHasPermission(Role)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Project.Functions.WhereUserHasPermission(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_WhereUserHasPermission_Static()
    {
        var expected = $"{Fields.Project} {Operators.In} {FunctionsConstants.WhereUserHasPermission(Role)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(Functions.Project.WhereUserHasPermission(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_WhereUserHasRole()
    {
        var expected = $"{Fields.Project} {Operators.In} {FunctionsConstants.WhereUserHasRole(Role)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Project.Functions.WhereUserHasRole(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_WhereUserHasRole_Static()
    {
        var expected = $"{Fields.Project} {Operators.In} {FunctionsConstants.WhereUserHasRole(Role)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(Functions.Project.WhereUserHasRole(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Not In

    [TestMethod]
    public void Should_Parses_NotIn_ProjectLeadByUser()
    {
        var expected = $"{Fields.Project} {Operators.NotIn} {FunctionsConstants.LeadByUser(Lead)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(f.Project.Functions.LeadByUser(Lead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_ProjectLeadByUser_Static()
    {
        var expected = $"{Fields.Project} {Operators.NotIn} {FunctionsConstants.LeadByUser(Lead)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(Functions.Project.LeadByUser(Lead)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_WhereUserHasPermission()
    {
        var expected = $"{Fields.Project} {Operators.NotIn} {FunctionsConstants.WhereUserHasPermission(Role)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(f.Project.Functions.WhereUserHasPermission(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_WhereUserHasPermission_Static()
    {
        var expected = $"{Fields.Project} {Operators.NotIn} {FunctionsConstants.WhereUserHasPermission(Role)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(Functions.Project.WhereUserHasPermission(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_WhereUserHasRole()
    {
        var expected = $"{Fields.Project} {Operators.NotIn} {FunctionsConstants.WhereUserHasRole(Role)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(f.Project.Functions.WhereUserHasRole(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_WhereUserHasRole_Static()
    {
        var expected = $"{Fields.Project} {Operators.NotIn} {FunctionsConstants.WhereUserHasRole(Role)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.NotIn(Functions.Project.WhereUserHasRole(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}