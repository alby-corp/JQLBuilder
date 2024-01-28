namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using FieldContestants = Constants.Fields;
using Fields = Fields;

[TestClass]
public class LabelsTests
{
    const string Labels = "ABS";
    const int LabelsId = 123;

    [TestMethod]
    public void Should_Cast_Labels_Expression_From_String()
    {
        var expression = (JqlLabels)Labels;

        Assert.AreEqual("Field", expression.Value.GetType().Name);
        Assert.AreEqual(new Field(Labels), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Labels_Expression_Form_Int()
    {
        var expression = (JqlLabels)LabelsId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(LabelsId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Labels_Field()
    {
        const string expected = FieldContestants.Labels;

        var field = Fields.All.Labels;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Labels} {Operators.Equals} {Labels} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.Equals} {LabelsId} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.NotEquals} {Labels} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.NotEquals} {LabelsId} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.Equals} {Labels} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.Equals} {LabelsId} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.NotEquals} {Labels} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.NotEquals} {LabelsId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Labels == Labels)
            .And(f => f.Labels == LabelsId)
            .And(f => f.Labels != Labels)
            .And(f => f.Labels != LabelsId)
            .And(f => Labels == f.Labels)
            .And(f => LabelsId == f.Labels)
            .And(f => Labels != f.Labels)
            .And(f => LabelsId != f.Labels)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Labels} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Labels.Is())
            .And(f => f.Labels.Is(s => s.Empty))
            .And(f => f.Labels.Is(s => s.Null))
            .And(f => f.Labels.IsNot())
            .And(f => f.Labels.IsNot(s => s.Empty))
            .And(f => f.Labels.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Labels} {Operators.In} ({LabelsId}, {LabelsId}, {LabelsId}) {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.In} ({LabelsId}, {LabelsId}, {LabelsId}) {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.In} ({LabelsId}, {Labels}, {LabelsId}) {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.In} ({LabelsId}, {Labels}, {LabelsId}) {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.NotIn} ({LabelsId}, {LabelsId}, {LabelsId}) {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.NotIn} ({LabelsId}, {LabelsId}, {LabelsId}) {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.NotIn} ({LabelsId}, {Labels}, {LabelsId}) {Keywords.And} " +
            $"{FieldContestants.Labels} {Operators.NotIn} ({LabelsId}, {Labels}, {LabelsId})";

        var homogeneousFilter = new JqlCollection<JqlLabels> { LabelsId, LabelsId, LabelsId };
        var heterogeneousFilter = new JqlCollection<JqlLabels> { LabelsId, Labels, LabelsId };

        var actual = JqlBuilder.Query
            .Where(f => f.Labels.In(LabelsId, LabelsId, LabelsId))
            .And(f => f.Labels.In(homogeneousFilter))
            .And(f => f.Labels.In(LabelsId, Labels, LabelsId))
            .And(f => f.Labels.In(heterogeneousFilter))
            .And(f => f.Labels.NotIn(LabelsId, LabelsId, LabelsId))
            .And(f => f.Labels.NotIn(homogeneousFilter))
            .And(f => f.Labels.NotIn(LabelsId, Labels, LabelsId))
            .And(f => f.Labels.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} {FieldContestants.Labels} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Labels)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}