// ReSharper disable once CheckNamespace
namespace JQLBuilder;

using Constants;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;
using Types.Abstract;

public static class ContainsExtensions
{
    public static Bool Contains<T>(this IJqlField<T> left, T right) where T : IJqlContains<T> =>
        new BinaryOperator(left, Operators.Contains, right, Priority.Equality);

    public static Bool NotContains<T>(this IJqlField<T> left, T right) where T : IJqlContains<T> =>
        new BinaryOperator(left, Operators.NotContains, right, Priority.Equality);
}