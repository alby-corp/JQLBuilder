namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure.Constants;
using Support;

public partial class ProjectTests
{
    [TestMethod]
    public void Should_Parses_Is_Empty()
    {
        const string expected = $"{Fields.Project} {Operators.Is} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Is(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Null()
    {
        const string expected = $"{Fields.Project} {Operators.Is} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Is(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Default()
    {
        const string expected = $"{Fields.Project} {Operators.Is} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.Is())
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Empty()
    {
        const string expected = $"{Fields.Project} {Operators.IsNot} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.IsNot(s => s.Empty))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Is_Not_Null()
    {
        const string expected = $"{Fields.Project} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Should_Parses_Is_Not_Default()
    {
        const string expected = $"{Fields.Project} {Operators.IsNot} {Keywords.Empty}";

        var actual = JqlBuilder.Query
            .Where(f => f.Project.IsNot())
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}