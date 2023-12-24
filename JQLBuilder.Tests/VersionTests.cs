namespace JQLBuilder.Tests;

[TestClass]
public class VersionTests
{
    [TestMethod]
    public void TestMethod1()
    {
        const string expected = "affectedVersion = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.Version == (e => e.Released())).ToString();
        
        Assert.AreEqual(expected, actual);
    }
}