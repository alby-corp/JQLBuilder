// ReSharper disable once CheckNamespace

namespace JQLBuilder;

using Types.Abstract;
using Types.Enum;
using Types.Primitive;

public static class MembershipExtensions
{
    public static Bool In<T>(this T value, IJqlCollection<T> jqlCollection) where T : IJqlMembership<T> =>
        new BinaryOperator(value, "in", jqlCollection, Priority.Powerful);

    public static Bool In<T>(this T value, params T[] collection) where T : class, IJqlMembership<T> =>
        new BinaryOperator(value, "in", new JqlCollection<T> { Value = collection }, Priority.Powerful);

    public static Bool NotIn<T>(this T value, IJqlCollection<T> jqlCollection) where T : IJqlMembership<T> =>
        new BinaryOperator(value, "not in", jqlCollection, Priority.Powerful);

    public static Bool NotIn<T>(this T value, params T[] collection) where T : class, IJqlMembership<T> =>
        new BinaryOperator(value, "not in", new JqlCollection<T> { Value = collection }, Priority.Powerful);
}