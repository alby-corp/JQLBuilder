namespace JQLBuilder.Types.Support;

using Abstract;
using Constants;
using Infrastructure.Constants;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class NullableExtensions
{
    static Values ValuesSelection { get; } = new();

    internal static Bool Is<T>(this T value, Func<Values, string>? selector = default) where T : IJqlNullable =>
        new UnaryOperator($"{Operators.Is} {selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty}", value, Direction.Suffix);

    internal static Bool IsNot<T>(this T value, Func<Values, string>? selector = default) where T : IJqlNullable =>
        new UnaryOperator($"{Operators.IsNot} {selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty}", value, Direction.Suffix);

    internal class Values
    {
        public readonly string Empty = Keywords.Empty;
        public readonly string Null = Keywords.Null;
    }
}