namespace JQLBuilder.Types.Support;

using Abstract;
using Contains;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class ContainsExtensions
{
    internal static Bool Contains<T>(this IJqlField<T> left, T right) where T : IJqlContains<T> =>
        new BinaryOperator(left, Operators.Contains, right, Priority.Equality);

    internal static Bool NotContains<T>(this IJqlField<T> left, T right) where T : IJqlContains<T> =>
        new BinaryOperator(left, Operators.NotContains, right, Priority.Equality);
}