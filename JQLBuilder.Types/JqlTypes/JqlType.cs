namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class TypeField : JqlValue, IJqlField<TypeExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(TypeField left, TypeExpression right) => left.Equal(right);
    public static Bool operator !=(TypeField left, TypeExpression right) => left.NotEqual(right);

    public static Bool operator ==(TypeExpression left, TypeField right) => right.Equal(left);
    public static Bool operator !=(TypeExpression left, TypeField right) => right.NotEqual(left);
}

public class TypeExpression : JqlValue, IJqlMembership<TypeExpression>
{
    public static implicit operator TypeExpression(string value) => new() { Value = value };
    public static implicit operator TypeExpression(int value) => new() { Value = value };
}