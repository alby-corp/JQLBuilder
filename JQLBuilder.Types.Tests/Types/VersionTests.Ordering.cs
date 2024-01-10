namespace JQLBuilder.Types.Tests.Types;

public partial class VersionTests
{
    [TestMethod]
    public void Should_Order_By_ASC_Affected_Version()
    {
        const string expected = "order by affectedVersion asc";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Version.Affected)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Order_By_DESC_Affected_Version()
    {
        const string expected = "order by affectedVersion desc";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Version.Affected)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Order_By_ASC_Fix_Version()
    {
        const string expected = "order by fixVersion asc";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Order_By_DESC_Fix_Version()
    {
        const string expected = "order by fixVersion desc";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}