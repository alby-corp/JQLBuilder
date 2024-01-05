namespace JQLBuilder.Infrastructure.Operators;

using Abstract;
using Constants;
using Enum;

public class Bool : IJqlType
{
    public static UnaryOperator operator !(Bool value) => new(JqlKeywords.Not, value, Direction.Prefix);
    public static BinaryOperator operator &(Bool left, Bool right) => new(left, JqlKeywords.And, right, Priority.LogicalAnd);
    public static BinaryOperator operator |(Bool left, Bool right) => new(left, JqlKeywords.Or, right, Priority.LogicalOr);
}