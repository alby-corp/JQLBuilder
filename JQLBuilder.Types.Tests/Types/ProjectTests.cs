namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class ProjectTests
{
    const string Lead = "Me";
    const string Role = "User";
    const string ProjectName = "My Project";
    const int ProjectId = 123;

    [TestMethod]
    public void Should_Cast_Version_Expression_By_String()
    {
        var expression = (ProjectExpression)ProjectName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(ProjectName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Version_Expression_By_Int()
    {
        var expression = (ProjectExpression)ProjectId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(ProjectId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Fix_Version_Field()
    {
        const string expected = Constants.Fields.Project;

        var field = Fields.All.Project;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}