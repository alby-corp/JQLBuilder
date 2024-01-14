namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class TypeTests
{
    const string TypeName = "MyType";
    const int TypeId = 1;

    [TestMethod]
    public void Should_Cast_Type_Expression_By_String()
    {
        var expression = (TypeExpression)TypeName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(TypeName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Type_Expression_By_Int()
    {
        var expression = (ProjectExpression)TypeId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(TypeId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Type_Field()
    {
        const string expected = Constants.Fields.Type;

        var field = Fields.All.Type;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Issue_Type_Field()
    {
        const string expected = Constants.Fields.IssueType;

        var field = Fields.All.Type.Issue;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}