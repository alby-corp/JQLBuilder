namespace JQLBuilder.Types.Tests;

[TestClass]
public class VersionTests
{
    [TestMethod]
    public void TestMethod1()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.Version.LatestUnreleased() == f.Version.LatestReleased()).ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.AffectedVersion.In(f.Version.Released())).ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void TestMethod3()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.AffectedVersion.In(f.Version.LatestReleased())).ToString();
        
        Assert.AreEqual(expected, actual);
    }
}