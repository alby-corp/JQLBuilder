namespace JQLBuilder.Types.Support;

using Abstract;
using Enum;
using Primitive;

public static class HistoricalExtensions
{
    public static Bool Was<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> => new BinaryOperator(left, Constants.Was, right, Priority.Powerful);

    public static Bool WasIn<T>(this IJqlField<T> left, JqlCollection<T> right) where T : IJqlHistorical<T> => new BinaryOperator(left, Constants.WasIn, right, Priority.Powerful);

    public static Bool WasNot<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> => new BinaryOperator(left, Constants.WasNot, right, Priority.Powerful);

    public static Bool WasNotIn<T>(this IJqlField<T> left, JqlCollection<T> right) where T : IJqlHistorical<T> => new BinaryOperator(left, Constants.WasNotIn, right, Priority.Powerful);

    public static Bool Changed<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> => new BinaryOperator(left, Constants.Changed, right, Priority.Powerful);
}