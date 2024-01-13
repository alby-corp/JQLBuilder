namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;

public partial class CategoryTests
{
    #region In

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.Category} {Operators.In} ("{CategoryName}", "{CategoryName}", "{CategoryName}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Category.In(CategoryName, CategoryName, CategoryName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.Category} {Operators.In} ("{CategoryName}", "{CategoryName}", "{CategoryName}")""";
        
        var filter = new JqlCollection<CategoryExpression> { CategoryName, CategoryName, CategoryName };

        var actual = JqlBuilder.Query
            .Where(f => f.Category.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    #endregion

    #region Not In

    [TestMethod]
    public void Should_Parses_NotIn_Params_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.Category} {Operators.NotIn} ("{CategoryName}", "{CategoryName}", "{CategoryName}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Category.NotIn(CategoryName, CategoryName, CategoryName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.Category} {Operators.NotIn} ("{CategoryName}", "{CategoryName}", "{CategoryName}")""";
        
        var filter = new JqlCollection<CategoryExpression> { CategoryName, CategoryName, CategoryName };

        var actual = JqlBuilder.Query
            .Where(f => f.Category.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    #endregion
}