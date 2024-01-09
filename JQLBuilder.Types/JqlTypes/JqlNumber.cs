namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class NumberField : JqlValue, IJqlField<NumberExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(NumberField left, NumberExpression right) => left.Equal(right);

    public static Bool operator !=(NumberField left, NumberExpression right) => left.NotEqual(right);

    public static Bool operator >(NumberField left, NumberExpression right) => left.GreaterThan(right);

    public static Bool operator >=(NumberField left, NumberExpression right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(NumberField left, NumberExpression right) => left.LessThan(right);

    public static Bool operator <=(NumberField left, NumberExpression right) => left.LessThanOrEqual(right);

    public static Bool operator ==(NumberExpression left, NumberField right) => right.Equal(left);

    public static Bool operator !=(NumberExpression left, NumberField right) => right.NotEqual(left);

    public static Bool operator >(NumberExpression left, NumberField right) => right.GreaterThan(left);

    public static Bool operator >=(NumberExpression left, NumberField right) => right.GreaterThanOrEqual(left);

    public static Bool operator <(NumberExpression left, NumberField right) => right.LessThan(left);

    public static Bool operator <=(NumberExpression left, NumberField right) => right.LessThanOrEqual(left);
}

public class NumberExpression : JqlValue, IJqlMembership<NumberExpression>
{
    public static implicit operator NumberExpression(int value) => new() { Value = value };
}