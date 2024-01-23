﻿namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using FieldContestants = Constants.Fields;
using Fields = Fields;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

public class HistoricalUserTests
{
    const string User = "Me";
    const string ExpectedUser = @"""Me""";
    const int UserId = 123;
    const string Group = "QA";
    const string SpacedGroup = "Quality Analysts";

    [TestMethod]
    public void Should_Cast_HistoricalUser_Expression_From_String()
    {
        var actual = (HistoricalUserExpression)User;

        Assert.AreEqual("String", actual.Value.GetType().Name);
        Assert.AreEqual(User, actual.Value);
    }

    [TestMethod]
    public void Should_Cast_HistoricalUser_Expression_From_Int()
    {
        var actual = (HistoricalUserExpression)UserId;

        Assert.AreEqual("Int31", actual.Value.GetType().Name);
        Assert.AreEqual(User, actual.Value);
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
            $"{FieldContestants.Creator} {Operators.Equals} {User} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.Equals} {UserId} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotEquals} {User} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotEquals} {UserId} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.Equals} {User} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.Equals} {UserId} {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotEquals} {User} {Keywords.And} " +
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
            $"{FieldContestants.Creator} {Operators.In} ({UserId}, {User}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.In} ({UserId}, {User}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotIn} ({UserId}, {UserId}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotIn} ({UserId}, {UserId}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotIn} ({UserId}, {User}, {UserId}) {Keywords.And} " +
            $"{FieldContestants.Creator} {Operators.NotIn} ({UserId}, {User}, {UserId})";

        var homogeneousFilter = new JqlCollection<UserExpression> { UserId, UserId, UserId };
        var heterogeneousFilter = new JqlCollection<UserExpression> { UserId, User, UserId };

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
            $"{FieldContestants.Assignee} {Operators.Was} {User} {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.Was} {UserId} {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNot} {User} {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNot} {UserId} {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasIn} ({User}, {User}, {User}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasIn} ({User}, {User}, {User}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasIn} ({User}, {UserId}, {User}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasIn} ({User}, {UserId}, {User}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNotIn} ({User}, {User}, {User}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNotIn} ({User}, {User}, {User}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNotIn} ({User}, {UserId}, {User}) {Keywords.And} " +
            $"{FieldContestants.Assignee} {Operators.WasNotIn} ({User}, {UserId}, {User})";

        var homogeneousFilter = new JqlCollection<HistoricalUserExpression> { User, User, User };
        var heterogeneousFilter = new JqlCollection<HistoricalUserExpression> { User, UserId, User };

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