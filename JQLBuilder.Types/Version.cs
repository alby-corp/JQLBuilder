namespace JQLBuilder.Types;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class VersionField : JqlValue, IJqlNullable, IJqlField<VersionExpression>
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(VersionField left, VersionExpression right) => left.Equal(right);

    public static Bool operator !=(VersionField left, VersionExpression right) => left.NotEqual(right);

    public static Bool operator >(VersionField left, VersionExpression right) => left.LessThan(right);

    public static Bool operator >=(VersionField left, VersionExpression right) => left.LessThanOrEqual(right);

    public static Bool operator <(VersionField left, VersionExpression right) => left.GreaterThan(right);

    public static Bool operator <=(VersionField left, VersionExpression right) => left.GreaterThanOrEqual(right);

    public static Bool operator ==(VersionExpression left, VersionField right) => right.Equal(left);

    public static Bool operator !=(VersionExpression left, VersionField right) => right.NotEqual(left);

    public static Bool operator >(VersionExpression left, VersionField right) => right.GreaterThan(left);

    public static Bool operator >=(VersionExpression left, VersionField right) => right.GreaterThanOrEqual(left);

    public static Bool operator <(VersionExpression left, VersionField right) => right.LessThan(left);

    public static Bool operator <=(VersionExpression left, VersionField right) => right.LessThanOrEqual(left);
}

public class VersionExpression : JqlValue, IJqlMembership<VersionExpression>
{
    public static implicit operator VersionExpression(string value) => new() { Value = value };

    public static implicit operator VersionExpression(int value) => new() { Value = value };
}