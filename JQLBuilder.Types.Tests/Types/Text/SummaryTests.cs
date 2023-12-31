﻿namespace JQLBuilder.Types.Tests.Types.Text;

using Support;

[TestClass]
public class SummaryTests
{
    [TestMethod]
    public void Should_Parse_Contains()
    {
        const string expected = """
                                summary ~ "my summary"
                                """;
        
        var actual = JqlBuilder.Query
            .Where(f => f.Text.Summary.Contains("my summary"))
            .ToString();
        
        Assert.AreEqual(expected, actual);
    }
}