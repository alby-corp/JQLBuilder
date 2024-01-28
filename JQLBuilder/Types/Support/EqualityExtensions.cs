// ReSharper disable once CheckNamespace
namespace JQLBuilder;

using Constants;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;

public static class EqualityExtensions
{
    public static BinaryOperator Equal(this IJqlType left, IJqlType right) => new(left, Operators.Equals, right, Priority.Equality);

    public static BinaryOperator NotEqual(this IJqlType left, IJqlType right) => new(left, Operators.NotEquals, right, Priority.Equality);

    public static BinaryOperator GreaterThan(this IJqlType left, IJqlType right) => new(left, Operators.GreaterThan, right, Priority.Relation);

    public static BinaryOperator GreaterThanOrEqual(this IJqlType left, IJqlType right) => new(left, Operators.GreaterThanOrEqual, right, Priority.Relation);

    public static BinaryOperator LessThan(this IJqlType left, IJqlType right) => new(left, Operators.LessThan, right, Priority.Relation);

    public static BinaryOperator LessThanOrEqual(this IJqlType left, IJqlType right) => new(left, Operators.LessThanOrEqual, right, Priority.Relation);
}