namespace JQLBuilder.Types.Tests.Types.Project;

using Support;

public partial class ProjectTests
{
    [TestMethod]
    public void Should_Parses_Is_Empty()
    {
        const string expected = "project is EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Is(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Null()
    {
        const string expected = "project is NULL";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Is(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Empty()
    {
        const string expected = "project is not EMPTY";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.IsNot(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Null()
    {
        const string expected = "project is not NULL";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}