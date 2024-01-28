namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using JQLBuilder.Types.Support;
using Fields = Fields;
using FieldContestants = Constants.Fields;
using Functions = Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class HistoricalUserTests
{
    const string User = "Me";
    const int UserId = 123;
    const string Group = "QA";
    const string SpacedGroup = "Quality Analysts";
    const string ExpectedUser = $@"""{User}""";

    [TestMethod]
    public void Should_Parses_CustomField_HistoricalUser_From_Name()
    {
        const string customFieldName = "Reviewer";


        var field = Fields.All.User.Historical[customFieldName];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(customFieldName, actual);
    }

    [TestMethod]
    public void Should_Parses_CustomField_HistoricalUser_From_Id()
    {
        const int customFieldId = 10421;

        var field = Fields.All.User.Historical[customFieldId];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(FieldContestants.Custom(customFieldId), actual);
    }

    [TestMethod]
    public void Should_Cast_HistoricalUser_Expression_From_String()
    {
        var actual = (JqlHistoricalJqlUser)User;

        Assert.AreEqual("String", actual.Value.GetType().Name);
        Assert.AreEqual(User, actual.Value);
    }

    [TestMethod]
    public void Should_Cast_HistoricalUser_Expression_From_Int()
    {
        var actual = (JqlHistoricalJqlUser)UserId;

        Assert.AreEqual("Int32", actual.Value.GetType().Name);
        Assert.AreEqual(UserId, actual.Value);
    }

    [TestMethod]
    public void Should_Cast_Assignee()
    {
        const string expected = FieldContestants.Assignee;

        var field = Fields.All.User.Assignee;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Reporter()
    {
        const string expected = FieldContestants.Reporter;

        var field = Fields.All.User.Reporter;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Creator} {Operators.Equals} {ExpectedUser} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.Equals} {UserId} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotEquals} {ExpectedUser} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotEquals} {UserId} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.Equals} {ExpectedUser} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.Equals} {UserId} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotEquals} {ExpectedUser} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotEquals} {UserId}";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator == User)
            .And(f => f.User.Creator == UserId)
            .And(f => f.User.Creator != User)
            .And(f => f.User.Creator != UserId)
            .And(f => User == f.User.Creator)
            .And(f => UserId == f.User.Creator)
            .And(f => User != f.User.Creator)
            .And(f => UserId != f.User.Creator)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Creator} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator.Is())
            .And(f => f.User.Creator.Is(s => s.Empty))
            .And(f => f.User.Creator.Is(s => s.Null))
            .And(f => f.User.Creator.IsNot())
            .And(f => f.User.Creator.IsNot(s => s.Empty))
            .And(f => f.User.Creator.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Creator} {Operators.In} ({UserId}, {UserId}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.In} ({UserId}, {UserId}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.In} ({UserId}, {ExpectedUser}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.In} ({UserId}, {ExpectedUser}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotIn} ({UserId}, {UserId}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotIn} ({UserId}, {UserId}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotIn} ({UserId}, {ExpectedUser}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotIn} ({UserId}, {ExpectedUser}, {UserId})";

        var homogeneousFilter = new JqlCollection<JqlUser> { UserId, UserId, UserId };
        var heterogeneousFilter = new JqlCollection<JqlUser> { UserId, User, UserId };

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator.In(UserId, UserId, UserId))
            .And(f => f.User.Creator.In(homogeneousFilter))
            .And(f => f.User.Creator.In(UserId, User, UserId))
            .And(f => f.User.Creator.In(heterogeneousFilter))
            .And(f => f.User.Creator.NotIn(UserId, UserId, UserId))
            .And(f => f.User.Creator.NotIn(homogeneousFilter))
            .And(f => f.User.Creator.NotIn(UserId, User, UserId))
            .And(f => f.User.Creator.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields_For_User()
    {
        const string expected = $"{Keywords.OrderBy} " +
                                $"{FieldContestants.Creator} {Keywords.Ascending}, " +
                                $"{FieldContestants.Watcher} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.User.Creator)
            .ThenBy(f => f.User.Watcher)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Historical_Operators()
    {
        var expected =
            $"{FieldContestants.Assignee} {Operators.Was} {ExpectedUser} {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.Was} {UserId} {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNot} {ExpectedUser} {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNot} {UserId} {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasIn} ({ExpectedUser}, {UserId}, {ExpectedUser}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasIn} ({ExpectedUser}, {UserId}, {ExpectedUser}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNotIn} ({ExpectedUser}, {UserId}, {ExpectedUser}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNotIn} ({ExpectedUser}, {UserId}, {ExpectedUser})";

        var homogeneousFilter = new JqlCollection<JqlHistoricalJqlUser> { User, User, User };
        var heterogeneousFilter = new JqlCollection<JqlHistoricalJqlUser> { User, UserId, User };

        var actual = JqlBuilder.Query
            .Where(f => f.User.Assignee.Was(User))
            .And(f => f.User.Assignee.Was(UserId))
            .And(f => f.User.Assignee.WasNot(User))
            .And(f => f.User.Assignee.WasNot(UserId))
            .And(f => f.User.Assignee.WasIn(User, User, User))
            .And(f => f.User.Assignee.WasIn(homogeneousFilter))
            .And(f => f.User.Assignee.WasIn(User, UserId, User))
            .And(f => f.User.Assignee.WasIn(heterogeneousFilter))
            .And(f => f.User.Assignee.WasNotIn(User, User, User))
            .And(f => f.User.Assignee.WasNotIn(homogeneousFilter))
            .And(f => f.User.Assignee.WasNotIn(User, UserId, User))
            .And(f => f.User.Assignee.WasNotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_CurrentUser_Function()
    {
        const string expected = $"{FieldContestants.Creator} {Operators.Equals} {FunctionsConstants.CurrentUser}() {Keywords.And} " +
                                $"{FieldContestants.Creator} {Operators.Equals} {FunctionsConstants.CurrentUser}() {Keywords.And} " +
                                $"{FieldContestants.Creator} {Operators.NotEquals} {FunctionsConstants.CurrentUser}() {Keywords.And} " +
                                $"{FieldContestants.Creator} {Operators.NotEquals} {FunctionsConstants.CurrentUser}()";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator == f.Functions.User.CurrentUser())
            .And(f => f.User.Creator == Functions.User.CurrentUser())
            .And(f => f.User.Creator != f.Functions.User.CurrentUser())
            .And(f => f.User.Creator != Functions.User.CurrentUser())
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_MemberOf_Function()
    {
        const string expected = $"""{FieldContestants.Creator} {Operators.In} {FunctionsConstants.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{FieldContestants.Creator} {Operators.In} {FunctionsConstants.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{FieldContestants.Creator} {Operators.In} {FunctionsConstants.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{FieldContestants.Creator} {Operators.In} {FunctionsConstants.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{FieldContestants.Creator} {Operators.NotIn} {FunctionsConstants.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{FieldContestants.Creator} {Operators.NotIn} {FunctionsConstants.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{FieldContestants.Creator} {Operators.NotIn} {FunctionsConstants.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{FieldContestants.Creator} {Operators.NotIn} {FunctionsConstants.MembersOf}("{SpacedGroup}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator.In(f.Functions.User.MemberOf(Group)))
            .And(f => f.User.Creator.In(f.Functions.User.MemberOf(SpacedGroup)))
            .And(f => f.User.Creator.In(Functions.User.MemberOf(Group)))
            .And(f => f.User.Creator.In(Functions.User.MemberOf(SpacedGroup)))
            .And(f => f.User.Creator.NotIn(f.Functions.User.MemberOf(Group)))
            .And(f => f.User.Creator.NotIn(f.Functions.User.MemberOf(SpacedGroup)))
            .And(f => f.User.Creator.NotIn(Functions.User.MemberOf(Group)))
            .And(f => f.User.Creator.NotIn(Functions.User.MemberOf(SpacedGroup)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}