namespace JQLBuilder.Types.Custom;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class Number : JqlValue, IJqlMembership<Number>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(Number left, Number right) => left.Equal(right);
    public static Bool operator !=(Number left, Number right) => left.NotEqual(right);

    public static Bool operator >(Number left, Number right) => left.GreaterThan(right);
    public static Bool operator >=(Number left, Number right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(Number left, Number right) => left.LessThan(right);
    public static Bool operator <=(Number left, Number right) => left.LessThanOrEqual(right);
}