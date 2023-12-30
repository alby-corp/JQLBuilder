// ReSharper disable once CheckNamespace

namespace JQLBuilder;

using Types.Abstract;
using Types.Enum;
using Types.Primitive;

public static class MembershipExtensions
{
    public static Bool In<T>(this IJqlField<T> value, IJqlCollection<T> jqlCollection)
        where T : IJqlType, IJqlMembership<T>
        => new BinaryOperator(value, "in", jqlCollection, Priority.Powerful);

    public static Bool In<T>(this IJqlField<T> value, params T[] collection)
        where T : IJqlType, IJqlMembership<T>
        => new BinaryOperator(value, "in", new JqlValue { Value = collection }, Priority.Powerful);

    public static Bool NotIn<T>(this IJqlField<T> value, IJqlCollection<T> jqlCollection)
        where T : IJqlType, IJqlMembership<T>
        => new BinaryOperator(value, "not in", jqlCollection, Priority.Powerful);

    public static Bool NotIn<T>(this IJqlField<T> value, params T[] collection)
        where T : IJqlType, IJqlMembership<T>
        => new BinaryOperator(value, "not in", new JqlValue { Value = collection }, Priority.Powerful);
}