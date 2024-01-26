namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class VersionField : JqlValue, IJqlNullable, IJqlField<JqlVersion>
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(VersionField left, JqlVersion right) => left.Equal(right);
    public static Bool operator !=(VersionField left, JqlVersion right) => left.NotEqual(right);
    public static Bool operator >(VersionField left, JqlVersion right) => left.GreaterThan(right);
    public static Bool operator >=(VersionField left, JqlVersion right) => left.GreaterThanOrEqual(right);
    public static Bool operator <(VersionField left, JqlVersion right) => left.LessThan(right);
    public static Bool operator <=(VersionField left, JqlVersion right) => left.LessThanOrEqual(right);
    public static Bool operator ==(JqlVersion left, VersionField right) => right.Equal(left);
    public static Bool operator !=(JqlVersion left, VersionField right) => right.NotEqual(left);
    public static Bool operator >(JqlVersion left, VersionField right) => right.LessThan(left);
    public static Bool operator >=(JqlVersion left, VersionField right) => right.LessThanOrEqual(left);
    public static Bool operator <(JqlVersion left, VersionField right) => right.GreaterThan(left);
    public static Bool operator <=(JqlVersion left, VersionField right) => right.GreaterThanOrEqual(left);
}

public class JqlVersion : JqlValue, IJqlMembership<JqlVersion>
{
    public static implicit operator JqlVersion(string value) => new() { Value = value };
    public static implicit operator JqlVersion(int value) => new() { Value = value };
}