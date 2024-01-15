namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using JqlTypes;
using Support;

public partial class IssueTests
{
    #region In

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        const string expected = $"{Fields.Issue} {Operators.In} ({IssueName}, {IssueName}, {IssueName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.In(IssueName, IssueName, IssueName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Homogeneous()
    {
        const string expected = $"{Fields.Issue} {Operators.In} ({IssueName}, {IssueName}, {IssueName})";

        var filter = new JqlCollection<IssueExpression> { IssueName, IssueName, IssueName };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        const string expected = $"""
                                 {Fields.Issue} {Operators.In} ({IssueName}, {IssueName}, {IssueName})
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.In(IssueName, IssueName, IssueName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Collection_When_Are_Heterogeneous()
    {
        const string expected = $"""{Fields.Issue} {Operators.In} ({IssueName}, {IssueName}, {IssueName})""";

        var filter = new JqlCollection<IssueExpression> { IssueName, IssueName, IssueName };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.In(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion

    #region Not In

    [TestMethod]
    public void Should_Parses_NotIn_Params_When_Are_Homogeneous()
    {
        const string expected = $"{Fields.Issue} {Operators.NotIn} ({IssueName}, {IssueName}, {IssueName})";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.NotIn(IssueName, IssueName, IssueName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Homogeneous()
    {
        const string expected = $"{Fields.Issue} {Operators.NotIn} ({IssueName}, {IssueName}, {IssueName})";

        var filter = new JqlCollection<IssueExpression> { IssueName, IssueName, IssueName };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_NotIn_Params_When_Are_Heterogeneous()
    {
        const string expected = $"""
                                 {Fields.Issue} {Operators.NotIn} ({IssueName}, {IssueName})
                                 """;

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.NotIn(IssueName, IssueName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_NotIn_Collection_When_Are_Heterogeneous()
    {
        const string expected = $"""{Fields.Issue} {Operators.NotIn} ({IssueName}, {IssueName}, {IssueName})""";

        var filter = new JqlCollection<IssueExpression> { IssueName, IssueName, IssueName };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.NotIn(filter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}   