namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using DateOnly = DateOnly;
using Fields = Fields;
using DateTime = DateTime;
using FieldContestants = Constants.Fields;


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
    public void Should_Cast_Created_Field()
    {
        const string expected = FieldContestants.Created;

        var field = Fields.All.Date.Created;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_CreatedDate_Field()
    {
        const string expected = FieldContestants.CreatedDate;

        var field = Fields.All.Date.CreatedDate;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Updated_Field()
    {
        const string expected = FieldContestants.Updated;

        var field = Fields.All.Date.Updated;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_UpdatedDate_Field()
    {
        const string expected = FieldContestants.UpdatedDate;

        var field = Fields.All.Date.UpdatedDate;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_LastViewed_Field()
    {
        const string expected = FieldContestants.LastViewed;

        var field = Fields.All.Date.LastViewed;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Resolved_Field()
    {
        const string expected = FieldContestants.Resolved;

        var field = Fields.All.Date.Resolved;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_ResolutionDate_Field()
    {
        const string expected = FieldContestants.ResolutionDate;

        var field = Fields.All.Date.ResolutionDate;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
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
                (f.Date.Time[CustomFieldId] == "2000-02-03 04:05") &
                (f.Date.Time[CustomFieldId] == "2000-02-03") &
                (f.Date.Time[CustomFieldId] == "3 1m 5h 2d"))
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
        var field = Fields.All.Date.Time[CustomFieldName];
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
            .Where(f => f.Date.Time[CustomFieldName] == DateTime)
            .And(f => f.Date.Time[CustomFieldName] != DateTime)
            .And(f => f.Date.Time[CustomFieldName] > DateTime)
            .And(f => f.Date.Time[CustomFieldName] >= DateTime)
            .And(f => f.Date.Time[CustomFieldName] < DateTime)
            .And(f => f.Date.Time[CustomFieldName] <= DateTime)
            .And(f => DateTime == f.Date.Time[CustomFieldId])
            .And(f => DateTime != f.Date.Time[CustomFieldId])
            .And(f => DateTime < f.Date.Time[CustomFieldId])
            .And(f => DateTime <= f.Date.Time[CustomFieldId])
            .And(f => DateTime > f.Date.Time[CustomFieldId])
            .And(f => DateTime >= f.Date.Time[CustomFieldId])
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
            .Where(f => f.Date.Time[CustomFieldName].Is())
            .And(f => f.Date.Time[CustomFieldName].Is(s => s.Empty))
            .And(f => f.Date.Time[CustomFieldName].Is(s => s.Null))
            .And(f => f.Date.Time[CustomFieldId].IsNot())
            .And(f => f.Date.Time[CustomFieldId].IsNot(s => s.Empty))
            .And(f => f.Date.Time[CustomFieldId].IsNot(s => s.Null))
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
            .Where(f => f.Date.Time[CustomFieldName].In(DateTime, DateTime, DateTime))
            .And(f => f.Date.Time[CustomFieldId].In(filter))
            .And(f => f.Date.Time[CustomFieldName].NotIn(DateTime, DateTime, DateTime))
            .And(f => f.Date.Time[CustomFieldId].NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
        [TestMethod]
    public void Should_Cast_Date_Functions()
    {
        const string increment = "(-1m)";

        const string expected =
            $"{FieldContestants.Created} {Operators.Equals} {Functions.Now}() {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.CurrentLogin}() {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.StartOfDay}{increment} {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.StartOfWeek}{increment} {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.StartOfMonth}{increment} {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.StartOfYear}{increment} {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.EndOfDay}{increment} {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.EndOfWeek}{increment} {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.EndOfMonth}{increment} {Keywords.And} " +
            $"{FieldContestants.Created} {Operators.Equals} {Functions.EndOfYear}{increment}";

        var actual = JqlBuilder.Query
            .Where(f => f.Date.Created == f.Functions.Date.Now)
            .And(f => f.Date.Created == f.Functions.Date.CurrentLogin)
            .And(f => f.Date.Created == f.Functions.Date.StartOfDay("-1"))
            .And(f => f.Date.Created == f.Functions.Date.StartOfWeek("-1"))
            .And(f => f.Date.Created == f.Functions.Date.StartOfMonth("-1"))
            .And(f => f.Date.Created == f.Functions.Date.StartOfYear("-1"))
            .And(f => f.Date.Created == f.Functions.Date.EndOfDay("-1"))
            .And(f => f.Date.Created == f.Functions.Date.EndOfWeek("-1"))
            .And(f => f.Date.Created == f.Functions.Date.EndOfMonth("-1"))
            .And(f => f.Date.Created == f.Functions.Date.EndOfYear("-1"))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}