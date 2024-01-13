namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Support;

public partial class PriorityTests
{
    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Priority} {Operators.In} ({PriorityId}, "{PriorityName}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.In(PriorityId, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_In_Params_When_Are_Homogeneous()
    {
        var expected = $"{Fields.Priority} {Operators.In} ({PriorityId}, {PriorityId}, {PriorityId})";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.In(PriorityId, PriorityId, PriorityId))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Heterogeneous()
    {
        var expected = $"""{Fields.Priority} {Operators.NotIn} ({PriorityId}, "{PriorityName}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.NotIn(PriorityId, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_In_Params_When_Are_Homogeneous()
    {
        const string expected = $"""{Fields.Priority} {Operators.NotIn} ("{PriorityName}", "{PriorityName}", "{PriorityName}")""";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.NotIn(PriorityName, PriorityName, PriorityName))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}