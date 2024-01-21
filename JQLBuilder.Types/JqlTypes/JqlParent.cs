namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class ParentField : JqlValue, IJqlField<ParentExpression>
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(ParentField left, ParentExpression right) => left.Equal(right);
    public static Bool operator !=(ParentField left, ParentExpression right) => left.NotEqual(right);

    public static Bool operator ==(ParentExpression left, ParentField right) => right.Equal(left);
    public static Bool operator !=(ParentExpression left, ParentField right) => right.NotEqual(left);
}

public class ParentExpression : JqlValue, IJqlMembership<ParentExpression>
{
    public static implicit operator ParentExpression(string value) => new() { Value = new Field(value) };
    public static implicit operator ParentExpression(int value) => new() { Value = value };
}