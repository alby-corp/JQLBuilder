// ReSharper disable once CheckNamespace

namespace JQLBuilder;

using Types.Abstract;
using Types.Enum;
using Types.Primitive;

/// <summary>
///     This class provides extension methods for methods that don't involve operators and should be used directly.
/// </summary>
public static class MembershipExtensions
{
    /// <summary>
    ///     Creates a binary operator for the "in" membership check.
    /// </summary>
    public static Bool In<T>(this T value, IJqlCollection<T> jqlCollection) where T : IJqlMembership<T> =>
        new BinaryOperator(value, "in", jqlCollection, Priority.Powerful);

    /// <summary>
    ///     Creates a binary operator for the "in" membership check using a variable number of parameters.
    /// </summary>
    public static Bool In<T>(this T value, params T[] collection) where T : class, IJqlMembership<T> =>
        new BinaryOperator(value, "in", new JqlCollection<T> { Value = collection }, Priority.Powerful);

    /// <summary>
    ///     Creates a binary operator for the "not in" non-membership check.
    /// </summary>
    public static Bool NotIn<T>(this T value, IJqlCollection<T> jqlCollection) where T : IJqlMembership<T> =>
        new BinaryOperator(value, "not in", jqlCollection, Priority.Powerful);

    /// <summary>
    ///     Creates a binary operator for the "not in" non-membership check using a variable number of parameters.
    /// </summary>
    public static Bool NotIn<T>(this T value, params T[] collection) where T : class, IJqlMembership<T> =>
        new BinaryOperator(value, "not in", new JqlCollection<T> { Value = collection }, Priority.Powerful);
}