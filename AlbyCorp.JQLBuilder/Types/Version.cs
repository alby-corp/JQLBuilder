namespace AlbyCorp.JQLBuilder.Types;

using Abstract;

public class Version(object value) : JqlValue(value), IJqlType.IEquatable<Version>, IJqlType.IComparable<Version>
{
    public static Bool operator >(Version left, Version right) => JqlType.GreaterThan(left, right);
    public static Bool operator >=(Version left, Version right) => JqlType.GreaterThanOrEqual(left, right);
    public static Bool operator <(Version left, Version right) => JqlType.LessThan(left, right);
    public static Bool operator <=(Version left, Version right) => JqlType.LessThanOrEqual(left, right);
    public static Bool operator ==(Version left, Version right) => JqlType.Equals(left, right);
    public static Bool operator !=(Version left, Version right) => JqlType.NotEquals(left, right);
}