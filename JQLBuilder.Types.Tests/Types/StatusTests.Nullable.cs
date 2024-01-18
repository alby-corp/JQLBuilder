namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;
using Support;

public partial class StatusTests
{
    [TestMethod]
    public void Should_Parses_Is_Empty()
    {
        const string expected = $"{Fields.Status} {Operators.Is} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Is(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Null()
    {
        const string expected = $"{Fields.Status} {Operators.Is} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Is(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Default()
    {
        const string expected = $"{Fields.Status} {Operators.Is} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.Is())
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Empty()
    {
        const string expected = $"{Fields.Status} {Operators.IsNot} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.IsNot(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Null()
    {
        const string expected = $"{Fields.Status} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Default()
    {
        const string expected = $"{Fields.Status} {Operators.IsNot} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status.IsNot())
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}