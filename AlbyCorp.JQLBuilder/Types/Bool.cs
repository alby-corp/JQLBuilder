namespace AlbyCorp.JQLBuilder.Types;

public class Bool : IJqlType
{
    public static Bool operator &(Bool left, Bool right) => JqlType.And(left, right);
    public static Bool operator |(Bool left, Bool right) => JqlType.Or(left, right);
}