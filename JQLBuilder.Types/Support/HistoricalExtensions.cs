namespace JQLBuilder.Types.Support;

using Abstract;
using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class HistoricalExtensions
{
    internal static Bool Was<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.Was, right, Priority.Powerful);
    
    internal static Bool WasIn<T>(this IJqlField<T> value, params T[] collection) where T : IJqlType, IJqlHistorical<T> =>
        new BinaryOperator(value, Operators.WasIn, new JqlValue { Value = collection }, Priority.Powerful);

    internal static Bool WasIn<T>(this IJqlField<T> left, JqlCollection<T> right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasIn, right, Priority.Powerful);

    internal static Bool WasNot<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasNot, right, Priority.Powerful);
    
    internal static Bool WasNotIn<T>(this IJqlField<T> value, params T[] collection) where T : IJqlType, IJqlHistorical<T> =>
        new BinaryOperator(value, Operators.WasNotIn, new JqlValue { Value = collection }, Priority.Powerful);

    internal static Bool WasNotIn<T>(this IJqlField<T> left, JqlCollection<T> right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasNotIn, right, Priority.Powerful);

    public static Bool Change<T>(this IJqlField<T> field, Func<Change<T>, Change<T>> operators)
        where T : IJqlType, IJqlHistorical<T>
    {
        var changes = operators(new Change<T>([]));
        return new BinaryOperator(field, "CHANGED", changes, Priority.Powerful);
    }
}
