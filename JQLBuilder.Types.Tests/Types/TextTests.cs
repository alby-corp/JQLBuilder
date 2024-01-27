namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using Fields = Fields;

[TestClass]
public class TextTests
{
    const string CustomFieldName = "Start date";
    const int CustomFieldId = 10421;
    const string Text = "MyText";
    const string ExpectedCustomFieldName = $@"""{CustomFieldName}""";
    const string ExpectedText = $@"""{Text}""";
    readonly string expectedCustomFieldId = $"cf[{CustomFieldId}]";

    [TestMethod]
    public void Should_Cast_Project_Expression_By_String()
    {
        var expression = (JqlText)Text;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(Text, expression.Value);
    }

    [TestMethod]
    public void Should_Parses_CustomField_Text_From_Name()
    {
        var field = Fields.All.Text[CustomFieldName];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(CustomFieldName, actual);
    }

    [TestMethod]
    public void Should_Parses_CustomField_Text_From_Id()
    {
        var expected = Constants.Fields.Custom(CustomFieldId);

        var field = Fields.All.Text[CustomFieldId];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Summary_Field()
    {
        const string expected = Constants.Fields.Summary;

        var field = Fields.All.Text.Summary;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Description_Field()
    {
        const string expected = Constants.Fields.Description;

        var field = Fields.All.Text.Description;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Comment_Field()
    {
        const string expected = Constants.Fields.Comment;

        var field = Fields.All.Text.Comment;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Environment_Field()
    {
        const string expected = Constants.Fields.Environment;

        var field = Fields.All.Text.Environment;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Text_Field()
    {
        const string expected = Constants.Fields.Text;

        var field = Fields.All.Text;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        var expected =
            $"{ExpectedCustomFieldName} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{ExpectedCustomFieldName} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{ExpectedCustomFieldName} {Operators.Is} {Keywords.Null} {Keywords.And} " +
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
    public void Should_Parses_Contains_Operators()
    {
        var expected = $"{ExpectedCustomFieldName} {Operators.Contains} {ExpectedText} {Keywords.And} " +
                       $"{expectedCustomFieldId} {Operators.NotContains} {ExpectedText}";

        var actual = JqlBuilder.Query
            .Where(f => f.Text[CustomFieldName].Contains(Text))
            .And(f => f.Text[CustomFieldId].NotContains(Text))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}