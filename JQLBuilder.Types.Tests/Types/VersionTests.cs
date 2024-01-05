namespace JQLBuilder.Types.Tests.Types;

using Facade.Builders;

[TestClass]
public class VersionTests
{
    [TestMethod]
    public void TestMethod1()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.Version.Affected == f.Version.Functions.LatestReleased()).ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod2()
    {
        const string expected = "affectedVersion in releasedVersions()";

        var actual = JqlBuilder.Query.Where(f => f.Version.Affected.In(f.Version.Functions.Released())).ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod3()
    {
        const string expected = """affectedVersion in ("12121", latestReleasedVersion(), 123)""";

        var actual = JqlBuilder.Query.Where(f => f.Version.Affected.In("12121", f.Version.Functions.LatestReleased(), 123)).ToString();

        Assert.AreEqual(expected, actual);
    }
}