namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;

public partial class StatusTests
{
    [TestMethod]
    public void Should_Order_By_ASC_Affected_Status()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Status} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Status)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_DESC_Affected_Status()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Status} {Keywords.Descending}";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Status)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_ASC_Fix_Status()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Status} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Status)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_DESC_Fix_Status()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Status} {Keywords.Descending}";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Status)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}