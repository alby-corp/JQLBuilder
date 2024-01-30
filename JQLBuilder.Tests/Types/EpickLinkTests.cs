namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using FieldContestants = Constants.Fields;
using Fields = Fields;
using Functions = Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class EpicLinkTests
{
    const string EpicLink = "ABS-123";
    const int EpicLinkId = 123;
    const string EpicLinkField = $@"""{FieldContestants.EpicLink}""";

    [TestMethod]
    public void Should_Cast_EpicLink_Expression_From_String()
    {
        var expression = (JqlEpicLink)EpicLink;

        Assert.AreEqual("Issue", expression.Value.GetType().Name);
        Assert.AreEqual(new Issue(EpicLink), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_EpicLink_Expression_Form_Int()
    {
        var expression = (JqlEpicLink)EpicLinkId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(EpicLinkId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_EpicLink_Field()
    {
        var field = Fields.All.Issue.EpicLink;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(FieldContestants.EpicLink, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{EpicLinkField} {Operators.Equals} {EpicLink} {Keywords.And} " +
            $"{EpicLinkField} {Operators.Equals} {EpicLinkId} {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotEquals} {EpicLink} {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotEquals} {EpicLinkId} {Keywords.And} " +
            $"{EpicLinkField} {Operators.Equals} {EpicLink} {Keywords.And} " +
            $"{EpicLinkField} {Operators.Equals} {EpicLinkId} {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotEquals} {EpicLink} {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotEquals} {EpicLinkId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink == EpicLink)
            .And(f => f.Issue.EpicLink == EpicLinkId)
            .And(f => f.Issue.EpicLink != EpicLink)
            .And(f => f.Issue.EpicLink != EpicLinkId)
            .And(f => EpicLink == f.Issue.EpicLink)
            .And(f => EpicLinkId == f.Issue.EpicLink)
            .And(f => EpicLink != f.Issue.EpicLink)
            .And(f => EpicLinkId != f.Issue.EpicLink)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{EpicLinkField} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{EpicLinkField} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{EpicLinkField} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{EpicLinkField} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{EpicLinkField} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{EpicLinkField} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink.Is())
            .And(f => f.Issue.EpicLink.Is(s => s.Empty))
            .And(f => f.Issue.EpicLink.Is(s => s.Null))
            .And(f => f.Issue.EpicLink.IsNot())
            .And(f => f.Issue.EpicLink.IsNot(s => s.Empty))
            .And(f => f.Issue.EpicLink.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{EpicLinkField} {Operators.In} ({EpicLinkId}, {EpicLinkId}, {EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} ({EpicLinkId}, {EpicLinkId}, {EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} ({EpicLinkId}, {EpicLink}, {EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} ({EpicLinkId}, {EpicLink}, {EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} ({EpicLinkId}, {EpicLinkId}, {EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} ({EpicLinkId}, {EpicLinkId}, {EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} ({EpicLinkId}, {EpicLink}, {EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} ({EpicLinkId}, {EpicLink}, {EpicLinkId})";

        var homogeneousFilter = new JqlCollection<JqlEpicLink> { EpicLinkId, EpicLinkId, EpicLinkId };
        var heterogeneousFilter = new JqlCollection<JqlEpicLink> { EpicLinkId, EpicLink, EpicLinkId };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink.In(EpicLinkId, EpicLinkId, EpicLinkId))
            .And(f => f.Issue.EpicLink.In(homogeneousFilter))
            .And(f => f.Issue.EpicLink.In(EpicLinkId, EpicLink, EpicLinkId))
            .And(f => f.Issue.EpicLink.In(heterogeneousFilter))
            .And(f => f.Issue.EpicLink.NotIn(EpicLinkId, EpicLinkId, EpicLinkId))
            .And(f => f.Issue.EpicLink.NotIn(homogeneousFilter))
            .And(f => f.Issue.EpicLink.NotIn(EpicLinkId, EpicLink, EpicLinkId))
            .And(f => f.Issue.EpicLink.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
        [TestMethod]
    public void Should_Parses_VotedIssues_Function()
    {
        const string expected =
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.VotedIssues}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.VotedIssues}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.VotedIssues}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.VotedIssues}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink.In(f.Functions.Issues.Voted))
            .And(f => f.Issue.EpicLink.NotIn(f.Functions.Issues.Voted))
            .And(f => f.Issue.EpicLink.In(Functions.Issues.Voted))
            .And(f => f.Issue.EpicLink.NotIn(Functions.Issues.Voted))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WatchedIssues_Function()
    {
        const string expected =
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.WatchedIssues}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.WatchedIssues}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.WatchedIssues}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.WatchedIssues}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink.In(f.Functions.Issues.Watched))
            .And(f => f.Issue.EpicLink.NotIn(f.Functions.Issues.Watched))
            .And(f => f.Issue.EpicLink.In(Functions.Issues.Watched))
            .And(f => f.Issue.EpicLink.NotIn(Functions.Issues.Watched))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_IssueHistory_Function()
    {
        const string expected =
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.IssueHistory}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.IssueHistory}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.IssueHistory}() {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.IssueHistory}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink.In(f.Functions.Issues.History))
            .And(f => f.Issue.EpicLink.NotIn(f.Functions.Issues.History))
            .And(f => f.Issue.EpicLink.In(Functions.Issues.History))
            .And(f => f.Issue.EpicLink.NotIn(Functions.Issues.History))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_LinkedIssues_Function()
    {
        const string link = "is duplicated by";
        const string expectedLink = @"""is duplicated by""";

        var expected =
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.LinkedIssues}({EpicLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.LinkedIssues}({EpicLink}, {expectedLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({EpicLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({EpicLink}, {expectedLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.LinkedIssues}({EpicLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.LinkedIssues}({EpicLink}, {expectedLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({EpicLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({EpicLink}, {expectedLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.LinkedIssues}({EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.LinkedIssues}({EpicLinkId}, {expectedLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({EpicLinkId}, {expectedLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.LinkedIssues}({EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.In} {FunctionsConstants.LinkedIssues}({EpicLinkId}, {expectedLink}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({EpicLinkId}) {Keywords.And} " +
            $"{EpicLinkField} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({EpicLinkId}, {expectedLink})";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink.In(f.Functions.Issues.LinkedIssues(EpicLink)))
            .And(f => f.Issue.EpicLink.In(f.Functions.Issues.LinkedIssues(EpicLink, link)))
            .And(f => f.Issue.EpicLink.NotIn(f.Functions.Issues.LinkedIssues(EpicLink)))
            .And(f => f.Issue.EpicLink.NotIn(f.Functions.Issues.LinkedIssues(EpicLink, link)))
            .And(f => f.Issue.EpicLink.In(Functions.Issues.LinkedIssues(EpicLink)))
            .And(f => f.Issue.EpicLink.In(Functions.Issues.LinkedIssues(EpicLink, link)))
            .And(f => f.Issue.EpicLink.NotIn(Functions.Issues.LinkedIssues(EpicLink)))
            .And(f => f.Issue.EpicLink.NotIn(Functions.Issues.LinkedIssues(EpicLink, link)))
            .And(f => f.Issue.EpicLink.In(f.Functions.Issues.LinkedIssues(EpicLinkId)))
            .And(f => f.Issue.EpicLink.In(f.Functions.Issues.LinkedIssues(EpicLinkId, link)))
            .And(f => f.Issue.EpicLink.NotIn(f.Functions.Issues.LinkedIssues(EpicLinkId)))
            .And(f => f.Issue.EpicLink.NotIn(f.Functions.Issues.LinkedIssues(EpicLinkId, link)))
            .And(f => f.Issue.EpicLink.In(Functions.Issues.LinkedIssues(EpicLinkId)))
            .And(f => f.Issue.EpicLink.In(Functions.Issues.LinkedIssues(EpicLinkId, link)))
            .And(f => f.Issue.EpicLink.NotIn(Functions.Issues.LinkedIssues(EpicLinkId)))
            .And(f => f.Issue.EpicLink.NotIn(Functions.Issues.LinkedIssues(EpicLinkId, link)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}