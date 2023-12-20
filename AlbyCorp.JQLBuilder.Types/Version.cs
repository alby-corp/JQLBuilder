namespace AlbyCorp.JQLBuilder.Types;

using Abstract;
using Primitive;
using Support;

public class Version : IJqlValue, IJqlMembership<Version>
{
    public required object Value { get; init; }

    public static Bool operator ==(Version left, Version right) => left.Equal(right);
    public static Bool operator !=(Version left, Version right) => left.NotEqual(right);

    public static Bool operator >(Version left, Version right) => left.GreaterThan(right);
    public static Bool operator >=(Version left, Version right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(Version left, Version right) => left.LessThan(right);
    public static Bool operator <=(Version left, Version right) => left.LessThanOrEqual(right);
}