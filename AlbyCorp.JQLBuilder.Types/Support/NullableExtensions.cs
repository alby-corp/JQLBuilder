// ReSharper disable once CheckNamespace

namespace JQLBuilder;

using System.Diagnostics.CodeAnalysis;
using JqlBuilder.Types.Abstract;
using JqlBuilder.Types.Enum;
using JqlBuilder.Types.Primitive;

public static class NullableExtensions
{
    static Values ValuesSelection { get; } = new();

    /// <summary>
    ///     Creates a unary operator for the "is EMPTY" check.
    /// </summary>
    public static Bool Is<T>(this T value, Func<Values, string> selector) where T : IJqlNullable =>
        new UnaryOperator($"is {selector(ValuesSelection)}", value, Direction.Suffix);

    /// <summary>
    ///     Creates a unary operator for the "is NOT EMPTY" check.
    /// </summary>
    public static Bool IsNot<T>(this T value, Func<Values, string> selector) where T : IJqlNullable =>
        new UnaryOperator($"is not {selector(ValuesSelection)}", value, Direction.Suffix);

    public class Values
    {
        public readonly string Empty = "EMPTY";
        public readonly string Null = "NULL";
    }
}