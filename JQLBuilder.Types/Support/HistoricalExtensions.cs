namespace JQLBuilder.Types.Support;

using Abstract;
using Enum;
using Primitive;

public static class HistoricalExtensions
{
    public static Bool Was<T>(this T left, T right) where T : IJqlHistorical<T> => new BinaryOperator(left, "was", right, Priority.Powerful);

    public static Bool WasIn<T>(this T left, JqlCollection<T> right) where T : IJqlHistorical<T> => new BinaryOperator(left, "was in", right, Priority.Powerful);

    public static Bool WasNot<T>(this T left, T right) where T : IJqlHistorical<T> => new BinaryOperator(left, "was not", right, Priority.Powerful);

    public static Bool WasNotIn<T>(this T left, JqlCollection<T> right) where T : IJqlHistorical<T> => new BinaryOperator(left, "was not in", right, Priority.Powerful);

    public static Bool Changed<T>(this T left, T right) where T : IJqlHistorical<T> => new BinaryOperator(left, "changed", right, Priority.Powerful);
}