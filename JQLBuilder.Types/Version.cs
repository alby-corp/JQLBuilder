namespace JQLBuilder.Types;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class Version : JqlValue, IJqlMembership<Version>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static implicit operator Version(string value) => new() { Value = value };
    public static implicit operator Version(int value) => new() { Value = value };

    public static Bool operator ==(Version left, Version right) => left.Equal(right);
    public static Bool operator !=(Version left, Version right) => left.NotEqual(right);

    public static Bool operator >(Version left, Version right) => left.GreaterThan(right);
    public static Bool operator >=(Version left, Version right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(Version left, Version right) => left.LessThan(right);
    public static Bool operator <=(Version left, Version right) => left.LessThanOrEqual(right);
}