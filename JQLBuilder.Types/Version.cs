namespace JQLBuilder.Types;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class Version(object value) : IJqlValue, IJqlMembership<Version>
#pragma warning restore CS0660, CS0661
{
    object IJqlValue.Value { get; init; } = value;

    public static Bool operator ==(Version left, Version right) => left.Equal(right);
    public static Bool operator !=(Version left, Version right) => left.NotEqual(right);

    public static Bool operator >(Version left, Version right) => left.GreaterThan(right);
    public static Bool operator >=(Version left, Version right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(Version left, Version right) => left.LessThan(right);
    public static Bool operator <=(Version left, Version right) => left.LessThanOrEqual(right);
}