namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using DateOnly = DateOnly;
using Fields = Fields;
using DateTime = DateTime;

[TestClass]
public class DateTimeTests
{
    const string CustomFieldName = "DateTime";
    const int CustomFieldId = 10421;
    static readonly DateTime DateTime = new(2001, 2, 3, 4, 5, 0);
    readonly string dateTimeString = $"\"{DateTime:yyyy-MM-dd HH:mm}\"";
    readonly string expectedCustomFieldId = $"cf[{CustomFieldId}]";

    [TestMethod]
    public void Should_Cast_Expression_By_DateTime()
    {
        var expression = (JqlDateTime)DateTime;

        Assert.AreEqual("DateTime", expression.Value.GetType().Name);
        Assert.AreEqual(DateTime, expression.Value);
    }

    [TestMethod]
    public void Should_Parse_DateTime()
    {
        var expected = new DateTime(2000, 2, 3, 4, 5, 0);
        var actual = (JqlDateTime)"2000-02-03 04:05";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Parse_DateOnly()
    {
        var expected = new DateOnly(2000, 2, 3);
        var actual = (JqlDateTime)"2000-02-03";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Parse_RelativeDate()
    {
        var expected = new TimeOffset(0, 0, 1, 2, 3, 4);
        var actual = (JqlDateTime)"3 1m 5h 2d    -4h +1w 2h";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Render_Literals_Correctly()
    {
        var expected =
            $"{expectedCustomFieldId} {Operators.Equals} \"2000-02-03 04:05\" {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.Equals} \"2000-02-03\" {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.Equals} \"2d 5h 4m\"";

        var actual = JqlBuilder.Query
            .Where(f =>
                (f.DateTime[CustomFieldId] == "2000-02-03 04:05") &
                (f.DateTime[CustomFieldId] == "2000-02-03") &
                (f.DateTime[CustomFieldId] == "3 1m 5h 2d"))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Throw_When_Parsing_Invalid_Formats()
    {
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)" ");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"1m - 4h");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"2000-02-03 04:05:06");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"2000-99-03 04:05");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"1y");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"1M");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"m");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"invalid");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"-");
        Assert.ThrowsException<ArgumentException>(() => (JqlDateTime)"+");
    }

    [TestMethod]
    public void Should_Parses_CustomField_DateTime_From_Name()
    {
        var field = Fields.All.DateTime[CustomFieldName];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(CustomFieldName, actual);
    }

    [TestMethod]
    public void Should_Parses_CustomField_DateTime_From_Id()
    {
        var field = Fields.All.Text[CustomFieldId];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expectedCustomFieldId, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{CustomFieldName} {Operators.Equals} {dateTimeString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.NotEquals} {dateTimeString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.GreaterThan} {dateTimeString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.GreaterThanOrEqual} {dateTimeString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.LessThan} {dateTimeString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.LessThanOrEqual} {dateTimeString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.Equals} {dateTimeString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.NotEquals} {dateTimeString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.GreaterThan} {dateTimeString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.GreaterThanOrEqual} {dateTimeString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.LessThan} {dateTimeString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.LessThanOrEqual} {dateTimeString}";

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName] == DateTime)
            .And(f => f.DateTime[CustomFieldName] != DateTime)
            .And(f => f.DateTime[CustomFieldName] > DateTime)
            .And(f => f.DateTime[CustomFieldName] >= DateTime)
            .And(f => f.DateTime[CustomFieldName] < DateTime)
            .And(f => f.DateTime[CustomFieldName] <= DateTime)
            .And(f => DateTime == f.DateTime[CustomFieldId])
            .And(f => DateTime != f.DateTime[CustomFieldId])
            .And(f => DateTime < f.DateTime[CustomFieldId])
            .And(f => DateTime <= f.DateTime[CustomFieldId])
            .And(f => DateTime > f.DateTime[CustomFieldId])
            .And(f => DateTime >= f.DateTime[CustomFieldId])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        var expected =
            $"{CustomFieldName} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{CustomFieldName} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{CustomFieldName} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName].Is())
            .And(f => f.DateTime[CustomFieldName].Is(s => s.Empty))
            .And(f => f.DateTime[CustomFieldName].Is(s => s.Null))
            .And(f => f.DateTime[CustomFieldId].IsNot())
            .And(f => f.DateTime[CustomFieldId].IsNot(s => s.Empty))
            .And(f => f.DateTime[CustomFieldId].IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{CustomFieldName} {Operators.In} ({dateTimeString}, {dateTimeString}, {dateTimeString}) {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.In} ({dateTimeString}, {dateTimeString}, {dateTimeString}) {Keywords.And} " +
            $"{CustomFieldName} {Operators.NotIn} ({dateTimeString}, {dateTimeString}, {dateTimeString}) {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.NotIn} ({dateTimeString}, {dateTimeString}, {dateTimeString})";

        var filter = new JqlCollection<JqlDateTime> { DateTime, DateTime, DateTime };

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName].In(DateTime, DateTime, DateTime))
            .And(f => f.DateTime[CustomFieldId].In(filter))
            .And(f => f.DateTime[CustomFieldName].NotIn(DateTime, DateTime, DateTime))
            .And(f => f.DateTime[CustomFieldId].NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}