namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class ComponentField : JqlValue, IJqlField<ComponentExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(ComponentField left, ComponentExpression right) => left.Equal(right);

    public static Bool operator !=(ComponentField left, ComponentExpression right) => left.NotEqual(right);

    public static Bool operator ==(ComponentExpression left, ComponentField right) => right.Equal(left);

    public static Bool operator !=(ComponentExpression left, ComponentField right) => right.NotEqual(left);
}

public class ComponentExpression : JqlValue, IJqlMembership<ComponentExpression>, IJqlHistorical<ComponentExpression>
{
    public static implicit operator ComponentExpression(string value) => new() { Value = new Field(value) };
    public static implicit operator ComponentExpression(int value) => new() { Value = value };
}