namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

public partial class StatusTests
{
    const string User = "USER";
    const string Date = "2023-01-01";
    const string DateTime = "2023-01-01 01:01";

    #region Was/WasNot/Changed

    [TestMethod]
    public void Should_Parses_Was_Expression()
    {
        const string expected = $"{Fields.Status} {Operators.Was} {StatusName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Was(StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasNot_Expression()
    {
        const string expected = $"{Fields.Status} {Operators.WasNot} {StatusName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasNot(StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region WasIn

    [TestMethod]
    public void Should_Parses_WasIn_Params_Expression_Homogeneous()
    {
        const string expected = $"{Fields.Status} {Operators.WasIn} ({StatusName}, {StatusName}, {StatusName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasIn(StatusName, StatusName, StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Status} {Operators.WasIn} ({StatusName}, {StatusName})";

        var filter = new JqlCollection<StatusExpression> { StatusName, StatusName };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasIn_Params_Expression_Heterogeneous()
    {
        var expected = $"{Fields.Status} {Operators.WasIn} ({StatusName}, {StatusId}, {StatusName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasIn(StatusName, StatusId, StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"{Fields.Status} {Operators.WasIn} ({StatusId}, {StatusName})";

        var filter = new JqlCollection<StatusExpression> { StatusId, StatusName };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region WasNotIn

    [TestMethod]
    public void Should_Parses_WasNotIn_Params_Expression_Homogeneous()
    {
        const string expected = $"{Fields.Status} {Operators.WasNotIn} ({StatusName}, {StatusName}, {StatusName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasNotIn(StatusName, StatusName, StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasNotIn_Collection_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Status} {Operators.WasNotIn} ({StatusName}, {StatusName})";

        var filter = new JqlCollection<StatusExpression> { StatusName, StatusName };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasNotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasNotIn_Params_Expression_Heterogeneous()
    {
        var expected = $"{Fields.Status} {Operators.WasNotIn} ({StatusName}, {StatusId}, {StatusName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasNotIn(StatusName, StatusId, StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_WasNotIn_Collection_When_Are_Heterogeneous()
    {
        var expected = $"{Fields.Status} {Operators.WasNotIn} ({StatusId}, {StatusName})";

        var filter = new JqlCollection<StatusExpression> { StatusId, StatusName };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.WasNotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Changed

    [TestMethod]
    public void Should_Parses_Changed_Empty()
    {
        const string expected = $"{Fields.Status} {Operators.Changed}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed())
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_From()
    {
        const string expected = $"{Fields.Status} {Operators.Changed} {Operators.From} {StatusName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.From(StatusName)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_From_Empty()
    {
        const string expected = $"{Fields.Status} {Operators.Changed} {Operators.From} {Operators.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.From(v => v.Empty)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_From_Null()
    {
        const string expected = $"{Fields.Status} {Operators.Changed} {Operators.From} {Operators.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.From(v => v.Null)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_To()
    {
        const string expected = $"{Fields.Status} {Operators.Changed} {Operators.To} {StatusName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.To(StatusName)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_To_Empty()
    {
        const string expected = $"{Fields.Status} {Operators.Changed} {Operators.To} {Operators.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.To(v => v.Empty)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_To_Null()
    {
        const string expected = $"{Fields.Status} {Operators.Changed} {Operators.To} {Operators.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.To(v => v.Null)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By()
    {
        const string expected = $"""
                                 {Fields.Status} {Operators.Changed} {Operators.By} "{User}"
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.By(User)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By_Empty()
    {
        const string expected = $"{Fields.Status} {Operators.Changed} {Operators.By} {Operators.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.By(v => v.Empty)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By_Null()
    {
        const string expected = $"{Fields.Status} {Operators.Changed} {Operators.By} {Operators.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.By(v => v.Null)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By_Params()
    {
        const string expected = $"""{Fields.Status} {Operators.Changed} {Operators.By} ("{User}", "{User}", "{User}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.By(User, User, User)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_By_Collection()
    {
        const string expected = $"""{Fields.Status} {Operators.Changed} {Operators.By} ("{User}", "{User}", "{User}")""";

        var filter = new JqlCollection<UserExpression> { User, User, User };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c => c.By(filter)))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_After()
    {
        const string expected = $"""{Fields.Status} {Operators.Changed} {Operators.After} "{Date}" {Operators.After} "{DateTime}" {Operators.After} {FunctionsConstants.Now}() {Operators.After} {FunctionsConstants.Now}() {Operators.After} {FunctionsConstants.Now}()""";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c =>
                c.After(Date)
                    .After(DateTime)
                    .After(f.DateTime.Functions.Now)
                    .After(f.DateOnly.Functions.Now)
                    .After(Functions.DateTime.Now)
            ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_Before()
    {
        const string expected = $"""{Fields.Status} {Operators.Changed} {Operators.Before} "{Date}" {Operators.Before} "{DateTime}" {Operators.Before} {FunctionsConstants.Now}() {Operators.Before} {FunctionsConstants.Now}() {Operators.Before} {FunctionsConstants.Now}()""";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c =>
                c.Before(Date)
                    .Before(DateTime)
                    .Before(f.DateTime.Functions.Now)
                    .Before(f.DateOnly.Functions.Now)
                    .Before(Functions.DateTime.Now)
            ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_On()
    {
        const string expected = $"""{Fields.Status} {Operators.Changed} {Operators.On} "{Date}" {Operators.On} "{DateTime}" {Operators.On} {FunctionsConstants.Now}() {Operators.On} {FunctionsConstants.Now}() {Operators.On} {FunctionsConstants.Now}()""";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Changed(c =>
                c.On(Date)
                    .On(DateTime)
                    .On(f.DateTime.Functions.Now)
                    .On(f.DateOnly.Functions.Now)
                    .On(Functions.DateTime.Now)
            ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Changed_During()
    {
        const string expected = $"""{Fields.Status} {Operators.Changed} {Operators.During} ({FunctionsConstants.Now}(), {FunctionsConstants.Now}()) {Operators.During} ("{Date}", "{DateTime}") {Operators.During} ("{DateTime}", {FunctionsConstants.Now}()) {Operators.During} ("{Date}", {FunctionsConstants.Now}())""";

        var actual = JqlBuilder.Query.Where(f => 
                f.Status.Changed(c => c
                    .During(f.DateTime.Functions.Now, f.DateOnly.Functions.Now)
                    .During(Date, DateTime)
                    .During(DateTime, f.DateOnly.Functions.Now)
                    .During(Date, f.DateTime.Functions.Now)
                ))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}
