namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class NumberField : JqlValue, IJqlField<JqlNumber>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(NumberField left, JqlNumber right) => left.Equal(right);
    public static Bool operator !=(NumberField left, JqlNumber right) => left.NotEqual(right);
    public static Bool operator >(NumberField left, JqlNumber right) => left.GreaterThan(right);
    public static Bool operator >=(NumberField left, JqlNumber right) => left.GreaterThanOrEqual(right);
    public static Bool operator <(NumberField left, JqlNumber right) => left.LessThan(right);
    public static Bool operator <=(NumberField left, JqlNumber right) => left.LessThanOrEqual(right);
    public static Bool operator ==(JqlNumber left, NumberField right) => right.Equal(left);
    public static Bool operator !=(JqlNumber left, NumberField right) => right.NotEqual(left);
    public static Bool operator >(JqlNumber left, NumberField right) => right.GreaterThan(left);
    public static Bool operator >=(JqlNumber left, NumberField right) => right.GreaterThanOrEqual(left);
    public static Bool operator <(JqlNumber left, NumberField right) => right.LessThan(left);
    public static Bool operator <=(JqlNumber left, NumberField right) => right.LessThanOrEqual(left);
}

public class JqlNumber : JqlValue, IJqlMembership<JqlNumber>
{
    public static implicit operator JqlNumber(int value) => new() { Value = value };
}