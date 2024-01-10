namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class TextTests
{
    const string CustomFieldName = "Start date";
    const int CustomFieldId = 10421;
    const string Text = "MyText";

    [TestMethod]
    public void Should_Cast_Project_Expression_By_String()
    {
        var expression = (TextExpression)CustomFieldName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(CustomFieldName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Custom_Text_String_Field()
    {
        var field = Fields.All.Text[CustomFieldName];
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(CustomFieldName, actual);
    }

    [TestMethod]
    public void Should_Cast_Custom_Text_Int_Field()
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
}