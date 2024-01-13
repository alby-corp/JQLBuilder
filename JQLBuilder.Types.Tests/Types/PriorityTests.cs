namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class PriorityTests
{
    const string PriorityName = "MyVersion";
    const int PriorityId = 123;

    [TestMethod]
    public void Should_Cast_Priority_Expression_By_String()
    {
        var expression = (VersionExpression)PriorityName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(PriorityName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Priority_Expression_By_Int()
    {
        var expression = (VersionExpression)PriorityId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(PriorityId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Priority()
    {
        const string expected = Constants.Fields.Priority;

        var field = Fields.All.Priority;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}