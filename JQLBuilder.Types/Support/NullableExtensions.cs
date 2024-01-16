namespace JQLBuilder.Types.Support;

using Abstract;
using Constants;
using Infrastructure.Operators;
using JqlTypes;

internal static class NullableExtensions
{
    static JqlNoValues ValuesSelection { get; } = new();

    internal static Bool Is<T>(this T value, Func<JqlNoValues, JqlNoValue>? selector = default) where T : IJqlNullable =>
        new NoValueOperator(value, $"{Operators.Is}", selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty);

    internal static Bool IsNot<T>(this T value, Func<JqlNoValues, JqlNoValue>? selector = default) where T : IJqlNullable =>
        new NoValueOperator(value, $"{Operators.IsNot}", selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty);
}