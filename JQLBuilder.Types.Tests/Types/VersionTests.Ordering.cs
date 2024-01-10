namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;

public partial class VersionTests
{
    [TestMethod]
    public void Should_Order_By_ASC_Affected_Version()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.AffectedVersion} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Version.Affected)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_DESC_Affected_Version()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.AffectedVersion} {Keywords.Descending}";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Version.Affected)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_ASC_Fix_Version()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.FixVersion} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_DESC_Fix_Version()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.FixVersion} {Keywords.Descending}";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}