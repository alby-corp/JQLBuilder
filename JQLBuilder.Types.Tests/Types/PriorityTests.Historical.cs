namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;

public partial class PriorityTests
{
    #region Was/WasNot/Changed

    [TestMethod]
    public void Should_Parses_Was_Expression()
    {
        const string expected = $"""
                                 {Fields.Priority} {Operators.Was} "{PriorityName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Was(PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_WasNot_Expression()
    {
        const string expected = $"""
                                 {Fields.Priority} {Operators.WasNot} "{PriorityName}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNot(PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }    

    #endregion

    #region WasIn

    [TestMethod]
    public void Should_Parses_WasIn_Params_Expression_Homogeneous()
    {
        const string expected = $"""
                                 {Fields.Priority} {Operators.WasIn} ("{PriorityName}", "{PriorityName}", "{PriorityName}")
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasIn(PriorityName, PriorityName, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_WasIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"""{Fields.Priority} {Operators.WasIn} ("{PriorityName}", "{PriorityName}")""";
        
        var filter = new JqlCollection<PriorityExpression> { PriorityName, PriorityName };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_WasIn_Params_Expression_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Priority} {Operators.WasIn} ("{PriorityName}", {PriorityId}, "{PriorityName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasIn(PriorityName, PriorityId, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_WasIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Priority} {Operators.WasIn} ({PriorityId}, "{PriorityName}")""";
        
        var filter = new JqlCollection<PriorityExpression> { PriorityId, PriorityName };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    #endregion

    #region WasNotIn

    [TestMethod]
    public void Should_Parses_WasNotIn_Params_Expression_Homogeneous()
    {
        const string expected = $"""
                                 {Fields.Priority} {Operators.WasNotIn} ("{PriorityName}", "{PriorityName}", "{PriorityName}")
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNotIn(PriorityName, PriorityName, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_WasNotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"""{Fields.Priority} {Operators.WasNotIn} ("{PriorityName}", "{PriorityName}")""";
        
        var filter = new JqlCollection<PriorityExpression> { PriorityName, PriorityName };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_WasNotIn_Params_Expression_Heterogeneous()
    {
        var expected = $"""
                        {Fields.Priority} {Operators.WasNotIn} ("{PriorityName}", {PriorityId}, "{PriorityName}")
                        """;

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNotIn(PriorityName, PriorityId, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_WasNotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Priority} {Operators.WasNotIn} ({PriorityId}, "{PriorityName}")""";
        
        var filter = new JqlCollection<PriorityExpression> { PriorityId, PriorityName };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}