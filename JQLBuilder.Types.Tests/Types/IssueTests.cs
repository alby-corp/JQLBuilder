namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using Fields = Fields;
using FieldContestants = Constants.Fields;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class IssueTests
{
    const string Issue = "ABC-123";
    const int IssueId = 123;

    [TestMethod]
    public void Should_Cast_Issue_Expression_From_String()
    {
        var expression = (IssueExpression)Issue;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(Issue, expression.Value);
    }
    
    [TestMethod]
    public void Should_Cast_Issue_Expression_From_Int()
    {
        var expression = (IssueExpression)IssueId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(IssueId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Issue_Field()
    {
        const string expected = FieldContestants.Issue;

        var field = Fields.All.Issue;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_IssueKey_Field()
    {
        const string expected = FieldContestants.IssueKey;

        var field = Fields.All.Issue.IssueKey;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Id_Field()
    {
        const string expected = FieldContestants.Id;

        var field = Fields.All.Issue.Id;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Key_Field()
    {
        const string expected = FieldContestants.Key;

        var field = Fields.All.Issue.Key;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected = $"{FieldContestants.Issue} {Operators.Equals} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.Equals} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.NotEquals} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.NotEquals} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.GreaterThanOrEqual} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.GreaterThanOrEqual} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.GreaterThan} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.GreaterThan} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.LessThanOrEqual} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.LessThanOrEqual} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.LessThan} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.LessThan} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.Equals} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.Equals} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.NotEquals} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.NotEquals} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.LessThanOrEqual} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.LessThanOrEqual} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.LessThan} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.LessThan} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.GreaterThanOrEqual} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.GreaterThanOrEqual} {IssueId} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.GreaterThan} {Issue} {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.GreaterThan} {IssueId}";


        var actual = JqlBuilder.Query
            .Where(f => f.Issue == Issue)
            .And(f => f.Issue == IssueId)
            .And(f => f.Issue != Issue)
            .And(f => f.Issue != IssueId)
            .And(f => f.Issue >= Issue)
            .And(f => f.Issue >= IssueId)
            .And(f => f.Issue > Issue)
            .And(f => f.Issue > IssueId)
            .And(f => f.Issue <= Issue)
            .And(f => f.Issue <= IssueId)
            .And(f => f.Issue < Issue)
            .And(f => f.Issue < IssueId)
            .And(f => Issue == f.Issue)
            .And(f => IssueId == f.Issue)
            .And(f => Issue != f.Issue)
            .And(f => IssueId != f.Issue)
            .And(f => Issue >= f.Issue)
            .And(f => IssueId >= f.Issue)
            .And(f => Issue > f.Issue)
            .And(f => IssueId > f.Issue)
            .And(f => Issue <= f.Issue)
            .And(f => IssueId <= f.Issue)
            .And(f => Issue < f.Issue)
            .And(f => IssueId < f.Issue)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected = $"{FieldContestants.Issue} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{FieldContestants.Issue} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{FieldContestants.Issue} {Operators.Is} {Keywords.Null} {Keywords.And} " +
                                $"{FieldContestants.Issue} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{FieldContestants.Issue} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{FieldContestants.Issue} {Operators.IsNot} {Keywords.Null}";
        
        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Is())
            .And(f => f.Issue.Is(s => s.Empty))
            .And (f => f.Issue.Is(s => s.Null))
            .And(f => f.Issue.IsNot())
            .And(f => f.Issue.IsNot(s => s.Empty))
            .And(f => f.Issue.IsNot(s => s.Null))
            .ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected = $"{FieldContestants.Issue} {Operators.In} ({IssueId}, {IssueId}, {IssueId}) {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.In} ({IssueId}, {IssueId}, {IssueId}) {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.In} ({IssueId}, {Issue}, {IssueId}) {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.In} ({IssueId}, {Issue}, {IssueId}) {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.NotIn} ({IssueId}, {IssueId}, {IssueId}) {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.NotIn} ({IssueId}, {IssueId}, {IssueId}) {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.NotIn} ({IssueId}, {Issue}, {IssueId}) {Keywords.And} " +
                       $"{FieldContestants.Issue} {Operators.NotIn} ({IssueId}, {Issue}, {IssueId})";
        
        var homogeneousFilter = new JqlCollection<IssueExpression> { IssueId, IssueId, IssueId };
        var heterogeneousFilter = new JqlCollection<IssueExpression> { IssueId, Issue, IssueId };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.In(IssueId, IssueId, IssueId))
            .And(f => f.Issue.In(homogeneousFilter))
            .And(f => f.Issue.In(IssueId, Issue, IssueId))
            .And(f => f.Issue.In(heterogeneousFilter))
            .And(f => f.Issue.NotIn(IssueId, IssueId, IssueId))
            .And(f => f.Issue.NotIn(homogeneousFilter))
            .And(f => f.Issue.NotIn(IssueId, Issue, IssueId))
            .And(f => f.Issue.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} {FieldContestants.Issue} {Keywords.Ascending}, " +
                                $"{FieldContestants.IssueKey} {Keywords.Ascending}, " +
                                $"{FieldContestants.Key} {Keywords.Ascending}, " +
                                $"{FieldContestants.Id} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Issue)
            .ThenBy(f => f.Issue.IssueKey)
            .ThenBy(f => f.Issue.Key)
            .ThenBy(f => f.Issue.Id)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_VotedIssues_Functions()
    {
        const string expected = $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.VotedIssues}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.VotedIssues}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.VotedIssues}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.VotedIssues}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(f.Functions.Issues.Voted))
            .And(f => f.Issue.Id.NotIn(f.Functions.Issues.Voted))
            .And(f => f.Issue.Id.In(Functions.Issues.Voted))
            .And(f => f.Issue.Id.NotIn(Functions.Issues.Voted))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_WatchedIssues_Functions()
    {
        const string expected = $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.WatchedIssues}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.WatchedIssues}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.WatchedIssues}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.WatchedIssues}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(f.Functions.Issues.Watched))
            .And(f => f.Issue.Id.NotIn(f.Functions.Issues.Watched))
            .And(f => f.Issue.Id.In(Functions.Issues.Watched))
            .And(f => f.Issue.Id.NotIn(Functions.Issues.Watched))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_IssueHistory_Functions()
    {
        const string expected = $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.IssueHistory}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.IssueHistory}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.IssueHistory}() {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.IssueHistory}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(f.Functions.Issues.History))
            .And(f => f.Issue.Id.NotIn(f.Functions.Issues.History))
            .And(f => f.Issue.Id.In(Functions.Issues.History))
            .And(f => f.Issue.Id.NotIn(Functions.Issues.History))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_LinkedIssues_Functions()
    {
        const string link = "is duplicated by";
        const string expectedLink = @"""is duplicated by""";

        var expected = $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.LinkedIssues}({Issue}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.LinkedIssues}({Issue}, {expectedLink}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({Issue}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({Issue}, {expectedLink}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.LinkedIssues}({Issue}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.LinkedIssues}({Issue}, {expectedLink}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({Issue}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({Issue}, {expectedLink}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.LinkedIssues}({IssueId}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.LinkedIssues}({IssueId}, {expectedLink}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({IssueId}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({IssueId}, {expectedLink}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.LinkedIssues}({IssueId}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.In} {FunctionsConstants.LinkedIssues}({IssueId}, {expectedLink}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({IssueId}) {Keywords.And} " +
                                $"{FieldContestants.Id} {Operators.NotIn} {FunctionsConstants.LinkedIssues}({IssueId}, {expectedLink})";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Id.In(f.Functions.Issues.LinkedIssues(Issue)))
            .And(f => f.Issue.Id.In(f.Functions.Issues.LinkedIssues(Issue, link))) 
            .And(f => f.Issue.Id.NotIn(f.Functions.Issues.LinkedIssues(Issue)))
            .And(f => f.Issue.Id.NotIn(f.Functions.Issues.LinkedIssues(Issue, link)))
            .And(f => f.Issue.Id.In(Functions.Issues.LinkedIssues(Issue)))
            .And(f => f.Issue.Id.In(Functions.Issues.LinkedIssues(Issue, link)))
            .And(f => f.Issue.Id.NotIn(Functions.Issues.LinkedIssues(Issue)))
            .And(f => f.Issue.Id.NotIn(Functions.Issues.LinkedIssues(Issue, link)))
            .And(f => f.Issue.Id.In(f.Functions.Issues.LinkedIssues(IssueId)))
            .And(f => f.Issue.Id.In(f.Functions.Issues.LinkedIssues(IssueId, link))) 
            .And(f => f.Issue.Id.NotIn(f.Functions.Issues.LinkedIssues(IssueId)))
            .And(f => f.Issue.Id.NotIn(f.Functions.Issues.LinkedIssues(IssueId, link)))
            .And(f => f.Issue.Id.In(Functions.Issues.LinkedIssues(IssueId)))
            .And(f => f.Issue.Id.In(Functions.Issues.LinkedIssues(IssueId, link)))
            .And(f => f.Issue.Id.NotIn(Functions.Issues.LinkedIssues(IssueId)))
            .And(f => f.Issue.Id.NotIn(Functions.Issues.LinkedIssues(IssueId, link)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}