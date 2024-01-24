namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JQLBuilder.Infrastructure.Constants;
using Constants;
using JqlTypes;
using Support;
using Fields = Fields;
using DateTime = System.DateTime;

[TestClass]
public class DateTimeTests
{
    const string CustomFieldName = "DateTime";
    const int CustomFieldId = 10421;
    static readonly DateTime dateTime = new(2001, 2, 3, 4, 5, 0);
    readonly string dateTimeString = $"\"{dateTime:yyyy-MM-dd HH:mm}\"";
    readonly string expectedCustomFieldId = $"cf[{CustomFieldId}]";

    [TestMethod]
    public void Should_Cast_Expression_By_DateTime()
    {
        var expression = (DateTimeExpression) dateTime;

        Assert.AreEqual("DateTime", expression.Value.GetType().Name);
        Assert.AreEqual(dateTime, expression.Value);
    }

    [TestMethod]
    public void Should_Parse_DateTime()
    {
        var expected = new DateTime(2000, 2, 3, 4, 5, 0);
        var actual = (DateTimeExpression) "2000-02-03 04:05";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Parse_DateOnly()
    {
        var expected = new System.DateOnly(2000, 2, 3);
        var actual = (DateTimeExpression) "2000-02-03";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Parse_RelativeDate()
    {
        var expected = new TimeOffset(0, 0, 1, 2, 3, 4);
        var actual = (DateTimeExpression) "3 1m 5h 2d    -4h +1w 2h";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Render_Literals_Correctly()
    {
        var expected = $"{expectedCustomFieldId} {Operators.Equals} \"2000-02-03 04:05\" {Keywords.And} " +
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
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) " ");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "1m - 4h");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "2000-02-03 04:05:06");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "2000-99-03 04:05");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "1y");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "1M");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "m");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "invalid");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "-");
        Assert.ThrowsException<ArgumentException>(() => (DateTimeExpression) "+");
    }

    [TestMethod]
    public void Should_Parses_CustomField_DateTime_From_Name()
    {
        var field = Fields.All.DateTime[CustomFieldName];
        var actual = ((Field) field.Value).Value;

        Assert.AreEqual(CustomFieldName, actual);
    }

    [TestMethod]
    public void Should_Parses_CustomField_DateTime_From_Id()
    {
        var field = Fields.All.Text[CustomFieldId];
        var actual = ((Field) field.Value).Value;

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
            .Where(f => f.DateTime[CustomFieldName] == dateTime)
            .And(f => f.DateTime[CustomFieldName] != dateTime)
            .And(f => f.DateTime[CustomFieldName] > dateTime)
            .And(f => f.DateTime[CustomFieldName] >= dateTime)
            .And(f => f.DateTime[CustomFieldName] < dateTime)
            .And(f => f.DateTime[CustomFieldName] <= dateTime)
            .And(f => dateTime == f.DateTime[CustomFieldId])
            .And(f => dateTime != f.DateTime[CustomFieldId])
            .And(f => dateTime < f.DateTime[CustomFieldId])
            .And(f => dateTime <= f.DateTime[CustomFieldId])
            .And(f => dateTime > f.DateTime[CustomFieldId])
            .And(f => dateTime >= f.DateTime[CustomFieldId])
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

        var filter = new JqlCollection<DateTimeExpression> {dateTime, dateTime, dateTime};

        var actual = JqlBuilder.Query
            .Where(f => f.DateTime[CustomFieldName].In(dateTime, dateTime, dateTime))
            .And(f => f.DateTime[CustomFieldId].In(filter))
            .And(f => f.DateTime[CustomFieldName].NotIn(dateTime, dateTime, dateTime))
            .And(f => f.DateTime[CustomFieldId].NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}