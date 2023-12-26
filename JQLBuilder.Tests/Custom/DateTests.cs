namespace JQLBuilder.Tests.Custom;

[TestClass]
public class DateTests
{
    [TestMethod]
    public void Method1()
    {
        const string expected = @"""Start Date"" = now()";
        
        var actual = JqlBuilder.Query
            .Where(f => f.Date("Start Date") == f.Now());
        
        Assert.AreEqual(expected, actual.ToString());
    }
    
    [TestMethod]
    public void Method2()
    {
        var actual = JqlBuilder.Query
            .Where(f => f.Date("Start Date") == "2023-10-10");
        
        Assert.AreEqual(@"""Start Date"" = 2023-10-10", actual.ToString());
    }
}