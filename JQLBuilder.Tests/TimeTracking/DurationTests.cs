namespace JQLBuilder.Tests.TimeTracking;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class DurationTests
{
    const string DurationString = "2d 5h 4m";
    const string ExpectedDuration = $@"""{DurationString}""";
    readonly TimeSpan TimeSpan = TimeSpan.FromSeconds(555 * 24 * 60 * 60 + 4 * 60 * 60 + 3 * 60);
    string ExpectedTimeSpan => $"\"555d 4h 3m\"";
    
    [TestMethod]
    public void Should_Cast_OriginalEstimate_Field()
    {
        const string expected = FieldContestants.OriginalEstimate;

        var field = Fields.All.TimeTracking.OriginalEstimate;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Cast_TimeOriginalEstimate_Field()
    {
        const string expected = FieldContestants.TimeOriginalEstimate;

        var field = Fields.All.TimeTracking.TimeOriginalEstimate;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Cast_RemainingEstimate_Field()
    {
        const string expected = FieldContestants.RemainingEstimate;

        var field = Fields.All.TimeTracking.RemainingEstimate;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Cast_TimeEstimate_Field()
    {
        const string expected = FieldContestants.TimeEstimate;

        var field = Fields.All.TimeTracking.TimeEstimate;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Cast_TimeSpent_Field()
    {
        const string expected = FieldContestants.TimeSpent;

        var field = Fields.All.TimeTracking.TimeSpent;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parse_String_Duration()
    {
        var expected = new TimeOffset(0, 0, 3, 20, 4, 5);
        var actual = (JqlDuration)"20d 3w 4h 5m";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Parse_TimeStamp_Duration()
    {
        var expected = new TimeOffset(0, 0, 0, 10, 9, 8);
        var actual = (JqlDuration)TimeSpan.FromDays(10).Add(TimeSpan.FromHours(9).Add(TimeSpan.FromMinutes(8)));
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Render_Literals_Correctly()
    {
        const string expected = $@"{FieldContestants.TimeEstimate} {Operators.Equals} ""2d 5h 4m""";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.TimeEstimate == "3 1m 5h 2d")
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Throw_When_Parsing_Invalid_Formats()
    {
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)" ");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"1m - 4h");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"2000-02-03 04:05:06");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"2000-99-03 04:05");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"1y");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"1M");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"m");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"invalid");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"-");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"+");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"1m - 4h");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"- 4h");
        Assert.ThrowsException<ArgumentException>(() => (JqlDuration)"+4h");
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.TimeEstimate} {Operators.Equals} {ExpectedDuration} {Keywords.And} " +
            $"{FieldContestants.TimeEstimate} {Operators.NotEquals} {ExpectedDuration} {Keywords.And} " +
            $"{FieldContestants.TimeEstimate} {Operators.GreaterThan} {ExpectedDuration} {Keywords.And} " +
            $"{FieldContestants.TimeEstimate} {Operators.GreaterThanOrEqual} {ExpectedDuration} {Keywords.And} " +
            $"{FieldContestants.TimeEstimate} {Operators.LessThan} {ExpectedDuration} {Keywords.And} " +
            $"{FieldContestants.TimeEstimate} {Operators.LessThanOrEqual} {ExpectedDuration} {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.Equals} {ExpectedTimeSpan} {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.NotEquals} {ExpectedTimeSpan} {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.GreaterThan} {ExpectedTimeSpan} {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.GreaterThanOrEqual} {ExpectedTimeSpan} {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.LessThan} {ExpectedTimeSpan} {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.LessThanOrEqual} {ExpectedTimeSpan}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.TimeEstimate == DurationString)
            .And(f => f.TimeTracking.TimeEstimate != DurationString)
            .And(f => f.TimeTracking.TimeEstimate > DurationString)
            .And(f => f.TimeTracking.TimeEstimate >= DurationString)
            .And(f => f.TimeTracking.TimeEstimate < DurationString)
            .And(f => f.TimeTracking.TimeEstimate <= DurationString)
            .And(f => TimeSpan == f.TimeTracking.OriginalEstimate)
            .And(f => TimeSpan != f.TimeTracking.OriginalEstimate)
            .And(f => TimeSpan < f.TimeTracking.OriginalEstimate)
            .And(f => TimeSpan <= f.TimeTracking.OriginalEstimate)
            .And(f => TimeSpan > f.TimeTracking.OriginalEstimate)
            .And(f => TimeSpan >= f.TimeTracking.OriginalEstimate)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected = 
            $"{FieldContestants.TimeOriginalEstimate} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.TimeOriginalEstimate} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.TimeOriginalEstimate} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.TimeOriginalEstimate} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.TimeOriginalEstimate} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.TimeOriginalEstimate} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.TimeOriginalEstimate.Is())
            .And(f => f.TimeTracking.TimeOriginalEstimate.Is(s => s.Empty))
            .And(f => f.TimeTracking.TimeOriginalEstimate.Is(s => s.Null))
            .And(f => f.TimeTracking.TimeOriginalEstimate.IsNot())
            .And(f => f.TimeTracking.TimeOriginalEstimate.IsNot(s => s.Empty))
            .And(f => f.TimeTracking.TimeOriginalEstimate.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.OriginalEstimate} {Operators.In} ({ExpectedTimeSpan}, {ExpectedTimeSpan}, {ExpectedTimeSpan}) {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.In} ({ExpectedTimeSpan}, {ExpectedDuration}, {ExpectedTimeSpan}) {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.In} ({ExpectedDuration}, {ExpectedDuration}, {ExpectedDuration}) {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.In} ({ExpectedDuration}, {ExpectedTimeSpan}, {ExpectedDuration}) {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.NotIn} ({ExpectedDuration}, {ExpectedDuration}, {ExpectedDuration}) {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.NotIn} ({ExpectedDuration}, {ExpectedTimeSpan}, {ExpectedDuration}) {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.NotIn} ({ExpectedDuration}, {ExpectedDuration}, {ExpectedDuration}) {Keywords.And} " +
            $"{FieldContestants.OriginalEstimate} {Operators.NotIn} ({ExpectedDuration}, {ExpectedTimeSpan}, {ExpectedDuration})";

    
        var homogeneousFilter = new JqlCollection<JqlDuration> { DurationString, DurationString, DurationString };
        var heterogeneousFilter = new JqlCollection<JqlDuration> { DurationString, TimeSpan, DurationString };
    
        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.OriginalEstimate.In(TimeSpan, TimeSpan, TimeSpan))
            .And(f => f.TimeTracking.OriginalEstimate.In(TimeSpan, DurationString, TimeSpan))
            .And(f => f.TimeTracking.OriginalEstimate.In(homogeneousFilter))
            .And(f => f.TimeTracking.OriginalEstimate.In(heterogeneousFilter))
            .And(f => f.TimeTracking.OriginalEstimate.NotIn(DurationString, DurationString, DurationString))
            .And(f => f.TimeTracking.OriginalEstimate.NotIn(DurationString, TimeSpan, DurationString))
            .And(f => f.TimeTracking.OriginalEstimate.NotIn(homogeneousFilter))
            .And(f => f.TimeTracking.OriginalEstimate.NotIn(heterogeneousFilter))
            .ToString();
    
        Assert.AreEqual(expected, actual);
    }
}