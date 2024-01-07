namespace JQLBuilder.Infrastructure.Operators;

using Abstract;
using Constants;
using Enum;

public class Bool : IJqlType
{
    public static UnaryOperator operator !(Bool value) => new(Keywords.Not, value, Direction.Prefix);
    public static BinaryOperator operator &(Bool left, Bool right) => new(left, Keywords.And, right, Priority.LogicalAnd);
    public static BinaryOperator operator |(Bool left, Bool right) => new(left, Keywords.Or, right, Priority.LogicalOr);
}