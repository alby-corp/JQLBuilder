namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;

public partial class StatusTests
{
    #region In

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Status} {Operators.In} ({StatusId}, {StatusName})""";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.In(StatusId, StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Status} {Operators.In} ({StatusId}, {StatusName})""";

        var filter = new JqlCollection<StatusExpression> { StatusId, StatusName };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Status} {Operators.In} ({StatusId}, {StatusId}, {StatusId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.In(StatusId, StatusId, StatusId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.Status} {Operators.In} ({StatusName}, {StatusName})""";

        var filter = new JqlCollection<StatusExpression> { StatusName, StatusName };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region NotIn

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Status} {Operators.NotIn} ({StatusId}, {StatusName})""";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.NotIn(StatusId, StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Collection_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Status} {Operators.NotIn} ({StatusId}, {StatusName})""";

        var filter = new JqlCollection<StatusExpression> { StatusId, StatusName };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.Status} {Operators.NotIn} ({StatusName}, {StatusName}, {StatusName})""";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.NotIn(StatusName, StatusName, StatusName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Collection_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.Status} {Operators.NotIn} ({StatusName}, {StatusName})""";

        var filter = new JqlCollection<StatusExpression> { StatusName, StatusName };

        var actual = JqlBuilder.Query
            .Where(f => f.Status.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}