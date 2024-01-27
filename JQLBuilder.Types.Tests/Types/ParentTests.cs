namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class ParentTests
{
    const string Parent = "ABC-123";
    const int ParentId = 123;

    [TestMethod]
    public void Should_Cast_Parent_Expression_From_String()
    {
        var expression = (JqlParent)Parent;

        Assert.AreEqual("Field", expression.Value.GetType().Name);
        Assert.AreEqual(new Field(Parent), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Parent_Expression_From_Int()
    {
        var expression = (JqlParent)ParentId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(ParentId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Parent_Field()
    {
        const string expected = FieldContestants.Parent;

        var field = Fields.All.Issue.Parent;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Parent} {Operators.Equals} {Parent} {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.Equals} {ParentId} {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.NotEquals} {Parent} {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.NotEquals} {ParentId} {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.Equals} {Parent} {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.Equals} {ParentId} {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.NotEquals} {Parent} {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.NotEquals} {ParentId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Parent == Parent)
            .And(f => f.Issue.Parent == ParentId)
            .And(f => f.Issue.Parent != Parent)
            .And(f => f.Issue.Parent != ParentId)
            .And(f => Parent == f.Issue.Parent)
            .And(f => ParentId == f.Issue.Parent)
            .And(f => Parent != f.Issue.Parent)
            .And(f => ParentId != f.Issue.Parent)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Parent} {Operators.In} ({ParentId}, {ParentId}, {ParentId}) {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.In} ({ParentId}, {ParentId}, {ParentId}) {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.In} ({ParentId}, {Parent}, {ParentId}) {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.In} ({ParentId}, {Parent}, {ParentId}) {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.NotIn} ({ParentId}, {ParentId}, {ParentId}) {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.NotIn} ({ParentId}, {ParentId}, {ParentId}) {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.NotIn} ({ParentId}, {Parent}, {ParentId}) {Keywords.And} " +
            $"{FieldContestants.Parent} {Operators.NotIn} ({ParentId}, {Parent}, {ParentId})";

        var homogeneousFilter = new JqlCollection<JqlParent> { ParentId, ParentId, ParentId };
        var heterogeneousFilter = new JqlCollection<JqlParent> { ParentId, Parent, ParentId };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Parent.In(ParentId, ParentId, ParentId))
            .And(f => f.Issue.Parent.In(homogeneousFilter))
            .And(f => f.Issue.Parent.In(ParentId, Parent, ParentId))
            .And(f => f.Issue.Parent.In(heterogeneousFilter))
            .And(f => f.Issue.Parent.NotIn(ParentId, ParentId, ParentId))
            .And(f => f.Issue.Parent.NotIn(homogeneousFilter))
            .And(f => f.Issue.Parent.NotIn(ParentId, Parent, ParentId))
            .And(f => f.Issue.Parent.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}