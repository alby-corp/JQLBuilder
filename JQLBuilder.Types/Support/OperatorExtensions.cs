namespace JQLBuilder.Types.Support;

using Abstract;
using Enum;
using Primitive;

/// <summary>
///     This class provides extension methods for operator overloads. Use this class exclusively for extensions defining
///     operator behaviors.
///     For example, core operators such as == and != are implemented in <see cref="Equal" /> and <see cref="NotEqual" />
///     defined here.
/// </summary>
internal static class OperatorExtensions
{
    /// <summary>
    ///     Creates a binary operator for the equality comparison (==).
    /// </summary>
    internal static BinaryOperator Equal(this IJqlType left, IJqlType right) =>
        new(left, Constants.Equals, right, Priority.Equality);

    /// <summary>
    ///     Creates a binary operator for the inequality comparison (!=).
    /// </summary>
    internal static BinaryOperator NotEqual(this IJqlType left, IJqlType right) =>
        new(left, Constants.NotEquals, right, Priority.Equality);

    /// <summary>
    ///     Creates a binary operator for the greater-than comparison (>).
    /// </summary>
    internal static BinaryOperator GreaterThan(this IJqlType left, IJqlType right) =>
        new(left, Constants.GreaterThan, right, Priority.Relation);

    /// <summary>
    ///     Creates a binary operator for the greater-than-or-equal comparison (>=).
    /// </summary>
    internal static BinaryOperator GreaterThanOrEqual(this IJqlType left, IJqlType right) =>
        new(left, Constants.GreaterThanOrEqual, right, Priority.Relation);

    /// <summary>
    ///     Creates a binary operator for the less-than comparison (<).
    /// </summary>
    internal static BinaryOperator LessThan(this IJqlType left, IJqlType right) =>
        new(left, Constants.LessThan, right, Priority.Relation);

    /// <summary>
    ///     Creates a binary operator for the less-than-or-equal comparison (<=).
    /// </summary>
    internal static BinaryOperator LessThanOrEqual(this IJqlType left, IJqlType right) =>
        new(left, Constants.LessThanOrEqual, right, Priority.Relation);

    /// <summary>
    ///     Creates a binary operator for the AND logical operation (!).
    /// </summary>
    internal static BinaryOperator And(this IJqlType left, IJqlType right) =>
        new(left, Constants.And, right, Priority.LogicalAnd);

    /// <summary>
    ///     Creates a binary operator for the OR logical operation (||).
    /// </summary>
    internal static BinaryOperator Or(this IJqlType left, IJqlType right) =>
        new(left, Constants.Or, right, Priority.LogicalOr);

    /// <summary>
    ///     Creates a unary operator for the NOT logical operation (!).
    /// </summary>
    internal static Bool Not(this Bool value) =>
        new UnaryOperator(Constants.Not, value, Direction.Prefix);
}