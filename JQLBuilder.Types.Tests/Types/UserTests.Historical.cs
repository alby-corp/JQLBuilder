namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using Functions = JQLBuilder.Functions;

public partial class UserTests
{
    [TestMethod]
    public void Should_Parses_Equals_And_NotEquals_Expression_For_HistoricalUser()
    {
        const string expected = $"{Fields.Assignee} {Operators.Equals} {ExpectedUser} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.NotEquals} {ExpectedUser} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.Equals} {ExpectedUser} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.NotEquals} {ExpectedUser}";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Assignee == User)
            .And(f => f.User.Assignee != User)
            .And(f => User == f.User.Assignee)
            .And(f => User != f.User.Assignee)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_And_IsNot_Expressions_For_HistoricalUser()
    {
        const string expected = $"{Fields.Assignee} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.Is} {Keywords.Null} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Assignee.Is())
            .And(f => f.User.Assignee.Is(s => s.Empty))
            .And(f => f.User.Assignee.Is(s => s.Null))
            .And(f => f.User.Assignee.IsNot())
            .And(f => f.User.Assignee.IsNot(s => s.Empty))
            .And(f => f.User.Assignee.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_And_NotIn_Parameters_And_Collections_For_HistoricalUser()
    {
        const string expected = $"{Fields.Assignee} {Operators.In} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.In} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.NotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.NotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser})";

        var filter = new JqlCollection<HistoricalUserExpression>
        {
            User, User, User
        };

        var actual = JqlBuilder.Query
            .Where(f => f.User.Assignee.In(User, User, User))
            .And(f => f.User.Assignee.In(filter))
            .And(f => f.User.Assignee.NotIn(User, User, User))
            .And(f => f.User.Assignee.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Was_And_WasNot_For_HistoricalUser()
    {
        const string expected = $"{Fields.Assignee} {Operators.Was} {ExpectedUser} {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.WasNot} {ExpectedUser}";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Assignee.Was(User))
            .And(f => f.User.Assignee.WasNot(User))
            .ToString();

        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Should_Parses_WasIn_And_WasNotIn_Parameters_And_Collections_For_HistoricalUser()
    {
        const string expected = $"{Fields.Assignee} {Operators.WasIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.WasIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.WasNotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.WasNotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser})";

        var filter = new JqlCollection<HistoricalUserExpression>
        {
            User, User, User
        };

        var actual = JqlBuilder.Query
            .Where(f => f.User.Assignee.WasIn(User, User, User))
            .And(f => f.User.Assignee.WasIn(filter))
            .And(f => f.User.Assignee.WasNotIn(User, User, User))
            .And(f => f.User.Assignee.WasNotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields_For_HistoricalUser()
    {
        const string expected = $"{Keywords.OrderBy} " +
                                $"{Fields.Assignee} {Keywords.Ascending}, " +
                                $"{Fields.Watchers} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.User.Assignee)
            .ThenBy(f => f.User.Watchers)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_CurrentUser_Function_For_HistoricalUser()
    {
        const string expected = $"{Fields.Assignee} {Operators.Equals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.Equals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.NotEquals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Fields.Assignee} {Operators.NotEquals} {Constants.Functions.CurrentUser}()";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Assignee == f.Functions.User.CurrentUser())
            .And(f => f.User.Assignee == Functions.User.CurrentUser())
            .And(f => f.User.Assignee != f.Functions.User.CurrentUser())
            .And(f => f.User.Assignee != Functions.User.CurrentUser())
            .ToString();

        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Should_Parses_MemberOf_Function_For_HistoricalUser()
    {
        const string expected = $"""{Fields.Assignee} {Operators.In} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Fields.Assignee} {Operators.In} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Fields.Assignee} {Operators.In} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Fields.Assignee} {Operators.In} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Fields.Assignee} {Operators.NotIn} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Fields.Assignee} {Operators.NotIn} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Fields.Assignee} {Operators.NotIn} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Fields.Assignee} {Operators.NotIn} {Constants.Functions.MembersOf}("{SpacedGroup}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Assignee.In(f.Functions.User.MemberOf(Group)))
            .And(f => f.User.Assignee.In(f.Functions.User.MemberOf(SpacedGroup)))
            .And(f => f.User.Assignee.In(Functions.User.MemberOf(Group)))
            .And(f => f.User.Assignee.In(Functions.User.MemberOf(SpacedGroup)))
            .And(f => f.User.Assignee.NotIn(f.Functions.User.MemberOf(Group)))
            .And(f => f.User.Assignee.NotIn(f.Functions.User.MemberOf(SpacedGroup)))
            .And(f => f.User.Assignee.NotIn(Functions.User.MemberOf(Group)))
            .And(f => f.User.Assignee.NotIn(Functions.User.MemberOf(SpacedGroup)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}