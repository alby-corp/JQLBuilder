﻿namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using Fields = Fields;
using DateOnly = DateOnly;
using FieldConstants = Constants.Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class DateOnlyTests
{
    const string CustomFieldName = "DateOnly";
    const int CustomFieldId = 10421;
    static readonly DateOnly DateOnly = new(2001, 2, 3);
    readonly string dateOnlyString = $"\"{DateOnly:yyyy-MM-dd}\"";
    readonly string expectedCustomFieldId = $"{FieldConstants.Custom(CustomFieldId)}";

    [TestMethod]
    public void Should_Cast_Expression_By_DateOnly()
    {
        var expression = (JqlDate)DateOnly;

        Assert.AreEqual("DateOnly", expression.Value.GetType().Name);
        Assert.AreEqual(DateOnly, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Due_Field()
    {
        const string expected = FieldContestants.Due;

        var field = Fields.All.Date.Due;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_DueDate_Field()
    {
        const string expected = FieldContestants.DueDate;

        var field = Fields.All.Date.DueDate;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parse_DateOnly()
    {
        var expected = new DateOnly(2000, 2, 3);
        var actual = (JqlDate)"2000-02-03";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Parse_RelativeDate()
    {
        var expected = new TimeOffset(0, 0, 1, 2, 3, 4);
        var actual = (JqlDate)"3 1m 5h 2d    -4h +1w 2h";
        Assert.AreEqual(expected, actual.Value);
    }

    [TestMethod]
    public void Should_Render_Literals_Correctly()
    {
        var expected =
            $"{expectedCustomFieldId} {Operators.Equals} \"2000-02-03\" {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.Equals} \"2d 5h 4m\"";

        var actual = JqlBuilder.Query
            .Where(f =>
                (f.Date.Time[CustomFieldId] == "2000-02-03") &
                (f.Date.Time[CustomFieldId] == "3 1m 5h 2d"))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Throw_When_Parsing_Invalid_Formats()
    {
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)" ");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"1m - 4h");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"2000-02-03 04:05:06");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"2000-99-03 04:05");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"1y");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"1M");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"m");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"invalid");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"-");
        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"+");

        Assert.ThrowsException<ArgumentException>(() => (JqlDate)"2000-02-03 04:05");
    }

    [TestMethod]
    public void Should_Parses_CustomField_DateOnly_From_Name()
    {
        var field = Fields.All.Date.Only[CustomFieldName];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(CustomFieldName, actual);
    }

    [TestMethod]
    public void Should_Parses_CustomField_DateOnly_From_Id()
    {
        var field = Fields.All.Text[CustomFieldId];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expectedCustomFieldId, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{CustomFieldName} {Operators.Equals} {dateOnlyString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.NotEquals} {dateOnlyString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.GreaterThan} {dateOnlyString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.GreaterThanOrEqual} {dateOnlyString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.LessThan} {dateOnlyString} {Keywords.And} " +
            $"{CustomFieldName} {Operators.LessThanOrEqual} {dateOnlyString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.Equals} {dateOnlyString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.NotEquals} {dateOnlyString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.GreaterThan} {dateOnlyString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.GreaterThanOrEqual} {dateOnlyString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.LessThan} {dateOnlyString} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.LessThanOrEqual} {dateOnlyString}";

        var actual = JqlBuilder.Query
            .Where(f => f.Date.Only[CustomFieldName] == DateOnly)
            .And(f => f.Date.Only[CustomFieldName] != DateOnly)
            .And(f => f.Date.Only[CustomFieldName] > DateOnly)
            .And(f => f.Date.Only[CustomFieldName] >= DateOnly)
            .And(f => f.Date.Only[CustomFieldName] < DateOnly)
            .And(f => f.Date.Only[CustomFieldName] <= DateOnly)
            .And(f => DateOnly == f.Date.Only[CustomFieldId])
            .And(f => DateOnly != f.Date.Only[CustomFieldId])
            .And(f => DateOnly < f.Date.Only[CustomFieldId])
            .And(f => DateOnly <= f.Date.Only[CustomFieldId])
            .And(f => DateOnly > f.Date.Only[CustomFieldId])
            .And(f => DateOnly >= f.Date.Only[CustomFieldId])
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
            .Where(f => f.Date.Only[CustomFieldName].Is())
            .And(f => f.Date.Only[CustomFieldName].Is(s => s.Empty))
            .And(f => f.Date.Only[CustomFieldName].Is(s => s.Null))
            .And(f => f.Date.Only[CustomFieldId].IsNot())
            .And(f => f.Date.Only[CustomFieldId].IsNot(s => s.Empty))
            .And(f => f.Date.Only[CustomFieldId].IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{CustomFieldName} {Operators.In} ({dateOnlyString}, {dateOnlyString}, {dateOnlyString}) {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.In} ({dateOnlyString}, {dateOnlyString}, {dateOnlyString}) {Keywords.And} " +
            $"{CustomFieldName} {Operators.NotIn} ({dateOnlyString}, {dateOnlyString}, {dateOnlyString}) {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.NotIn} ({dateOnlyString}, {dateOnlyString}, {dateOnlyString})";

        var filter = new JqlCollection<JqlDate> { DateOnly, DateOnly, DateOnly };

        var actual = JqlBuilder.Query
            .Where(f => f.Date.Only[CustomFieldName].In(DateOnly, DateOnly, DateOnly))
            .And(f => f.Date.Only[CustomFieldId].In(filter))
            .And(f => f.Date.Only[CustomFieldName].NotIn(DateOnly, DateOnly, DateOnly))
            .And(f => f.Date.Only[CustomFieldId].NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Date_Functions()
    {
        const string increment = "(-1m)";

        const string expected =
            $"{FieldContestants.Due} {Operators.Equals} {Functions.Now}() {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.CurrentLogin}() {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.StartOfDay}{increment} {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.StartOfWeek}{increment} {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.StartOfMonth}{increment} {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.StartOfYear}{increment} {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.EndOfDay}{increment} {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.EndOfWeek}{increment} {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.EndOfMonth}{increment} {Keywords.And} " +
            $"{FieldContestants.Due} {Operators.Equals} {Functions.EndOfYear}{increment}";

        var actual = JqlBuilder.Query
            .Where(f => f.Date.Due == f.Functions.Date.Now)
            .And(f => f.Date.Due == f.Functions.Date.CurrentLogin)
            .And(f => f.Date.Due == f.Functions.Date.StartOfDay("-1"))
            .And(f => f.Date.Due == f.Functions.Date.StartOfWeek("-1"))
            .And(f => f.Date.Due == f.Functions.Date.StartOfMonth("-1"))
            .And(f => f.Date.Due == f.Functions.Date.StartOfYear("-1"))
            .And(f => f.Date.Due == f.Functions.Date.EndOfDay("-1"))
            .And(f => f.Date.Due == f.Functions.Date.EndOfWeek("-1"))
            .And(f => f.Date.Due == f.Functions.Date.EndOfMonth("-1"))
            .And(f => f.Date.Due == f.Functions.Date.EndOfYear("-1"))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}