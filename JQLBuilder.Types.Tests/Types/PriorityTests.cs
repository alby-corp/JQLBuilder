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
public class PriorityTests
{
    const string Priority = "Low";
    const int PriorityId = 123;

    [TestMethod]
    public void Should_Cast_Priority_Expression_From_String()
    {
        var expression = (JqlVersion)Priority;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(Priority, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Priority_Expression_From_Int()
    {
        var expression = (JqlVersion)PriorityId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(PriorityId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Priority()
    {
        const string expected = FieldContestants.Priority;

        var field = Fields.All.Priority;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Priority} {Operators.Equals} {Priority} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.NotEquals} {Priority} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.GreaterThan} {Priority} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.GreaterThanOrEqual} {Priority} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.LessThan} {Priority} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.LessThanOrEqual} {Priority} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Equals} {PriorityId} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.NotEquals} {PriorityId} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.GreaterThan} {PriorityId} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.GreaterThanOrEqual} {PriorityId} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.LessThan} {PriorityId} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.LessThanOrEqual} {PriorityId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority == Priority)
            .And(f => f.Priority != Priority)
            .And(f => f.Priority > Priority)
            .And(f => f.Priority >= Priority)
            .And(f => f.Priority < Priority)
            .And(f => f.Priority <= Priority)
            .And(f => PriorityId == f.Priority)
            .And(f => PriorityId != f.Priority)
            .And(f => PriorityId < f.Priority)
            .And(f => PriorityId <= f.Priority)
            .And(f => PriorityId > f.Priority)
            .And(f => PriorityId >= f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Priority} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Is())
            .And(f => f.Priority.Is(s => s.Empty))
            .And(f => f.Priority.Is(s => s.Null))
            .And(f => f.Priority.IsNot())
            .And(f => f.Priority.IsNot(s => s.Empty))
            .And(f => f.Priority.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Priority} {Operators.In} ({PriorityId}, {PriorityId}, {PriorityId}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.In} ({PriorityId}, {PriorityId}, {PriorityId}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.In} ({PriorityId}, {Priority}, {PriorityId}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.In} ({PriorityId}, {Priority}, {PriorityId}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.NotIn} ({PriorityId}, {PriorityId}, {PriorityId}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.NotIn} ({PriorityId}, {PriorityId}, {PriorityId}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.NotIn} ({PriorityId}, {Priority}, {PriorityId}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.NotIn} ({PriorityId}, {Priority}, {PriorityId})";

        var homogeneousFilter = new JqlCollection<JqlPriority> { PriorityId, PriorityId, PriorityId };
        var heterogeneousFilter = new JqlCollection<JqlPriority> { PriorityId, Priority, PriorityId };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.In(PriorityId, PriorityId, PriorityId))
            .And(f => f.Priority.In(homogeneousFilter))
            .And(f => f.Priority.In(PriorityId, Priority, PriorityId))
            .And(f => f.Priority.In(heterogeneousFilter))
            .And(f => f.Priority.NotIn(PriorityId, PriorityId, PriorityId))
            .And(f => f.Priority.NotIn(homogeneousFilter))
            .And(f => f.Priority.NotIn(PriorityId, Priority, PriorityId))
            .And(f => f.Priority.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} {FieldContestants.Priority} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Historical_Operators()
    {
        var expected =
            $"{FieldContestants.Priority} {Operators.Was} {Priority} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Was} {PriorityId} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasNot} {Priority} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasNot} {PriorityId} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasIn} ({Priority}, {Priority}, {Priority}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasIn} ({Priority}, {Priority}, {Priority}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasIn} ({Priority}, {PriorityId}, {Priority}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasIn} ({Priority}, {PriorityId}, {Priority}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasNotIn} ({Priority}, {Priority}, {Priority}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasNotIn} ({Priority}, {Priority}, {Priority}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasNotIn} ({Priority}, {PriorityId}, {Priority}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.WasNotIn} ({Priority}, {PriorityId}, {Priority})";

        var homogeneousFilter = new JqlCollection<JqlPriority> { Priority, Priority, Priority };
        var heterogeneousFilter = new JqlCollection<JqlPriority> { Priority, PriorityId, Priority };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Was(Priority))
            .And(f => f.Priority.Was(PriorityId))
            .And(f => f.Priority.WasNot(Priority))
            .And(f => f.Priority.WasNot(PriorityId))
            .And(f => f.Priority.WasIn(Priority, Priority, Priority))
            .And(f => f.Priority.WasIn(homogeneousFilter))
            .And(f => f.Priority.WasIn(Priority, PriorityId, Priority))
            .And(f => f.Priority.WasIn(heterogeneousFilter))
            .And(f => f.Priority.WasNotIn(Priority, Priority, Priority))
            .And(f => f.Priority.WasNotIn(homogeneousFilter))
            .And(f => f.Priority.WasNotIn(Priority, PriorityId, Priority))
            .And(f => f.Priority.WasNotIn(heterogeneousFilter))
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

        const int userId = 123;
        const string user = "USER";
        const string expectedUser = $@"""{user}""";

        var expected =
            $"{FieldContestants.Priority} {Operators.Changed} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Changed} {Operators.After} {expectedDateTime} {Operators.After} {expectedDate} {Operators.After} {expectedDateTime} {Operators.After} {FunctionsConstants.Now}() {Operators.After} {FunctionsConstants.Now}() {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Changed} {Operators.Before} {expectedDateTime} {Operators.Before} {expectedDate} {Operators.Before} {expectedDateTime} {Operators.Before} {FunctionsConstants.Now}() {Operators.Before} {FunctionsConstants.Now}() {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Changed} {Operators.On} {expectedDateTime} {Operators.On} {expectedDate} {Operators.On} {expectedDateTime} {Operators.On} {FunctionsConstants.Now}() {Operators.On} {FunctionsConstants.Now}() {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Changed} {Operators.During} ({expectedDateTime}, {expectedDate}) {Operators.During} ({expectedDate}, {expectedDateTime}) {Operators.During} ({expectedDateTime}, {expectedDateTime}) {Operators.During} ({FunctionsConstants.Now}(), {expectedDateTime}) {Operators.During} ({FunctionsConstants.Now}(), {expectedDate}) {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Changed} {Operators.From} {Priority} {Operators.From} {PriorityId} {Operators.From} {Keywords.Empty} {Operators.From} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Changed} {Operators.To} {Priority} {Operators.To} {PriorityId} {Operators.To} {Keywords.Empty} {Operators.To} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Priority} {Operators.Changed} {Operators.By} {expectedUser} {Operators.By} ({expectedUser}, {expectedUser}, {userId}) {Operators.By} ({expectedUser}, {expectedUser}, {userId}) {Operators.By} {Keywords.Empty} {Operators.By} {Keywords.Null}";

        var filter = new JqlCollection<JqlUser>() { user, user, userId };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed())
            .And(f => f.Priority.Changed(c => c.After(now).After(date).After(dateTime).After(f.Functions.Date.Now).After(Functions.Date.Now)))
            .And(f => f.Priority.Changed(c => c.Before(now).Before(date).Before(dateTime).Before(f.Functions.Date.Now).Before(Functions.Date.Now)))
            .And(f => f.Priority.Changed(c => c.On(now).On(date).On(dateTime).On(f.Functions.Date.Now).On(Functions.Date.Now)))
            .And(f => f.Priority.Changed(c => c.During(now, date).During(date, dateTime).During(dateTime, now).During(f.Functions.Date.Now, now).During(Functions.Date.Now, date)))
            .And(f => f.Priority.Changed(c => c.From(Priority).From(PriorityId).From(a => a.Empty).From(a => a.Null)))
            .And(f => f.Priority.Changed(c => c.To(Priority).To(PriorityId).To(a => a.Empty).To(a => a.Null)))
            .And(f => f.Priority.Changed(c => c.By(user).By(filter).By(user, user, userId).By(a => a.Empty).By(a => a.Null)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}