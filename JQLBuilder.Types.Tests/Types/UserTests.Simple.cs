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
    public void Should_Parses_Equals_And_NotEquals_Expression_For_User()
    {
        const string expected = $"{Fields.Creator} {Operators.Equals} {ExpectedUser} {Keywords.And} " +
                                $"{Fields.Creator} {Operators.NotEquals} {ExpectedUser} {Keywords.And} " +
                                $"{Fields.Creator} {Operators.Equals} {ExpectedUser} {Keywords.And} " +
                                $"{Fields.Creator} {Operators.NotEquals} {ExpectedUser}";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator == User)
            .And(f => f.User.Creator != User)
            .And(f => User == f.User.Creator)
            .And(f => User != f.User.Creator)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Is_And_IsNot_Expressions_For_User()
    {
        const string expected = $"{Fields.Creator} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{Fields.Creator} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{Fields.Creator} {Operators.Is} {Keywords.Null} {Keywords.And} " +
                                $"{Fields.Creator} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{Fields.Creator} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{Fields.Creator} {Operators.IsNot} {Keywords.Null}";
        
        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator.Is())
            .And(f => f.User.Creator.Is(s => s.Empty))
            .And (f => f.User.Creator.Is(s => s.Null))
            .And(f => f.User.Creator.IsNot())
            .And(f => f.User.Creator.IsNot(s => s.Empty))
            .And(f => f.User.Creator.IsNot(s => s.Null))
            .ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_In_And_NotIn_Parameters_And_Collections_For_User()
    {
        const string expected = $"{Fields.Creator} {Operators.In} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Creator} {Operators.In} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Creator} {Operators.NotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Fields.Creator} {Operators.NotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser})";
        
        var filter = new JqlCollection<HistoricalUserExpression>
        {
            User, User, User
        };

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator.In(User, User, User))
            .And(f => f.User.Creator.In(filter))
            .And(f => f.User.Creator.NotIn(User, User, User))
            .And(f => f.User.Creator.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Ordering_Fields_For_User()
    {
        const string expected = $"{Keywords.OrderBy} " +
                                $"{Fields.Creator} {Keywords.Ascending}, " +
                                $"{Fields.Watchers} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.User.Creator)
            .ThenBy(f => f.User.Watchers)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_CurrentUser_Function_For_User()
    {
        const string expected = $"{Fields.Creator} {Operators.Equals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Fields.Creator} {Operators.Equals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Fields.Creator} {Operators.NotEquals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Fields.Creator} {Operators.NotEquals} {Constants.Functions.CurrentUser}()";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator == f.Functions.User.CurrentUser())
            .And(f => f.User.Creator == Functions.User.CurrentUser())
            .And(f => f.User.Creator != f.Functions.User.CurrentUser())
            .And(f => f.User.Creator != Functions.User.CurrentUser())
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    
    
    [TestMethod]
    public void Should_Parses_MemberOf_Function_For_User()
    {
        const string expected = $"""{Fields.Creator} {Operators.In} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Fields.Creator} {Operators.In} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Fields.Creator} {Operators.In} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Fields.Creator} {Operators.In} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Fields.Creator} {Operators.NotIn} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Fields.Creator} {Operators.NotIn} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Fields.Creator} {Operators.NotIn} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Fields.Creator} {Operators.NotIn} {Constants.Functions.MembersOf}("{SpacedGroup}")""";

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