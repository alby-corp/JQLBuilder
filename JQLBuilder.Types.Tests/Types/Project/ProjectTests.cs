namespace JQLBuilder.Types.Tests.Types.Project;

using JqlTypes;

[TestClass]
public partial class ProjectTests
{
    const string Lead = "Me";
    const string Role = "User";
    const string ProjectName = "My Project";
    const int ProjectId = 123;

    [TestMethod]
    public void Should_Cast_Project_Expression_By_String()
    {
        var expression = (ProjectExpression)ProjectName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(ProjectName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Project_Expression_By_Int()
    {
        var expression = (ProjectExpression)ProjectId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(ProjectId, expression.Value);
    }
}