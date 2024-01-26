namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using DateTime = System.DateTime;
using FieldContestants = Constants.Fields;
using Fields = Fields;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class StatusTests
{
    const string Status = "Low";
    const int StatusId = 123;

    [TestMethod]
    public void Should_Cast_Status_Expression_From_String()
    {
        var expression = (JqlVersion)Status;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(Status, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Status_Expression_From_Int()
    {
        var expression = (JqlVersion)StatusId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(StatusId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Status()
    {
        const string expected = FieldContestants.Status;

        var field = Fields.All.Status;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Status} {Operators.Equals} {Status} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.NotEquals} {Status} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Equals} {StatusId} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.NotEquals} {StatusId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status == Status)
            .And(f => f.Status != Status)
            .And(f => StatusId == f.Status)
            .And(f => StatusId != f.Status)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Status} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Is())
            .And(f => f.Status.Is(s => s.Empty))
            .And(f => f.Status.Is(s => s.Null))
            .And(f => f.Status.IsNot())
            .And(f => f.Status.IsNot(s => s.Empty))
            .And(f => f.Status.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Status} {Operators.In} ({StatusId}, {StatusId}, {StatusId}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.In} ({StatusId}, {StatusId}, {StatusId}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.In} ({StatusId}, {Status}, {StatusId}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.In} ({StatusId}, {Status}, {StatusId}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.NotIn} ({StatusId}, {StatusId}, {StatusId}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.NotIn} ({StatusId}, {StatusId}, {StatusId}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.NotIn} ({StatusId}, {Status}, {StatusId}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.NotIn} ({StatusId}, {Status}, {StatusId})";

        var homogeneousFilter = new JqlCollection<JqlStatus> { StatusId, StatusId, StatusId };
        var heterogeneousFilter = new JqlCollection<JqlStatus> { StatusId, Status, StatusId };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.In(StatusId, StatusId, StatusId))
            .And(f => f.Status.In(homogeneousFilter))
            .And(f => f.Status.In(StatusId, Status, StatusId))
            .And(f => f.Status.In(heterogeneousFilter))
            .And(f => f.Status.NotIn(StatusId, StatusId, StatusId))
            .And(f => f.Status.NotIn(homogeneousFilter))
            .And(f => f.Status.NotIn(StatusId, Status, StatusId))
            .And(f => f.Status.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} {FieldContestants.Status} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Status)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Historical_Operators()
    {
        var expected =
            $"{FieldContestants.Status} {Operators.Was} {Status} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Was} {StatusId} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasNot} {Status} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasNot} {StatusId} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasIn} ({Status}, {Status}, {Status}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasIn} ({Status}, {Status}, {Status}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasIn} ({Status}, {StatusId}, {Status}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasIn} ({Status}, {StatusId}, {Status}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasNotIn} ({Status}, {Status}, {Status}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasNotIn} ({Status}, {Status}, {Status}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasNotIn} ({Status}, {StatusId}, {Status}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.WasNotIn} ({Status}, {StatusId}, {Status})";

        var homogeneousFilter = new JqlCollection<JqlStatus> { Status, Status, Status };
        var heterogeneousFilter = new JqlCollection<JqlStatus> { Status, StatusId, Status };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Was(Status))
            .And(f => f.Status.Was(StatusId))
            .And(f => f.Status.WasNot(Status))
            .And(f => f.Status.WasNot(StatusId))
            .And(f => f.Status.WasIn(Status, Status, Status))
            .And(f => f.Status.WasIn(homogeneousFilter))
            .And(f => f.Status.WasIn(Status, StatusId, Status))
            .And(f => f.Status.WasIn(heterogeneousFilter))
            .And(f => f.Status.WasNotIn(Status, Status, Status))
            .And(f => f.Status.WasNotIn(homogeneousFilter))
            .And(f => f.Status.WasNotIn(Status, StatusId, Status))
            .And(f => f.Status.WasNotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Change_Operators()
    {
        var now = DateTime.Now;
        var date = $"{now:yyyy-MM-dd}";
        var dateTime = $"{now:yyyy-MM-dd HH:mm}";
        var expectedDate = $@"""{date}""";
        var expectedDateTime = $@"""{dateTime}""";

        const string user = "USER";
        const string expectedUser = $@"""{user}""";

        var expected =
            $"{FieldContestants.Status} {Operators.Changed} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Changed} {Operators.After} {expectedDateTime} {Operators.After} {expectedDate} {Operators.After} {expectedDateTime} {Operators.After} {FunctionsConstants.Now}() {Operators.After} {FunctionsConstants.Now}() {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Changed} {Operators.Before} {expectedDateTime} {Operators.Before} {expectedDate} {Operators.Before} {expectedDateTime} {Operators.Before} {FunctionsConstants.Now}() {Operators.Before} {FunctionsConstants.Now}() {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Changed} {Operators.On} {expectedDateTime} {Operators.On} {expectedDate} {Operators.On} {expectedDateTime} {Operators.On} {FunctionsConstants.Now}() {Operators.On} {FunctionsConstants.Now}() {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Changed} {Operators.During} ({expectedDateTime}, {expectedDate}) {Operators.During} ({expectedDate}, {expectedDateTime}) {Operators.During} ({expectedDateTime}, {expectedDateTime}) {Operators.During} ({FunctionsConstants.Now}(), {expectedDateTime}) {Operators.During} ({FunctionsConstants.Now}(), {expectedDate}) {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Changed} {Operators.From} {Status} {Operators.From} {StatusId} {Operators.To} {Status} {Operators.To} {StatusId} {Keywords.And} " +
            $"{FieldContestants.Status} {Operators.Changed} {Operators.By} {expectedUser}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed())
            .And(f => f.Status.Changed(c => c.After(now).After(date).After(dateTime).After(f.Functions.Date.Now).After(Functions.Date.Now)))
            .And(f => f.Status.Changed(c => c.Before(now).Before(date).Before(dateTime).Before(f.Functions.Date.Now).Before(Functions.Date.Now)))
            .And(f => f.Status.Changed(c => c.On(now).On(date).On(dateTime).On(f.Functions.Date.Now).On(Functions.Date.Now)))
            .And(f => f.Status.Changed(c => c.During(now, date).During(date, dateTime).During(dateTime, now).During(f.Functions.Date.Now, now).During(Functions.Date.Now, date)))
            .And(f => f.Status.Changed(c => c.From(Status).From(StatusId).To(Status).To(StatusId)))
            .And(f => f.Status.Changed(c => c.By(user)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}