namespace JQLBuilder.Types.Tests.Types;

using Constants;

public partial class PriorityTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"{Fields.Priority} {Operators.Equals} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority == PriorityName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"{Fields.Priority} {Operators.NotEquals} {PriorityId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority != PriorityId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression()
    {
        const string expected = $"{Fields.Priority} {Operators.GreaterThan} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority > PriorityName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_To_Expression()
    {
        var expected = $"{Fields.Priority} {Operators.GreaterThanOrEqual} {PriorityId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority >= PriorityId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression()
    {
        const string expected = $"{Fields.Priority} {Operators.LessThan} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority < PriorityName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_To_Expression()
    {
        var expected = $"{Fields.Priority} {Operators.LessThanOrEqual} {PriorityId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority <= PriorityId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #region Reverse

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"{Fields.Priority} {Operators.Equals} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => PriorityName == f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"{Fields.Priority} {Operators.NotEquals} {PriorityId}";

        var actual = JqlBuilder.Query
            .Where(f => PriorityId != f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression_Reverse()
    {
        const string expected = $"{Fields.Priority} {Operators.GreaterThan} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => PriorityName < f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_To_Expression_Reverse()
    {
        var expected = $"{Fields.Priority} {Operators.GreaterThanOrEqual} {PriorityId}";

        var actual = JqlBuilder.Query
            .Where(f => PriorityId <= f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression_Reverse()
    {
        const string expected = $"{Fields.Priority} {Operators.LessThan} {PriorityName}";

        var actual = JqlBuilder.Query
            .Where(f => PriorityName > f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_To_Expression_Reverse()
    {
        var expected = $"{Fields.Priority} {Operators.LessThanOrEqual} {PriorityId}";

        var actual = JqlBuilder.Query
            .Where(f => PriorityId >= f.Priority)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}