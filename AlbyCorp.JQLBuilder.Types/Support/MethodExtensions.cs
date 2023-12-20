namespace AlbyCorp.JQLBuilder.Types.Support;

using Abstract;
using Enum;
using Primitive;

/// <summary>
///     This class provides extension methods for methods that don't involve operators and should be used directly.
/// </summary>
public static class MethodExtensions
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

    /// <summary>
    ///     Creates a unary operator for the "is EMPTY" check.
    /// </summary>
    public static Bool IsEmpty<T>(this T value) where T : IJqlNullable =>
        new UnaryOperator("is EMPTY", value, Direction.Suffix);

    /// <summary>
    ///     Creates a unary operator for the "is NOT EMPTY" check.
    /// </summary>
    public static Bool IsNotEmpty<T>(this T value) where T : IJqlNullable =>
        new UnaryOperator("is NOT EMPTY", value, Direction.Suffix);
}