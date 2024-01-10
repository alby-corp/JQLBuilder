namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;

public partial class ProjectTests
{
    [TestMethod]
    public void Should_Order_By_ASC_Project()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Project} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Order_By_DESC_Project()
    {
        const string expected = $"{Keywords.OrderBy} {Fields.Project} {Keywords.Descending}";

        var actual = JqlBuilder.Query
            .OrderByDescending(f => f.Project)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}