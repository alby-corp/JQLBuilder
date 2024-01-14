namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class ParentTests
{
    const string ParentName = "My Parent";
    const int ParentId = 123;

    [TestMethod]
    public void Should_Cast_Version_Expression_By_String()
    {
        var expression = (ParentExpression)ParentName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(ParentName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Version_Expression_By_Int()
    {
        var expression = (ParentExpression)ParentId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(ParentId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Fix_Parent_Field()
    {
        const string expected = Constants.Fields.Parent;

        var field = Fields.All.Parent;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}