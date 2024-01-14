namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;

public partial class TypeTests
{
    [TestMethod]
    public void Should_Order_By_ASC_Type()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Type} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Type)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_DESC_Type()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Type} {Keywords.Descending}";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Type)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}