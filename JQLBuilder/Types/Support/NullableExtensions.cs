// ReSharper disable once CheckNamespace
namespace JQLBuilder;

using Constants;
using Infrastructure.Operators;
using Types.Abstract;
using Types.JqlTypes;

public static class NullableExtensions
{
    static JqlNoValues ValuesSelection { get; } = new();

    public static Bool Is<T>(this T value, Func<JqlNoValues, JqlNoValue>? selector = default) where T : IJqlNullable =>
        new NoValueOperator(value, $"{Operators.Is}", selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty);

    public static Bool IsNot<T>(this T value, Func<JqlNoValues, JqlNoValue>? selector = default) where T : IJqlNullable =>
        new NoValueOperator(value, $"{Operators.IsNot}", selector?.Invoke(ValuesSelection) ?? ValuesSelection.Empty);
}