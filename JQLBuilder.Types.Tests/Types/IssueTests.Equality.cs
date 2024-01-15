namespace JQLBuilder.Types.Tests.Types;

using Constants;

public partial class IssueTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"{Fields.Issue} {Operators.Equals} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue == IssueName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        const string expected = $"{Fields.Issue} {Operators.NotEquals} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue != IssueName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression()
    {
        const string expected = $"{Fields.Issue} {Operators.GreaterThan} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue > IssueName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_To_Expression()
    {
        const string expected = $"{Fields.Issue} {Operators.GreaterThanOrEqual} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue >= IssueName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression()
    {
        const string expected = $"{Fields.Issue} {Operators.LessThan} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue < IssueName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_To_Expression()
    {
        const string expected = $"{Fields.Issue} {Operators.LessThanOrEqual} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue <= IssueName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #region Reverse

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"{Fields.Issue} {Operators.Equals} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => IssueName == f.Issue)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        const string expected = $"{Fields.Issue} {Operators.NotEquals} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => IssueName != f.Issue)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression_Reverse()
    {
        const string expected = $"{Fields.Issue} {Operators.GreaterThan} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => IssueName < f.Issue)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_To_Expression_Reverse()
    {
        const string expected = $"{Fields.Issue} {Operators.GreaterThanOrEqual} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => IssueName <= f.Issue)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression_Reverse()
    {
        const string expected = $"{Fields.Issue} {Operators.LessThan} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => IssueName > f.Issue)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_To_Expression_Reverse()
    {
        const string expected = $"{Fields.Issue} {Operators.LessThanOrEqual} {IssueName}";

        var actual = JqlBuilder.Query
            .Where(f => IssueName >= f.Issue)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}