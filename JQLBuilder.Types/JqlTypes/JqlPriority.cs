namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class PriorityField : JqlValue, IJqlField<PriorityExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(PriorityField left, PriorityExpression right) => left.Equal(right);

    public static Bool operator !=(PriorityField left, PriorityExpression right) => left.NotEqual(right);

    public static Bool operator >(PriorityField left, PriorityExpression right) => left.GreaterThan(right);

    public static Bool operator >=(PriorityField left, PriorityExpression right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(PriorityField left, PriorityExpression right) => left.LessThan(right);

    public static Bool operator <=(PriorityField left, PriorityExpression right) => left.LessThanOrEqual(right);

    public static Bool operator ==(PriorityExpression left, PriorityField right) => right.Equal(left);

    public static Bool operator !=(PriorityExpression left, PriorityField right) => right.NotEqual(left);

    public static Bool operator >(PriorityExpression left, PriorityField right) => right.LessThan(left);

    public static Bool operator >=(PriorityExpression left, PriorityField right) => right.LessThanOrEqual(left);

    public static Bool operator <(PriorityExpression left, PriorityField right) => right.GreaterThan(left);

    public static Bool operator <=(PriorityExpression left, PriorityField right) => right.GreaterThanOrEqual(left);
}

public class PriorityExpression : JqlValue, IJqlMembership<PriorityExpression>
{
    public static implicit operator PriorityExpression(string value) => new() { Value = value };
    public static implicit operator PriorityExpression(int value) => new() { Value = value };
}