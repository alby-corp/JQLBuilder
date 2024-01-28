namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using FieldContestants = Constants.Fields;
using Fields = Fields;
using Functions = Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class ProjectTests
{
    const string Lead = "Me";
    const string Role = "User";
    const string Project = "ABS";
    const int ProjectId = 123;

    [TestMethod]
    public void Should_Cast_Project_Expression_From_String()
    {
        var expression = (JqlProject)Project;

        Assert.AreEqual("Field", expression.Value.GetType().Name);
        Assert.AreEqual(new Field(Project), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Project_Expression_Form_Int()
    {
        var expression = (JqlProject)ProjectId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(ProjectId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Project_Field()
    {
        const string expected = FieldContestants.Project;

        var field = Fields.All.Project;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Project} {Operators.Equals} {Project} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.Equals} {ProjectId} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.NotEquals} {Project} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.NotEquals} {ProjectId} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.Equals} {Project} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.Equals} {ProjectId} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.NotEquals} {Project} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.NotEquals} {ProjectId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project == Project)
            .And(f => f.Project == ProjectId)
            .And(f => f.Project != Project)
            .And(f => f.Project != ProjectId)
            .And(f => Project == f.Project)
            .And(f => ProjectId == f.Project)
            .And(f => Project != f.Project)
            .And(f => ProjectId != f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Project} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Is())
            .And(f => f.Project.Is(s => s.Empty))
            .And(f => f.Project.Is(s => s.Null))
            .And(f => f.Project.IsNot())
            .And(f => f.Project.IsNot(s => s.Empty))
            .And(f => f.Project.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Project} {Operators.In} ({ProjectId}, {ProjectId}, {ProjectId}) {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.In} ({ProjectId}, {ProjectId}, {ProjectId}) {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.In} ({ProjectId}, {Project}, {ProjectId}) {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.In} ({ProjectId}, {Project}, {ProjectId}) {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.NotIn} ({ProjectId}, {ProjectId}, {ProjectId}) {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.NotIn} ({ProjectId}, {ProjectId}, {ProjectId}) {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.NotIn} ({ProjectId}, {Project}, {ProjectId}) {Keywords.And} " +
            $"{FieldContestants.Project} {Operators.NotIn} ({ProjectId}, {Project}, {ProjectId})";

        var homogeneousFilter = new JqlCollection<JqlProject> { ProjectId, ProjectId, ProjectId };
        var heterogeneousFilter = new JqlCollection<JqlProject> { ProjectId, Project, ProjectId };

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(ProjectId, ProjectId, ProjectId))
            .And(f => f.Project.In(homogeneousFilter))
            .And(f => f.Project.In(ProjectId, Project, ProjectId))
            .And(f => f.Project.In(heterogeneousFilter))
            .And(f => f.Project.NotIn(ProjectId, ProjectId, ProjectId))
            .And(f => f.Project.NotIn(homogeneousFilter))
            .And(f => f.Project.NotIn(ProjectId, Project, ProjectId))
            .And(f => f.Project.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} {FieldContestants.Project} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_ProjectsLeadByUser_Function()
    {
        const string expected =
            $"""{FieldContestants.Project} {Operators.In} {FunctionsConstants.ProjectsLeadByUser}("{Lead}") {Keywords.And} """ +
            $"{FieldContestants.Project} {Operators.In} {FunctionsConstants.ProjectsLeadByUser}() {Keywords.And} " +
            $"""{FieldContestants.Project} {Operators.NotIn} {FunctionsConstants.ProjectsLeadByUser}("{Lead}") {Keywords.And} """ +
            $"{FieldContestants.Project} {Operators.NotIn} {FunctionsConstants.ProjectsLeadByUser}() {Keywords.And} " +
            $"""{FieldContestants.Project} {Operators.In} {FunctionsConstants.ProjectsLeadByUser}("{Lead}") {Keywords.And} """ +
            $"{FieldContestants.Project} {Operators.In} {FunctionsConstants.ProjectsLeadByUser}() {Keywords.And} " +
            $"""{FieldContestants.Project} {Operators.NotIn} {FunctionsConstants.ProjectsLeadByUser}("{Lead}") {Keywords.And} """ +
            $"{FieldContestants.Project} {Operators.NotIn} {FunctionsConstants.ProjectsLeadByUser}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Functions.Project.LeadByUser(Lead)))
            .And(f => f.Project.In(f.Functions.Project.LeadByUser()))
            .And(f => f.Project.NotIn(f.Functions.Project.LeadByUser(Lead)))
            .And(f => f.Project.NotIn(f.Functions.Project.LeadByUser()))
            .And(f => f.Project.In(Functions.Project.LeadByUser(Lead)))
            .And(f => f.Project.In(Functions.Project.LeadByUser()))
            .And(f => f.Project.NotIn(Functions.Project.LeadByUser(Lead)))
            .And(f => f.Project.NotIn(Functions.Project.LeadByUser()))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_ProjectsWhereUserHasPermission_Function()
    {
        const string expected =
            $"""{FieldContestants.Project} {Operators.In} {FunctionsConstants.WhereUserHasPermission}("{Role}") {Keywords.And} """ +
            $"""{FieldContestants.Project} {Operators.NotIn} {FunctionsConstants.WhereUserHasPermission}("{Role}") {Keywords.And} """ +
            $"""{FieldContestants.Project} {Operators.In} {FunctionsConstants.WhereUserHasPermission}("{Role}") {Keywords.And} """ +
            $"""{FieldContestants.Project} {Operators.NotIn} {FunctionsConstants.WhereUserHasPermission}("{Role}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Functions.Project.WhereUserHasPermission(Role)))
            .And(f => f.Project.NotIn(f.Functions.Project.WhereUserHasPermission(Role)))
            .And(f => f.Project.In(Functions.Project.WhereUserHasPermission(Role)))
            .And(f => f.Project.NotIn(Functions.Project.WhereUserHasPermission(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_ProjectsWhereUserHasRole_Function()
    {
        const string expected =
            $"""{FieldContestants.Project} {Operators.In} {FunctionsConstants.WhereUserHasRole}("{Role}") {Keywords.And} """ +
            $"""{FieldContestants.Project} {Operators.NotIn} {FunctionsConstants.WhereUserHasRole}("{Role}") {Keywords.And} """ +
            $"""{FieldContestants.Project} {Operators.In} {FunctionsConstants.WhereUserHasRole}("{Role}") {Keywords.And} """ +
            $"""{FieldContestants.Project} {Operators.NotIn} {FunctionsConstants.WhereUserHasRole}("{Role}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.In(f.Functions.Project.WhereUserHasRole(Role)))
            .And(f => f.Project.NotIn(f.Functions.Project.WhereUserHasRole(Role)))
            .And(f => f.Project.In(Functions.Project.WhereUserHasRole(Role)))
            .And(f => f.Project.NotIn(Functions.Project.WhereUserHasRole(Role)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}