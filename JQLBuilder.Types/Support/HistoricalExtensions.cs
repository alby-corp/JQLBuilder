namespace JQLBuilder.Types.Support;

using Contains;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class HistoricalExtensions
{
    internal static Bool Was<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.Was, right, Priority.Powerful);

    internal static Bool WasIn<T>(this IJqlField<T> left, JqlCollection<T> right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasIn, right, Priority.Powerful);

    internal static Bool WasNot<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasNot, right, Priority.Powerful);

    internal static Bool WasNotIn<T>(this IJqlField<T> left, JqlCollection<T> right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasNotIn, right, Priority.Powerful);

    internal static Bool Changed<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.Changed, right, Priority.Powerful);
}