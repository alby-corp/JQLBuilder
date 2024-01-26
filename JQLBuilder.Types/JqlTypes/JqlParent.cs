namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class ParentField : JqlValue, IJqlField<JqlParent>
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(ParentField left, JqlParent right) => left.Equal(right);
    public static Bool operator !=(ParentField left, JqlParent right) => left.NotEqual(right);
    public static Bool operator ==(JqlParent left, ParentField right) => right.Equal(left);
    public static Bool operator !=(JqlParent left, ParentField right) => right.NotEqual(left);
}

public class JqlParent : JqlValue, IJqlMembership<JqlParent>
{
    public static implicit operator JqlParent(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlParent(int value) => new() { Value = value };
}