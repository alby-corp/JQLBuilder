namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class PriorityField : JqlValue, IJqlField<JqlPriority>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(PriorityField left, JqlPriority right) => left.Equal(right);
    public static Bool operator !=(PriorityField left, JqlPriority right) => left.NotEqual(right);
    public static Bool operator >(PriorityField left, JqlPriority right) => left.GreaterThan(right);
    public static Bool operator >=(PriorityField left, JqlPriority right) => left.GreaterThanOrEqual(right);
    public static Bool operator <(PriorityField left, JqlPriority right) => left.LessThan(right);
    public static Bool operator <=(PriorityField left, JqlPriority right) => left.LessThanOrEqual(right);
    public static Bool operator ==(JqlPriority left, PriorityField right) => right.Equal(left);
    public static Bool operator !=(JqlPriority left, PriorityField right) => right.NotEqual(left);
    public static Bool operator >(JqlPriority left, PriorityField right) => right.LessThan(left);
    public static Bool operator >=(JqlPriority left, PriorityField right) => right.LessThanOrEqual(left);
    public static Bool operator <(JqlPriority left, PriorityField right) => right.GreaterThan(left);
    public static Bool operator <=(JqlPriority left, PriorityField right) => right.GreaterThanOrEqual(left);
}

public class JqlPriority : JqlValue, IJqlMembership<JqlPriority>, IJqlHistorical<JqlPriority>
{
    public static implicit operator JqlPriority(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlPriority(int value) => new() { Value = new Field($"{value}") };
}