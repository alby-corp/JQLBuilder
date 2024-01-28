namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class TypeField : JqlValue, IJqlField<JqlType>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(TypeField left, JqlType right) => left.Equal(right);
    public static Bool operator !=(TypeField left, JqlType right) => left.NotEqual(right);
    public static Bool operator ==(JqlType left, TypeField right) => right.Equal(left);
    public static Bool operator !=(JqlType left, TypeField right) => right.NotEqual(left);
}

public class JqlType : JqlValue, IJqlMembership<JqlType>
{
    public static implicit operator JqlType(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlType(int value) => new() { Value = value };
}