namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using FieldContestants = Constants.Fields;
using Fields = Fields;

[TestClass]
public class ProjectTypeTests
{
    const string ProjectType = "software";
    const string ExpectedProjectType = $@"""{ProjectType}""";
    
       [TestMethod]
    public void Should_Cast_Project_Expression_From_String()
    {
        var expression = (JqlProjectType)ProjectType;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(ProjectType, expression.Value);
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
            $"{FieldContestants.ProjectType} {Operators.Equals} {ExpectedProjectType} {Keywords.And} " +
            $"{FieldContestants.ProjectType} {Operators.NotEquals} {ExpectedProjectType} {Keywords.And} " +
            $"{FieldContestants.ProjectType} {Operators.Equals} {ExpectedProjectType} {Keywords.And} " +
            $"{FieldContestants.ProjectType} {Operators.NotEquals} {ExpectedProjectType}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Type == ProjectType)
            .And(f => f.Project.Type != ProjectType)
            .And(f => ProjectType == f.Project.Type)
            .And(f => ProjectType != f.Project.Type)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.ProjectType} {Operators.In} ({ExpectedProjectType}, {ExpectedProjectType}, {ExpectedProjectType}) {Keywords.And} " +
            $"{FieldContestants.ProjectType} {Operators.In} ({ExpectedProjectType}, {ExpectedProjectType}, {ExpectedProjectType}) {Keywords.And} " +
            $"{FieldContestants.ProjectType} {Operators.NotIn} ({ExpectedProjectType}, {ExpectedProjectType}, {ExpectedProjectType}) {Keywords.And} " +
            $"{FieldContestants.ProjectType} {Operators.NotIn} ({ExpectedProjectType}, {ExpectedProjectType}, {ExpectedProjectType})";

        var homogeneousFilter = new JqlCollection<JqlProjectType> { ProjectType, ProjectType, ProjectType };

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Type.In(ProjectType, ProjectType, ProjectType))
            .And(f => f.Project.Type.In(homogeneousFilter))
            .And(f => f.Project.Type.NotIn(ProjectType, ProjectType, ProjectType))
            .And(f => f.Project.Type.NotIn(homogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}