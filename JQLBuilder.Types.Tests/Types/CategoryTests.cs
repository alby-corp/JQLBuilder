namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class CategoryTests
{
    const string CategoryName = "Category";
    
    [TestMethod]
    public void Should_Cast_Category_Expression_By_String()
    {
        var expression = (CategoryExpression)CategoryName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(CategoryName, expression.Value);
    }
    
    [TestMethod]
    public void Should_Cast_Category()
    {
        const string expected = Constants.Fields.Category;

        var field = Fields.All.Category;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}