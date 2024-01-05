namespace JQLBuilder.Types.Tests.Types;

using Facade;

public partial class NumberTests
{
    [TestMethod]
    public void Should_Parses_Equals_Expression()
    {
        var expected = $"{CustomFieldName} = {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName] == Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression()
    {
        var expected = $"{CustomFieldName} != {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName] != Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression()
    {
        var expected = $"{CustomFieldName} > {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName] > Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_Expression()
    {
        var expected = $"{CustomFieldName} >= {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName] >= Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression()
    {
        var expected = $"{CustomFieldName} < {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName] < Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_Expression()
    {
        var expected = $"{CustomFieldName} <= {Number}";

        var actual = JqlBuilder.Query
            .Where(f => f.Custom.Number[CustomFieldName] <= Number)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #region Reverse

    [TestMethod]
    public void Should_Parses_Equals_Expression_Reverse()
    {
        var expected = $"{CustomFieldName} = {Number}";

        var actual = JqlBuilder.Query
            .Where(f => Number == f.Custom.Number[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Not_Equals_Expression_Reverse()
    {
        var expected = $"{CustomFieldName} != {Number}";

        var actual = JqlBuilder.Query
            .Where(f => Number != f.Custom.Number[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Expression_Reverse()
    {
        var expected = $"{CustomFieldName} > {Number}";

        var actual = JqlBuilder.Query
            .Where(f => Number > f.Custom.Number[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Greater_Than_Or_Equals_Expression_Reverse()
    {
        var expected = $"{CustomFieldName} >= {Number}";

        var actual = JqlBuilder.Query
            .Where(f => Number >= f.Custom.Number[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Expression_Reverse()
    {
        var expected = $"{CustomFieldName} < {Number}";

        var actual = JqlBuilder.Query
            .Where(f => Number < f.Custom.Number[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Less_Than_Or_Equals_Expression_Reverse()
    {
        var expected = $"{CustomFieldName} <= {Number}";

        var actual = JqlBuilder.Query
            .Where(f => Number <= f.Custom.Number[CustomFieldName])
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    #endregion
}