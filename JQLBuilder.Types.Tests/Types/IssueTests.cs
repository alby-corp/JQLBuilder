namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class IssueTests
{
    const string IssueName = "MyIssue";

    [TestMethod]
    public void Should_Cast_Issue_Expression_By_String()
    {
        var expression = (IssueExpression)IssueName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(IssueName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Issue()
    {
        const string expected = Constants.Fields.Issue;

        var field = Fields.All.Issue;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Fix_IssueKey()
    {
        const string expected = Constants.Fields.IssueKey;

        var field = Fields.All.Issue.IssueKey;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Key()
    {
        const string expected = Constants.Fields.Id;

        var field = Fields.All.Issue.Id;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Fix_Id()
    {
        const string expected = Constants.Fields.Key;

        var field = Fields.All.Issue.Key;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}