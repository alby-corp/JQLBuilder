namespace AlbyCorp.JQLBuilder.Types.Primitive;

using Abstract;
using Support;

public class Bool : IJqlType
{
    public static Bool operator !(Bool value) => value.Not();

    public static Bool operator &(Bool left, Bool right) => left.And(right);
    public static Bool operator |(Bool left, Bool right) => left.Or(right);
}