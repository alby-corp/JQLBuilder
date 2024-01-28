namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using JQLBuilder.Types.Support;
using FieldContestants = Constants.Fields;
using Fields = Fields;
using Functions = Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class SprintTests
{
    const string Sprint = "ABS";
    const int SprintId = 123;

    [TestMethod]
    public void Should_Cast_Sprint_Expression_From_String()
    {
        var expression = (JqlSprint)Sprint;

        Assert.AreEqual("Field", expression.Value.GetType().Name);
        Assert.AreEqual(new Field(Sprint), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Sprint_Expression_Form_Int()
    {
        var expression = (JqlSprint)SprintId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(SprintId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Sprint_Field()
    {
        const string expected = FieldContestants.Sprint;

        var field = Fields.All.Sprint;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Sprint} {Operators.Equals} {Sprint} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.Equals} {SprintId} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotEquals} {Sprint} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotEquals} {SprintId} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.Equals} {Sprint} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.Equals} {SprintId} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotEquals} {Sprint} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotEquals} {SprintId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Sprint == Sprint)
            .And(f => f.Sprint == SprintId)
            .And(f => f.Sprint != Sprint)
            .And(f => f.Sprint != SprintId)
            .And(f => Sprint == f.Sprint)
            .And(f => SprintId == f.Sprint)
            .And(f => Sprint != f.Sprint)
            .And(f => SprintId != f.Sprint)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Sprint} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Sprint.Is())
            .And(f => f.Sprint.Is(s => s.Empty))
            .And(f => f.Sprint.Is(s => s.Null))
            .And(f => f.Sprint.IsNot())
            .And(f => f.Sprint.IsNot(s => s.Empty))
            .And(f => f.Sprint.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Sprint} {Operators.In} ({SprintId}, {SprintId}, {SprintId}) {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.In} ({SprintId}, {SprintId}, {SprintId}) {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.In} ({SprintId}, {Sprint}, {SprintId}) {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.In} ({SprintId}, {Sprint}, {SprintId}) {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotIn} ({SprintId}, {SprintId}, {SprintId}) {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotIn} ({SprintId}, {SprintId}, {SprintId}) {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotIn} ({SprintId}, {Sprint}, {SprintId}) {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotIn} ({SprintId}, {Sprint}, {SprintId})";

        var homogeneousFilter = new JqlCollection<JqlSprint> { SprintId, SprintId, SprintId };
        var heterogeneousFilter = new JqlCollection<JqlSprint> { SprintId, Sprint, SprintId };

        var actual = JqlBuilder.Query
            .Where(f => f.Sprint.In(SprintId, SprintId, SprintId))
            .And(f => f.Sprint.In(homogeneousFilter))
            .And(f => f.Sprint.In(SprintId, Sprint, SprintId))
            .And(f => f.Sprint.In(heterogeneousFilter))
            .And(f => f.Sprint.NotIn(SprintId, SprintId, SprintId))
            .And(f => f.Sprint.NotIn(homogeneousFilter))
            .And(f => f.Sprint.NotIn(SprintId, Sprint, SprintId))
            .And(f => f.Sprint.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} {FieldContestants.Sprint} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Sprint)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_OpenSprints_Function()
    {
        const string expected =
            $"{FieldContestants.Sprint} {Operators.In} {FunctionsConstants.OpenSprints}() {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotIn} {FunctionsConstants.OpenSprints}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Sprint.In(f.Functions.Sprint.Open()))
            .And(f => f.Sprint.NotIn(f.Functions.Sprint.Open()))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_ClosedSprints_Function()
    {
        const string expected =
            $"{FieldContestants.Sprint} {Operators.In} {FunctionsConstants.ClosedSprints}() {Keywords.And} " +
            $"{FieldContestants.Sprint} {Operators.NotIn} {FunctionsConstants.ClosedSprints}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Sprint.In(Functions.Sprint.Closed()))
            .And(f => f.Sprint.NotIn(Functions.Sprint.Closed()))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}