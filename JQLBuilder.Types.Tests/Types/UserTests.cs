namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using Fields = Fields;
using Functions = JQLBuilder.Functions;

[TestClass]
public partial class UserTests
{
    const string User = "Me";
    const string ExpectedUser = @"""Me""";
    const string Group = "QA";
    const string SpacedGroup = "Quality Analysts";

    [TestMethod]
    public void Should_Cast_Version_Expression_By_String()
    {
        var actual = (UserExpression)User;

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
    public void Should_Parses_Equals_And_Not_Equals_Expression()
    {
        const string expected = $"{Constants.Fields.Creator} {Operators.Equals} {ExpectedUser} {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.NotEquals} {ExpectedUser} {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.Equals} {ExpectedUser} {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.NotEquals} {ExpectedUser}";

        var actual = JqlBuilder.Query
            .Where(f => f.User.Creator == User)
            .And(f => f.User.Creator != User)
            .And(f => User == f.User.Creator)
            .And(f => User != f.User.Creator)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Empty_Null_And_NotEmpty_NotNull_Expressions()
    {
        const string expected = $"{Constants.Fields.Creator} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.Is} {Keywords.Null} {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.IsNot} {Keywords.Null}";
        
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
    public void Should_Parses_In_Parameters_And_Collections()
    {
        const string expected = $"{Constants.Fields.Creator} {Operators.In} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.In} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.NotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser}) {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.NotIn} ({ExpectedUser}, {ExpectedUser}, {ExpectedUser})";
        
        var filter = new JqlCollection<UserExpression>
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
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} " +
                                $"{Constants.Fields.Creator} {Keywords.Ascending}, " +
                                $"{Constants.Fields.Watchers} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.User.Creator)
            .ThenBy(f => f.User.Watchers)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_CurrentUser_Function()
    {
        const string expected = $"{Constants.Fields.Creator} {Operators.Equals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.Equals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.NotEquals} {Constants.Functions.CurrentUser}() {Keywords.And} " +
                                $"{Constants.Fields.Creator} {Operators.NotEquals} {Constants.Functions.CurrentUser}()";

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
        const string expected = $"""{Constants.Fields.Creator} {Operators.In} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Constants.Fields.Creator} {Operators.In} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Constants.Fields.Creator} {Operators.In} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Constants.Fields.Creator} {Operators.In} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Constants.Fields.Creator} {Operators.NotIn} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Constants.Fields.Creator} {Operators.NotIn} {Constants.Functions.MembersOf}("{SpacedGroup}") {Keywords.And} """ +
                                $"""{Constants.Fields.Creator} {Operators.NotIn} {Constants.Functions.MembersOf}("{Group}") {Keywords.And} """ +
                                $"""{Constants.Fields.Creator} {Operators.NotIn} {Constants.Functions.MembersOf}("{SpacedGroup}")""";

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