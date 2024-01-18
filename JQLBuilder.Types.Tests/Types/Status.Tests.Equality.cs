namespace JQLBuilder.Types.Tests.Types;

using Constants;

public partial class StatusTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        const string expected = $"{Fields.Status} {Operators.Equals} {StatusName}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status == StatusName)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"{Fields.Status} {Operators.NotEquals} {StatusId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Status != StatusId)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #region Reverse

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        const string expected = $"{Fields.Status} {Operators.Equals} {StatusName}";

        var actual = JqlBuilder.Query
            .Where(f => StatusName == f.Status)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"{Fields.Status} {Operators.NotEquals} {StatusId}";

        var actual = JqlBuilder.Query
            .Where(f => StatusId != f.Status)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}