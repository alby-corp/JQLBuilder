namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Support;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

public partial class IssueTests
{
    #region In NotIn

    [TestMethod]
    public void Should_Parses_In_VotedIssues()
    {
        const string expected = $"{Fields.Id} {Operators.In} {FunctionsConstants.VotedIssues}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(f.Issue.Functions.Voted))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_WatchedIssues()
    {
        const string expected = $"{Fields.Id} {Operators.In} {FunctionsConstants.WatchedIssues}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(f.Issue.Functions.Watched))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_History()
    {
        const string expected = $"{Fields.Id} {Operators.In} {FunctionsConstants.History}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(f.Issue.Functions.History))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Linked()
    {
        var expected = $"{Fields.Id} {Operators.In} {FunctionsConstants.Linked(IssueName)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(f.Issue.Functions.Linked(IssueName)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Linked_With_Link_Type()
    {
        const string linkType = "is duplicated by";
        
        var expected = $"{Fields.Id} {Operators.NotIn} {FunctionsConstants.Linked(IssueName, linkType)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.NotIn(f.Issue.Functions.Linked(IssueName, linkType)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
    
    #region In NotIn Static

    [TestMethod]
    public void Should_Parses_In_VotedIssues_Static()
    {
        const string expected = $"{Fields.Id} {Operators.In} {FunctionsConstants.VotedIssues}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(Functions.Issues.Voted))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_WatchedIssues_Static()
    {
        const string expected = $"{Fields.Id} {Operators.In} {FunctionsConstants.WatchedIssues}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(Functions.Issues.Watched))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_History_Static()
    {
        const string expected = $"{Fields.Id} {Operators.In} {FunctionsConstants.History}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(Functions.Issues.History))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Linked_Static()
    {
        var expected = $"{Fields.Id} {Operators.In} {FunctionsConstants.Linked(IssueName)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(Functions.Issues.Linked(IssueName)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Linked_With_Link_Type_Static()
    {
        const string linkType = "is duplicated by";
        
        var expected = $"{Fields.Id} {Operators.NotIn} {FunctionsConstants.Linked(IssueName, linkType)}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.NotIn(Functions.Issues.Linked(IssueName, linkType)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}