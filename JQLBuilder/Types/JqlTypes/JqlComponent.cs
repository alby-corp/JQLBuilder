namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class ComponentField : JqlValue, IJqlField<JqlComponent>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(ComponentField left, JqlComponent right) => left.Equal(right);
    public static Bool operator !=(ComponentField left, JqlComponent right) => left.NotEqual(right);
    public static Bool operator ==(JqlComponent left, ComponentField right) => right.Equal(left);
    public static Bool operator !=(JqlComponent left, ComponentField right) => right.NotEqual(left);
}

public class JqlComponent : JqlValue, IJqlMembership<JqlComponent>, IJqlHistorical<JqlComponent>
{
    public static implicit operator JqlComponent(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlComponent(int value) => new() { Value = value };
}