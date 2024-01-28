// ReSharper disable once CheckNamespace
namespace JQLBuilder;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;
using Types.Abstract;

public static class MembershipExtensions
{
    public static Bool In<T>(this IJqlField<T> value, IJqlCollection<T> jqlCollection) where T : IJqlType, IJqlMembership<T> =>
        new BinaryOperator(value, Operators.In, jqlCollection, Priority.Powerful);

    public static Bool In<T>(this IJqlField<T> value, params T[] collection) where T : IJqlType, IJqlMembership<T> =>
        new BinaryOperator(value, Operators.In, new JqlValue { Value = collection }, Priority.Powerful);

    public static Bool NotIn<T>(this IJqlField<T> value, IJqlCollection<T> jqlCollection) where T : IJqlType, IJqlMembership<T> =>
        new BinaryOperator(value, Operators.NotIn, jqlCollection, Priority.Powerful);

    public static Bool NotIn<T>(this IJqlField<T> value, params T[] collection) where T : IJqlType, IJqlMembership<T> =>
        new BinaryOperator(value, Operators.NotIn, new JqlValue { Value = collection }, Priority.Powerful);
}