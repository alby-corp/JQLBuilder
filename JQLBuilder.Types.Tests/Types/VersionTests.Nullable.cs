namespace JQLBuilder.Types.Tests.Types;

using Support;

public partial class VersionTests
{
    [TestMethod]
    public void Should_Parses_Is_Empty()
    {
        const string expected = "affectedVersion is EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.Is(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Null()
    {
        const string expected = "affectedVersion is NULL";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.Is(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Empty()
    {
        const string expected = "affectedVersion is not EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.IsNot(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Null()
    {
        const string expected = "affectedVersion is not NULL";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}