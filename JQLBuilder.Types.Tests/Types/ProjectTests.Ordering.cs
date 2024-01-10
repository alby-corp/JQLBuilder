namespace JQLBuilder.Types.Tests.Types;

public partial class ProjectTests
{
    [TestMethod]
    public void Should_Order_By_ASC_Project()
    {
        const string expected = "order by project asc";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Order_By_DESC_Project()
    {
        const string expected = "order by project desc";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}