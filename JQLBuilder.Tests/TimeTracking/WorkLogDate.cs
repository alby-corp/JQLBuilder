namespace JQLBuilder.Tests.TimeTracking;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using Fields = Fields;
using DateOnly = DateOnly;
using FieldContestants = Constants.Fields;

[TestClass]
public class WorkLogDate
{
    static readonly DateOnly DateOnly = new(2001, 2, 3);
    readonly string dateOnlyString = $"\"{DateOnly:yyyy-MM-dd}\"";

    [TestMethod]
    public void Should_Cast_WorklogDate_Field()
    {
        const string expected = FieldContestants.WorklogDate;

        var field = Fields.All.TimeTracking.WorkLog.Date;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Render_Literals_Correctly()
    {
        const string expected = 
            $"{FieldContestants.WorklogDate} {Operators.Equals} \"2000-02-03\" {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} \"2d 5h 4m\"";

        var actual = JqlBuilder.Query
            .Where(f =>
                (f.TimeTracking.WorkLog.Date == "2000-02-03") &
                (f.TimeTracking.WorkLog.Date == "3 1m 5h 2d"))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.WorklogDate} {Operators.Equals} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.NotEquals} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.GreaterThan} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.GreaterThanOrEqual} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.LessThan} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.LessThanOrEqual} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.NotEquals} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.GreaterThan} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.GreaterThanOrEqual} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.LessThan} {dateOnlyString} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.LessThanOrEqual} {dateOnlyString}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Date == DateOnly)
            .And(f => f.TimeTracking.WorkLog.Date != DateOnly)
            .And(f => f.TimeTracking.WorkLog.Date > DateOnly)
            .And(f => f.TimeTracking.WorkLog.Date >= DateOnly)
            .And(f => f.TimeTracking.WorkLog.Date < DateOnly)
            .And(f => f.TimeTracking.WorkLog.Date <= DateOnly)
            .And(f => DateOnly == f.TimeTracking.WorkLog.Date)
            .And(f => DateOnly != f.TimeTracking.WorkLog.Date)
            .And(f => DateOnly <  f.TimeTracking.WorkLog.Date)
            .And(f => DateOnly <= f.TimeTracking.WorkLog.Date)
            .And(f => DateOnly >  f.TimeTracking.WorkLog.Date)
            .And(f => DateOnly >= f.TimeTracking.WorkLog.Date)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected = 
            $"{FieldContestants.WorklogDate} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Date.Is())
            .And(f => f.TimeTracking.WorkLog.Date.Is(s => s.Empty))
            .And(f => f.TimeTracking.WorkLog.Date.Is(s => s.Null))
            .And(f => f.TimeTracking.WorkLog.Date.IsNot())
            .And(f => f.TimeTracking.WorkLog.Date.IsNot(s => s.Empty))
            .And(f => f.TimeTracking.WorkLog.Date.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.WorklogDate} {Operators.In} ({dateOnlyString}, {dateOnlyString}, {dateOnlyString}) {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.In} ({dateOnlyString}, {dateOnlyString}, {dateOnlyString}) {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.NotIn} ({dateOnlyString}, {dateOnlyString}, {dateOnlyString}) {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.NotIn} ({dateOnlyString}, {dateOnlyString}, {dateOnlyString})";

        var filter = new JqlCollection<JqlDate> { DateOnly, DateOnly, DateOnly };

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Date.In(DateOnly, DateOnly, DateOnly))
            .And(f => f.TimeTracking.WorkLog.Date.In(filter))
            .And(f => f.TimeTracking.WorkLog.Date.NotIn(DateOnly, DateOnly, DateOnly))
            .And(f => f.TimeTracking.WorkLog.Date.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Date_Functions()
    {
        const string increment = "(-1m)";

        const string expected =
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.Now}() {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.CurrentLogin}() {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.StartOfDay}{increment} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.StartOfWeek}{increment} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.StartOfMonth}{increment} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.StartOfYear}{increment} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.EndOfDay}{increment} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.EndOfWeek}{increment} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.EndOfMonth}{increment} {Keywords.And} " +
            $"{FieldContestants.WorklogDate} {Operators.Equals} {Functions.EndOfYear}{increment}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.Now)
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.CurrentLogin)
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.StartOfDay("-1"))
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.StartOfWeek("-1"))
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.StartOfMonth("-1"))
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.StartOfYear("-1"))
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.EndOfDay("-1"))
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.EndOfWeek("-1"))
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.EndOfMonth("-1"))
            .And(f => f.TimeTracking.WorkLog.Date == f.Functions.Date.EndOfYear("-1"))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}