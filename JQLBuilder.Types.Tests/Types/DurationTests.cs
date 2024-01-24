﻿namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JQLBuilder.Infrastructure.Constants;
using Constants;
using JqlTypes;

[TestClass]
public class DurationTests
{
    const int CustomFieldId = 10421;

    [TestMethod]
    public void Should_Parse_Duration_y()
    {
        var expected = new TimeOffset(1, 0, 0, 0, 0, 0);
        var actual = (DurationArgument) "1y";
        Assert.AreEqual(expected, actual.Value);
    }
    
    [TestMethod]
    public void Should_Parse_Duration_M()
    {
        var expected = new TimeOffset(0, 1, 0, 0, 0, 0);
        var actual = (DurationArgument) "1M";
        Assert.AreEqual(expected, actual.Value);
    }
    
    [TestMethod]
    public void Should_Parse_Duration_w()
    {
        var expected = new TimeOffset(0, 0, 1, 0, 0, 0);
        var actual = (DurationArgument) "1w";
        Assert.AreEqual(expected, actual.Value);
    }
    
    [TestMethod]
    public void Should_Parse_Duration_d()
    {
        var expected = new TimeOffset(0, 0, 0, 1, 0, 0);
        var actual = (DurationArgument) "1d";
        Assert.AreEqual(expected, actual.Value);
    }
    
    [TestMethod]
    public void Should_Parse_Duration_h()
    {
        var expected = new TimeOffset(0, 0, 0, 0, 1, 0);
        var actual = (DurationArgument) "1h";
        Assert.AreEqual(expected, actual.Value);
    }
    
    [TestMethod]
    public void Should_Parse_Duration_m()
    {
        var expected = new TimeOffset(0, 0, 0, 0, 0, 1);
        var actual = (DurationArgument) "1m";
        Assert.AreEqual(expected, actual.Value);
    }
    
    [TestMethod]
    public void Should_Render_Literals_Correctly()
    {
        var expected = $"{Fields.Custom(CustomFieldId)} {Operators.Equals} {Functions.StartOfDay}(\"-1M\") {Keywords.And} " +
                       $"{Fields.Custom(CustomFieldId)} {Operators.Equals} {Functions.EndOfWeek}(\"1h\")";

        var actual = JqlBuilder.Query
            .Where(f =>
                (f.DateTime[CustomFieldId] == f.Functions.Date.StartOfDay("-1M")) &
                (f.DateOnly[CustomFieldId] == f.Functions.Date.EndOfWeek("1h")))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Throw_When_Parsing_Invalid_Formats()
    {
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) " ");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "1m - 4h");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "2000-02-03 04:05:06");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "2000-99-03 04:05");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "1y 1w");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "m");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "invalid");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "-");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "+");
        Assert.ThrowsException<ArgumentException>(() => (DurationArgument) "2000-02-03 04:05");
    }
}