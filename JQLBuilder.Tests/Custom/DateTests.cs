namespace JQLBuilder.Tests.Custom;

[TestClass]
public class DateTests
{
    [TestMethod]
    public void Method1()
    {
        const string expected = @"""Start date"" = now()";
        
        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date["Start date"] == f.Date.Now);
        
        Assert.AreEqual(expected, actual.ToString());
    }
    
    [TestMethod]
    public void Method2()
    {
        const string expected = "cf[12345] = now()";
        
        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date[12345] == f.Date.Now);
            // .Where(f => f.Custom.Date(12345) == f.Custom.Date.Now);
        
        Assert.AreEqual(expected, actual.ToString());
    }
    
    
    [TestMethod]
    public void Method3()
    {
        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date["Start date"] == "2023-10-10");
        
        Assert.AreEqual(@"""Start date"" = 2023-10-10", actual.ToString());
    }
    
    [TestMethod]
    public void Method4()
    {
        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Date["Start date"] == new DateTime(2023, 10, 10));
        
        Assert.AreEqual(@"""Start date"" = 2023-10-10", actual.ToString());
    }
}