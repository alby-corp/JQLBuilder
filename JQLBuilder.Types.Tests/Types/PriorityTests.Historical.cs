namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

public partial class PriorityTests
{
    const string User = "USER";
    const string Date = "2023-01-01";
    const string DateTime = "2023-01-01 01:01";

    #region Was/WasNot/Changed

    [TestMethod]
    public void Should_Parses_Was_Expression()
    {
        const string expected = $"{Fields.Priority} {Operators.Was} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Was(PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasNot_Expression()
    {
        const string expected = $"{Fields.Priority} {Operators.WasNot} {PriorityName}";

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
        const string expected = $"{Fields.Priority} {Operators.WasIn} ({PriorityName}, {PriorityName}, {PriorityName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasIn(PriorityName, PriorityName, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Priority} {Operators.WasIn} ({PriorityName}, {PriorityName})";

        var filter = new JqlCollection<PriorityExpression> { PriorityName, PriorityName };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasIn_Params_Expression_Heterogeneous()
    {
        var expected = $"{Fields.Priority} {Operators.WasIn} ({PriorityName}, {PriorityId}, {PriorityName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasIn(PriorityName, PriorityId, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"{Fields.Priority} {Operators.WasIn} ({PriorityId}, {PriorityName})";

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
        const string expected = $"{Fields.Priority} {Operators.WasNotIn} ({PriorityName}, {PriorityName}, {PriorityName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNotIn(PriorityName, PriorityName, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasNotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Priority} {Operators.WasNotIn} ({PriorityName}, {PriorityName})";

        var filter = new JqlCollection<PriorityExpression> { PriorityName, PriorityName };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasNotIn_Params_Expression_Heterogeneous()
    {
        var expected = $"{Fields.Priority} {Operators.WasNotIn} ({PriorityName}, {PriorityId}, {PriorityName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNotIn(PriorityName, PriorityId, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasNotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"{Fields.Priority} {Operators.WasNotIn} ({PriorityId}, {PriorityName})";

        var filter = new JqlCollection<PriorityExpression> { PriorityId, PriorityName };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.WasNotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Changed

    [TestMethod]
    public void Should_Parses_Changed_Empty()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed())
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_From()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed} {Operators.From} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.From(PriorityName)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_From_Empty()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed} {Operators.From} {Operators.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.From(v => v.Empty)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_From_Null()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed} {Operators.From} {Operators.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.From(v => v.Null)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_To()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed} {Operators.To} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.To(PriorityName)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_To_Empty()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed} {Operators.To} {Operators.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.To(v => v.Empty)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_To_Null()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed} {Operators.To} {Operators.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.To(v => v.Null)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By()
    {
        const string expected = $"""
                                 {Fields.Priority} {Operators.Changed} {Operators.By} "{User}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.By(User)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By_Empty()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed} {Operators.By} {Operators.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.By(v => v.Empty)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By_Null()
    {
        const string expected = $"{Fields.Priority} {Operators.Changed} {Operators.By} {Operators.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.By(v => v.Null)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By_Params()
    {
        const string expected = $"""{Fields.Priority} {Operators.Changed} {Operators.By} ("{User}", "{User}", "{User}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.By(User, User, User)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By_Collection()
    {
        const string expected = $"""{Fields.Priority} {Operators.Changed} {Operators.By} ("{User}", "{User}", "{User}")""";

        var filter = new JqlCollection<UserExpression> { User, User, User };

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c => c.By(filter)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_After()
    {
        const string expected = $"""{Fields.Priority} {Operators.Changed} {Operators.After} "{Date}" {Operators.After} "{DateTime}" {Operators.After} {FunctionsConstants.Now}() {Operators.After} {FunctionsConstants.Now}() {Operators.After} {FunctionsConstants.Now}()""";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c =>
                c.After(Date)
                    .After(DateTime)
                    .After(f.Functions.Date.Now)
                    .After(f.Functions.Date.Now)
                    .After(Functions.Date.Now)
            ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_Before()
    {
        const string expected = $"""{Fields.Priority} {Operators.Changed} {Operators.Before} "{Date}" {Operators.Before} "{DateTime}" {Operators.Before} {FunctionsConstants.Now}() {Operators.Before} {FunctionsConstants.Now}() {Operators.Before} {FunctionsConstants.Now}()""";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c =>
                c.Before(Date)
                    .Before(DateTime)
                    .Before(f.Functions.Date.Now)
                    .Before(f.Functions.Date.Now)
                    .Before(Functions.Date.Now)
            ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_On()
    {
        const string expected = $"""{Fields.Priority} {Operators.Changed} {Operators.On} "{Date}" {Operators.On} "{DateTime}" {Operators.On} {FunctionsConstants.Now}() {Operators.On} {FunctionsConstants.Now}() {Operators.On} {FunctionsConstants.Now}()""";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Changed(c =>
                c.On(Date)
                    .On(DateTime)
                    .On(f.Functions.Date.Now)
                    .On(f.Functions.Date.Now)
                    .On(Functions.Date.Now)
            ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_During()
    {
        const string expected = $"""{Fields.Priority} {Operators.Changed} {Operators.During} ({FunctionsConstants.Now}(), {FunctionsConstants.Now}()) {Operators.During} ("{Date}", "{DateTime}") {Operators.During} ("{DateTime}", {FunctionsConstants.Now}()) {Operators.During} ("{Date}", {FunctionsConstants.Now}())""";

        var actual = JqlBuilder.Query.Where(f =>
                f.Priority.Changed(c => c
                    .During(f.Functions.Date.Now, f.Functions.Date.Now)
                    .During(Date, DateTime)
                    .During(DateTime, f.Functions.Date.Now)
                    .During(Date, f.Functions.Date.Now)
                ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}