namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;
using Support;

public partial class PriorityTests
{
    [TestMethod]
    public void Should_Parses_Is_Empty()
    {
        const string expected = $"{Fields.Priority} {Operators.Is} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Is(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Null()
    {
        const string expected = $"{Fields.Priority} {Operators.Is} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.Is(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Empty()
    {
        const string expected = $"{Fields.Priority} {Operators.IsNot} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.IsNot(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Null()
    {
        const string expected = $"{Fields.Priority} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Priority.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}