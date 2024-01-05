namespace JQLBuilder.Types.Support;

using Infrastructure.Abstract;
using Infrastructure.Constants;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class EqualityExtensions
{
    internal static BinaryOperator Equal(this IJqlType left, IJqlType right) => new(left, JqlKeywords.Equals, right, Priority.Equality);

    internal static BinaryOperator NotEqual(this IJqlType left, IJqlType right) => new(left, JqlKeywords.NotEquals, right, Priority.Equality);

    internal static BinaryOperator GreaterThan(this IJqlType left, IJqlType right) => new(left, JqlKeywords.GreaterThan, right, Priority.Relation);

    internal static BinaryOperator GreaterThanOrEqual(this IJqlType left, IJqlType right) => new(left, JqlKeywords.GreaterThanOrEqual, right, Priority.Relation);

    internal static BinaryOperator LessThan(this IJqlType left, IJqlType right) => new(left, JqlKeywords.LessThan, right, Priority.Relation);

    internal static BinaryOperator LessThanOrEqual(this IJqlType left, IJqlType right) => new(left, JqlKeywords.LessThanOrEqual, right, Priority.Relation);
}