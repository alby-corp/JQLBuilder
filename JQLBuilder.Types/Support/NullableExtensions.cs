namespace JQLBuilder.Types.Support;

using Infrastructure.Abstract;
using Infrastructure.Constants;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class NullableExtensions
{
    static Values ValuesSelection { get; } = new();

    internal static Bool Is<T>(this T value, Func<Values, string>? selector = default) where T : IJqlNullable =>
        new UnaryOperator($"{JqlKeywords.Is} {selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty}", value, Direction.Suffix);

    internal static Bool IsNot<T>(this T value, Func<Values, string>? selector = default) where T : IJqlNullable =>
        new UnaryOperator($"{JqlKeywords.IsNot} {selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty}", value, Direction.Suffix);

    internal class Values
    {
        public readonly string Empty = JqlKeywords.Empty;
        public readonly string Null = JqlKeywords.Null;
    }
}