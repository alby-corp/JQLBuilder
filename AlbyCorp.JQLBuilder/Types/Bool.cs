namespace AlbyCorp.JQLBuilder.Types;

using Abstract;

public class Bool(object value) : JqlValue(value), IJqlType
{
    public static Bool operator &(Bool left, Bool right) => JqlType.And(left, right);
    public static Bool operator |(Bool left, Bool right) => JqlType.Or(left, right);

    public static implicit operator Bool(bool value) => new Bool(value);
}