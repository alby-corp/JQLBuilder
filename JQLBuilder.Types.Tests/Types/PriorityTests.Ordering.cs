namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;

public partial class PriorityTests
{
    [TestMethod]
    public void Should_Order_By_ASC_Affected_Priority()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Priority} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_DESC_Affected_Priority()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Priority} {Keywords.Descending}";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_ASC_Fix_Priority()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Priority} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_DESC_Fix_Priority()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Priority} {Keywords.Descending}";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}