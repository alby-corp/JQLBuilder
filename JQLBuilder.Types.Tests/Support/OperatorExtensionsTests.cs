namespace JQLBuilder.Types.Tests.Support;

using Abstract;
using Enum;
using Types.Support;

[TestClass]
public class NameExtensionsTests
{
    readonly MyJql left = new() { Value = DateTime.Now };
    readonly MyJql right = new() { Value = 1 };

    [TestMethod]
    public void EQUAL_TEST()
    {
        var actual = left.Equal(right);

        Assert.AreEqual(left, actual.Left);
        Assert.AreEqual(Constants.Equals, actual.Name);
        Assert.AreEqual(right, actual.Right);
        Assert.AreEqual(Priority.Equality, actual.Priority);
    }

    [TestMethod]
    public void NOT_EQUAL_TEST()
    {
        var actual = left.NotEqual(right);

        Assert.AreEqual(left, actual.Left);
        Assert.AreEqual(Constants.NotEquals, actual.Name);
        Assert.AreEqual(right, actual.Right);
        Assert.AreEqual(Priority.Equality, actual.Priority);
    }

    [TestMethod]
    public void GREATER_THAN_TEST()
    {
        var actual = left.GreaterThan(right);

        Assert.AreEqual(left, actual.Left);
        Assert.AreEqual(Constants.GreaterThan, actual.Name);
        Assert.AreEqual(right, actual.Right);
        Assert.AreEqual(Priority.Relation, actual.Priority);
    }

    [TestMethod]
    public void GREATER_THAN_OR_EQUAL_TEST()
    {
        var actual = left.GreaterThanOrEqual(right);

        Assert.AreEqual(left, actual.Left);
        Assert.AreEqual(Constants.GreaterThanOrEqual, actual.Name);
        Assert.AreEqual(right, actual.Right);
        Assert.AreEqual(Priority.Relation, actual.Priority);
    }

    [TestMethod]
    public void LESS_THAN_TEST()
    {
        var actual = left.LessThan(right);

        Assert.AreEqual(left, actual.Left);
        Assert.AreEqual(Constants.LessThan, actual.Name);
        Assert.AreEqual(right, actual.Right);
        Assert.AreEqual(Priority.Relation, actual.Priority);
    }

    [TestMethod]
    public void LESS_THAN_OR_EQUAL_TEST()
    {
        var actual = left.LessThanOrEqual(right);

        Assert.AreEqual(left, actual.Left);
        Assert.AreEqual(Constants.LessThanOrEqual, actual.Name);
        Assert.AreEqual(right, actual.Right);
        Assert.AreEqual(Priority.Relation, actual.Priority);
    }

    [TestMethod]
    public void AND_TEST()
    {
        var actual = left.And(right);

        Assert.AreEqual(left, actual.Left);
        Assert.AreEqual(Constants.And, actual.Name);
        Assert.AreEqual(right, actual.Right);
        Assert.AreEqual(Priority.LogicalAnd, actual.Priority);
    }

    [TestMethod]
    public void OR_TEST()
    {
        var actual = left.Or(right);

        Assert.AreEqual(left, actual.Left);
        Assert.AreEqual(Constants.Or, actual.Name);
        Assert.AreEqual(right, actual.Right);
        Assert.AreEqual(Priority.LogicalOr, actual.Priority);
    }

    [TestMethod]
    public void NOT_TEST() => throw new NotImplementedException();

    class MyJql : JqlValue;
}