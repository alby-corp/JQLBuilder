namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class UrlField : JqlValue, IJqlField<UrlExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(UrlField left, UrlExpression right) => left.Equal(right);

    public static Bool operator !=(UrlField left, UrlExpression right) => left.NotEqual(right);

    public static Bool operator ==(UrlExpression left, UrlField right) => right.Equal(left);

    public static Bool operator !=(UrlExpression left, UrlField right) => right.NotEqual(left);
}

public class UrlExpression : JqlValue, IJqlMembership<UrlExpression>
{
    public static implicit operator UrlExpression(string value) => new() { Value = value };
    public static implicit operator UrlExpression(int value) => new() { Value = value };
}