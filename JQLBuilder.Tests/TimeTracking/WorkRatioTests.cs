namespace JQLBuilder.Tests.TimeTracking;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class WorkRatioTests
{
    const int Ratio = 1234;
    
    [TestMethod]
    public void Should_Cast_WorkRatio_Field()
    {
        const string expected = FieldContestants.WorkRatio;

        var field = Fields.All.TimeTracking.WorkLog.Ratio;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.WorkRatio} {Operators.Equals} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.NotEquals} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.GreaterThan} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.GreaterThanOrEqual} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.LessThan} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.LessThanOrEqual} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.Equals} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.NotEquals} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.LessThan} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.LessThanOrEqual} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.GreaterThan} {Ratio} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.GreaterThanOrEqual} {Ratio}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Ratio == Ratio)
            .And(f => f.TimeTracking.WorkLog.Ratio != Ratio)
            .And(f => f.TimeTracking.WorkLog.Ratio > Ratio)
            .And(f => f.TimeTracking.WorkLog.Ratio >= Ratio)
            .And(f => f.TimeTracking.WorkLog.Ratio < Ratio)
            .And(f => f.TimeTracking.WorkLog.Ratio <= Ratio)
            .And(f => Ratio == f.TimeTracking.WorkLog.Ratio)
            .And(f => Ratio != f.TimeTracking.WorkLog.Ratio)
            .And(f => Ratio < f.TimeTracking.WorkLog.Ratio)
            .And(f => Ratio <= f.TimeTracking.WorkLog.Ratio)
            .And(f => Ratio > f.TimeTracking.WorkLog.Ratio)
            .And(f => Ratio >= f.TimeTracking.WorkLog.Ratio)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected = 
            $"{FieldContestants.WorkRatio} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Ratio.Is())
            .And(f => f.TimeTracking.WorkLog.Ratio.Is(s => s.Empty))
            .And(f => f.TimeTracking.WorkLog.Ratio.Is(s => s.Null))
            .And(f => f.TimeTracking.WorkLog.Ratio.IsNot())
            .And(f => f.TimeTracking.WorkLog.Ratio.IsNot(s => s.Empty))
            .And(f => f.TimeTracking.WorkLog.Ratio.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.WorkRatio} {Operators.In} ({Ratio}, {Ratio}, {Ratio}) {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.In} ({Ratio}, {Ratio}, {Ratio}) {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.NotIn} ({Ratio}, {Ratio}, {Ratio}) {Keywords.And} " +
            $"{FieldContestants.WorkRatio} {Operators.NotIn} ({Ratio}, {Ratio}, {Ratio})";

        var filter = new JqlCollection<JqlNumber> { Ratio, Ratio, Ratio };

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Ratio.In(Ratio, Ratio, Ratio))
            .And(f => f.TimeTracking.WorkLog.Ratio.In(filter))
            .And(f => f.TimeTracking.WorkLog.Ratio.NotIn(Ratio, Ratio, Ratio))
            .And(f => f.TimeTracking.WorkLog.Ratio.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected =
            $"{Keywords.OrderBy} {FieldContestants.WorkRatio} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.TimeTracking.WorkLog.Ratio)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}