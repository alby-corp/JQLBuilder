namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class IssueTypeTests
{
    const string Type = "Enanchement";
    const int TypeId = 1;

    [TestMethod]
    public void Should_Cast_Type_Expression_From_String()
    {
        var expression = (JqlType)Type;

        Assert.AreEqual("Field", expression.Value.GetType().Name);
        Assert.AreEqual(new Field(Type), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Type_Expression_From_Int()
    {
        var expression = (JqlProject)TypeId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(TypeId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Type_Field()
    {
        const string expected = FieldContestants.Type;

        var field = Fields.All.Issue.Type;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_TypeType_Field()
    {
        const string expected = FieldContestants.IssueType;

        var field = Fields.All.Issue.IssueType;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.IssueType} {Operators.Equals} {Type} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.Equals} {TypeId} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.NotEquals} {Type} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.NotEquals} {TypeId} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.Equals} {Type} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.Equals} {TypeId} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.NotEquals} {Type} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.NotEquals} {TypeId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.IssueType == Type)
            .And(f => f.Issue.IssueType == TypeId)
            .And(f => f.Issue.IssueType != Type)
            .And(f => f.Issue.IssueType != TypeId)
            .And(f => Type == f.Issue.IssueType)
            .And(f => TypeId == f.Issue.IssueType)
            .And(f => Type != f.Issue.IssueType)
            .And(f => TypeId != f.Issue.IssueType)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.IssueType} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.IssueType} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.IssueType.Is())
            .And(f => f.Issue.IssueType.Is(s => s.Empty))
            .And(f => f.Issue.IssueType.Is(s => s.Null))
            .And(f => f.Issue.IssueType.IsNot())
            .And(f => f.Issue.IssueType.IsNot(s => s.Empty))
            .And(f => f.Issue.IssueType.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Type} {Operators.In} ({TypeId}, {TypeId}, {TypeId}) {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.In} ({TypeId}, {TypeId}, {TypeId}) {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.In} ({TypeId}, {Type}, {TypeId}) {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.In} ({TypeId}, {Type}, {TypeId}) {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.NotIn} ({TypeId}, {TypeId}, {TypeId}) {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.NotIn} ({TypeId}, {TypeId}, {TypeId}) {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.NotIn} ({TypeId}, {Type}, {TypeId}) {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.NotIn} ({TypeId}, {Type}, {TypeId})";

        var homogeneousFilter = new JqlCollection<JqlType> { TypeId, TypeId, TypeId };
        var heterogeneousFilter = new JqlCollection<JqlType> { TypeId, Type, TypeId };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.Type.In(TypeId, TypeId, TypeId))
            .And(f => f.Issue.Type.In(homogeneousFilter))
            .And(f => f.Issue.Type.In(TypeId, Type, TypeId))
            .And(f => f.Issue.Type.In(heterogeneousFilter))
            .And(f => f.Issue.Type.NotIn(TypeId, TypeId, TypeId))
            .And(f => f.Issue.Type.NotIn(homogeneousFilter))
            .And(f => f.Issue.Type.NotIn(TypeId, Type, TypeId))
            .And(f => f.Issue.Type.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected =
            $"{Keywords.OrderBy} {FieldContestants.Type} {Keywords.Ascending}, " +
            $"{FieldContestants.IssueType} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Issue.Type)
            .ThenBy(f => f.Issue.IssueType)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}