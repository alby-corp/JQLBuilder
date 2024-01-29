namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using FieldContestants = Constants.Fields;
using Fields = Fields;

[TestClass]
public class FilterTests
{
    const string Filter = "Issues closed in the last 7 days";
    const string ExpectedFilter = $@"""{Filter}""";
    const int FilterId = 123;

    [TestMethod]
    public void Should_Cast_Filter_Expression_From_String()
    {
        var expression = (JqlFilter)Filter;

        Assert.AreEqual("Field", expression.Value.GetType().Name);
        Assert.AreEqual(new Field(Filter), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Filter_Expression_Form_Int()
    {
        var expression = (JqlFilter)FilterId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(FilterId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Filter_Field()
    {
        const string expected = FieldContestants.Filter;

        var field = Fields.All.Filter;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_SearchRequest_Field()
    {
        const string expected = FieldContestants.SearchRequest;

        var field = Fields.All.Filter.SearchRequest;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_SavedFilter_Field()
    {
        const string expected = FieldContestants.SavedFilter;

        var field = Fields.All.Filter.SavedFilter;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Request_Field()
    {
        const string expected = FieldContestants.Request;

        var field = Fields.All.Filter.Request;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Filter} {Operators.Equals} {ExpectedFilter} {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.Equals} {FilterId} {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.NotEquals} {ExpectedFilter} {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.NotEquals} {FilterId} {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.Equals} {ExpectedFilter} {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.Equals} {FilterId} {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.NotEquals} {ExpectedFilter} {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.NotEquals} {FilterId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Filter == Filter)
            .And(f => f.Filter == FilterId)
            .And(f => f.Filter != Filter)
            .And(f => f.Filter != FilterId)
            .And(f => Filter == f.Filter)
            .And(f => FilterId == f.Filter)
            .And(f => Filter != f.Filter)
            .And(f => FilterId != f.Filter)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Filter} {Operators.In} ({FilterId}, {FilterId}, {FilterId}) {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.In} ({FilterId}, {FilterId}, {FilterId}) {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.In} ({FilterId}, {ExpectedFilter}, {FilterId}) {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.In} ({FilterId}, {ExpectedFilter}, {FilterId}) {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.NotIn} ({FilterId}, {FilterId}, {FilterId}) {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.NotIn} ({FilterId}, {FilterId}, {FilterId}) {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.NotIn} ({FilterId}, {ExpectedFilter}, {FilterId}) {Keywords.And} " +
            $"{FieldContestants.Filter} {Operators.NotIn} ({FilterId}, {ExpectedFilter}, {FilterId})";

        var homogeneousFilter = new JqlCollection<JqlFilter> { FilterId, FilterId, FilterId };
        var heterogeneousFilter = new JqlCollection<JqlFilter> { FilterId, Filter, FilterId };

        var actual = JqlBuilder.Query
            .Where(f => f.Filter.In(FilterId, FilterId, FilterId))
            .And(f => f.Filter.In(homogeneousFilter))
            .And(f => f.Filter.In(FilterId, Filter, FilterId))
            .And(f => f.Filter.In(heterogeneousFilter))
            .And(f => f.Filter.NotIn(FilterId, FilterId, FilterId))
            .And(f => f.Filter.NotIn(homogeneousFilter))
            .And(f => f.Filter.NotIn(FilterId, Filter, FilterId))
            .And(f => f.Filter.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}