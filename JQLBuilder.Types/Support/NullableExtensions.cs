namespace JQLBuilder.Types.Support;

using Abstract;
using Enum;
using Primitive;

public static class NullableExtensions
{
    static Values ValuesSelection { get; } = new();

    public static Bool Is<T>(this T value, Func<Values, string>? selector = default) where T : IJqlNullable =>
        new UnaryOperator($"is {selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty}", value, Direction.Suffix);
    
    public static Bool IsNot<T>(this T value, Func<Values, string>? selector = default) where T : IJqlNullable =>
        new UnaryOperator($"is not {selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty}", value, Direction.Suffix);

    public class Values
    {
        public readonly string Empty = "EMPTY";
        public readonly string Null = "NULL";
    }
}