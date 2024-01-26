namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class TypeTests
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

        var field = Fields.All.Type;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_TypeType_Field()
    {
        const string expected = FieldContestants.IssueType;

        var field = Fields.All.Type.Issue;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Type} {Operators.Equals} {Type} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.Equals} {TypeId} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.NotEquals} {Type} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.NotEquals} {TypeId} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.Equals} {Type} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.Equals} {TypeId} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.NotEquals} {Type} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.NotEquals} {TypeId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Type == Type)
            .And(f => f.Type == TypeId)
            .And(f => f.Type != Type)
            .And(f => f.Type != TypeId)
            .And(f => Type == f.Type)
            .And(f => TypeId == f.Type)
            .And(f => Type != f.Type)
            .And(f => TypeId != f.Type)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Type} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Type} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Type.Is())
            .And(f => f.Type.Is(s => s.Empty))
            .And(f => f.Type.Is(s => s.Null))
            .And(f => f.Type.IsNot())
            .And(f => f.Type.IsNot(s => s.Empty))
            .And(f => f.Type.IsNot(s => s.Null))
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
            .Where(f => f.Type.In(TypeId, TypeId, TypeId))
            .And(f => f.Type.In(homogeneousFilter))
            .And(f => f.Type.In(TypeId, Type, TypeId))
            .And(f => f.Type.In(heterogeneousFilter))
            .And(f => f.Type.NotIn(TypeId, TypeId, TypeId))
            .And(f => f.Type.NotIn(homogeneousFilter))
            .And(f => f.Type.NotIn(TypeId, Type, TypeId))
            .And(f => f.Type.NotIn(heterogeneousFilter))
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
            .OrderBy(f => f.Type)
            .ThenBy(f => f.Type.Issue)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}