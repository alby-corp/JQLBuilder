namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;
using Fields = Fields;

[TestClass]
public partial class UserTests
{
    const string User = "Me";
    const string ExpectedUser = @"""Me""";
    const string Group = "QA";
    const string SpacedGroup = "Quality Analysts";

    [TestMethod]
    public void Should_Cast_User_Expression()
    {
        var actual = (UserExpression)User;

        Assert.AreEqual("String", actual.Value.GetType().Name);
        Assert.AreEqual(User, actual.Value);
    }

    [TestMethod]
    public void Should_Cast_HistoricalUser_Expression_By_String()
    {
        var actual = (HistoricalUserExpression)User;

        Assert.AreEqual("String", actual.Value.GetType().Name);
        Assert.AreEqual(User, actual.Value);
    }

    [TestMethod]
    public void Should_Cast_Creator()
    {
        const string expected = Constants.Fields.Creator;

        var field = Fields.All.User.Creator;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Voter()
    {
        const string expected = Constants.Fields.Voter;

        var field = Fields.All.User.Voter;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Watcher()
    {
        const string expected = Constants.Fields.Watchers;

        var field = Fields.All.User.Watcher;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Assignee()
    {
        const string expected = Constants.Fields.Assignee;

        var field = Fields.All.User.Assignee;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Reporter()
    {
        const string expected = Constants.Fields.Reporter;

        var field = Fields.All.User.Reporter;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}