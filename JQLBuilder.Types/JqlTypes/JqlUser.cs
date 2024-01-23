namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class UserField : JqlValue, IJqlField<UserExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(UserField left, UserExpression right) => left.Equal(right);
    public static Bool operator !=(UserField left, UserExpression right) => left.NotEqual(right);
    public static Bool operator ==(UserExpression left, UserField right) => right.Equal(left);
    public static Bool operator !=(UserExpression left, UserField right) => right.NotEqual(left);
}

public class UserExpression : JqlValue, IJqlMembership<UserExpression>
{
    public static implicit operator UserExpression(string value) => new() { Value = value };
    public static implicit operator UserExpression(int value) => new() { Value = value };
}