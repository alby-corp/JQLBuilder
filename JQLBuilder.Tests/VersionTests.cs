namespace JQLBuilder.Tests;

[TestClass]
public class VersionTests
{
    [TestMethod]
    public void TestMethod1()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.Version == f.VersionBuildIn.Released()).ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.Version.In(f.VersionBuildIn.Released())).ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void TestMethod3()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.Version.In(f.MembershipVersionBuildIn.Released())).ToString();
        
        Assert.AreEqual(expected, actual);
    }
}