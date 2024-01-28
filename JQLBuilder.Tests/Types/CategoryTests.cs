namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using JQLBuilder.Types.Support;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class CategoryTests
{
    const string Category = "Category";
    const string ExpectedCategory = $@"""{Category}""";

    [TestMethod]
    public void Should_Cast_Category_Expression_From_String()
    {
        var expression = (JqlCategory)Category;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(Category, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Category_Field()
    {
        const string expected = FieldContestants.Category;

        var field = Fields.All.Category;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        const string expected =
            $"{FieldContestants.Category} {Operators.Equals} {ExpectedCategory} {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.NotEquals} {ExpectedCategory} {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.Equals} {ExpectedCategory} {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.NotEquals} {ExpectedCategory}";

        var actual = JqlBuilder.Query
            .Where(f => f.Category == Category)
            .And(f => f.Category != Category)
            .And(f => Category == f.Category)
            .And(f => Category != f.Category)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Category} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Category.Is())
            .And(f => f.Category.Is(s => s.Empty))
            .And(f => f.Category.Is(s => s.Null))
            .And(f => f.Category.IsNot())
            .And(f => f.Category.IsNot(s => s.Empty))
            .And(f => f.Category.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        const string expected =
            $"{FieldContestants.Category} {Operators.In} ({ExpectedCategory}, {ExpectedCategory}, {ExpectedCategory}) {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.In} ({ExpectedCategory}, {ExpectedCategory}, {ExpectedCategory}) {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.NotIn} ({ExpectedCategory}, {ExpectedCategory}, {ExpectedCategory}) {Keywords.And} " +
            $"{FieldContestants.Category} {Operators.NotIn} ({ExpectedCategory}, {ExpectedCategory}, {ExpectedCategory})";

        var filter = new JqlCollection<JqlCategory>
        {
            Category, Category, Category
        };

        var actual = JqlBuilder.Query
            .Where(f => f.Category.In(Category, Category, Category))
            .And(f => f.Category.In(filter))
            .And(f => f.Category.NotIn(Category, Category, Category))
            .And(f => f.Category.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}