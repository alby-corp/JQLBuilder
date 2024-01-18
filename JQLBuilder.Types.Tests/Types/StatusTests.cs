namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class StatusTests
{
    const string StatusName = "MyStatus";
    const int StatusId = 123;

    [TestMethod]
    public void Should_Cast_Status_Expression_By_String()
    {
        var expression = (VersionExpression)StatusName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(StatusName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Status_Expression_By_Int()
    {
        var expression = (VersionExpression)StatusId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(StatusId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Status()
    {
        const string expected = Constants.Fields.Status;

        var field = Fields.All.Status;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}