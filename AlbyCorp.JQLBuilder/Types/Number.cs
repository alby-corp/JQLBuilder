namespace AlbyCorp.JQLBuilder.Types;

using Abstract;

public class Number(object value) : JqlValue(value), IJqlType
{
    public static Bool operator >(Number left, Number right) => JqlType.GreaterThan(left, right);
    public static Bool operator >=(Number left, Number right) => JqlType.GreaterThanOrEqual(left, right);
    public static Bool operator <(Number left, Number right) => JqlType.LessThan(left, right);
    public static Bool operator <=(Number left, Number right) => JqlType.LessThanOrEqual(left, right);

    public static Bool operator ==(Number left, Number right) => JqlType.Equals(left, right);
    public static Bool operator !=(Number left, Number right) => JqlType.NotEquals(left, right);

    public static implicit operator Number(int value) => new Number(value);
}