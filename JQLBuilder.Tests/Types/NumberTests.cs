namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class NumberTests
{
    const string CustomFieldName = "Number";
    const int CustomFieldId = 10421;
    const int Number = 1234;
    readonly string expectedCustomFieldId = $"cf[{CustomFieldId}]";

    [TestMethod]
    public void Should_Cast_Project_Expression_By_Int()
    {
        var expression = (JqlNumber)Number;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(Number, expression.Value);
    }

    [TestMethod]
    public void Should_Parses_CustomField_Number_From_Name()
    {
        var field = Fields.All.Number[CustomFieldName];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(CustomFieldName, actual);
    }

    [TestMethod]
    public void Should_Parses_CustomField_Number_From_Id()
    {
        var field = Fields.All.Text[CustomFieldId];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expectedCustomFieldId, actual);
    }

    [TestMethod]
    public void Should_Cast_Votes_Field()
    {
        const string expected = FieldContestants.Votes;

        var field = Fields.All.Number.Votes;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Watchers_Field()
    {
        const string expected = FieldContestants.Watchers;

        var field = Fields.All.Number.Watchers;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_HierarchicalLevel_Field()
    {
        const string expected = FieldContestants.HierarchicalLevel;

        var field = Fields.All.Number.HierarchicalLevel;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{CustomFieldName} {Operators.Equals} {Number} {Keywords.And} " +
            $"{CustomFieldName} {Operators.NotEquals} {Number} {Keywords.And} " +
            $"{CustomFieldName} {Operators.GreaterThan} {Number} {Keywords.And} " +
            $"{CustomFieldName} {Operators.GreaterThanOrEqual} {Number} {Keywords.And} " +
            $"{CustomFieldName} {Operators.LessThan} {Number} {Keywords.And} " +
            $"{CustomFieldName} {Operators.LessThanOrEqual} {Number} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.Equals} {Number} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.NotEquals} {Number} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.LessThan} {Number} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.LessThanOrEqual} {Number} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.GreaterThan} {Number} {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.GreaterThanOrEqual} {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Number[CustomFieldName] == Number)
            .And(f => f.Number[CustomFieldName] != Number)
            .And(f => f.Number[CustomFieldName] > Number)
            .And(f => f.Number[CustomFieldName] >= Number)
            .And(f => f.Number[CustomFieldName] < Number)
            .And(f => f.Number[CustomFieldName] <= Number)
            .And(f => Number == f.Number[CustomFieldId])
            .And(f => Number != f.Number[CustomFieldId])
            .And(f => Number < f.Number[CustomFieldId])
            .And(f => Number <= f.Number[CustomFieldId])
            .And(f => Number > f.Number[CustomFieldId])
            .And(f => Number >= f.Number[CustomFieldId])
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
            .Where(f => f.Number[CustomFieldName].Is())
            .And(f => f.Number[CustomFieldName].Is(s => s.Empty))
            .And(f => f.Number[CustomFieldName].Is(s => s.Null))
            .And(f => f.Number[CustomFieldId].IsNot())
            .And(f => f.Number[CustomFieldId].IsNot(s => s.Empty))
            .And(f => f.Number[CustomFieldId].IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{CustomFieldName} {Operators.In} ({Number}, {Number}, {Number}) {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.In} ({Number}, {Number}, {Number}) {Keywords.And} " +
            $"{CustomFieldName} {Operators.NotIn} ({Number}, {Number}, {Number}) {Keywords.And} " +
            $"{expectedCustomFieldId} {Operators.NotIn} ({Number}, {Number}, {Number})";

        var filter = new JqlCollection<JqlNumber> { Number, Number, Number };

        var actual = JqlBuilder.Query
            .Where(f => f.Number[CustomFieldName].In(Number, Number, Number))
            .And(f => f.Number[CustomFieldId].In(filter))
            .And(f => f.Number[CustomFieldName].NotIn(Number, Number, Number))
            .And(f => f.Number[CustomFieldId].NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}