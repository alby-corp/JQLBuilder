﻿namespace JQLBuilder.Types.Tests;

[TestClass]
public class VersionTests
{
    [TestMethod]
    public void TestMethod1()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.AffectedVersion == f.Versions.LatestReleased()).ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        const string expected = "affectedVersion in releasedVersions()";

        var actual = JqlBuilder.Query.Where(f => f.AffectedVersion.In(f.Versions.Released())).ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void TestMethod3()
    {
        const string expected = """affectedVersion in ("12121", latestReleasedVersion(), 123)""";

        var actual = JqlBuilder.Query.Where(f => f.AffectedVersion.In("12121", f.Versions.LatestReleased(), 123)).ToString();
        
        Assert.AreEqual(expected, actual);
    }
}