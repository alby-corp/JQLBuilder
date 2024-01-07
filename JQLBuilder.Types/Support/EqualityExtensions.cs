namespace JQLBuilder.Types.Support;

using Contains;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class EqualityExtensions
{
    internal static BinaryOperator Equal(this IJqlType left, IJqlType right) => new(left, Operators.Equals, right, Priority.Equality);

    internal static BinaryOperator NotEqual(this IJqlType left, IJqlType right) => new(left, Operators.NotEquals, right, Priority.Equality);

    internal static BinaryOperator GreaterThan(this IJqlType left, IJqlType right) => new(left, Operators.GreaterThan, right, Priority.Relation);

    internal static BinaryOperator GreaterThanOrEqual(this IJqlType left, IJqlType right) => new(left, Operators.GreaterThanOrEqual, right, Priority.Relation);

    internal static BinaryOperator LessThan(this IJqlType left, IJqlType right) => new(left, Operators.LessThan, right, Priority.Relation);

    internal static BinaryOperator LessThanOrEqual(this IJqlType left, IJqlType right) => new(left, Operators.LessThanOrEqual, right, Priority.Relation);
}