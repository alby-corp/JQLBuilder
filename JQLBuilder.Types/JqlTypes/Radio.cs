namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class RadioField : JqlValue, IJqlField<RadioExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(RadioField left, RadioExpression right) => left.Equal(right);

    public static Bool operator !=(RadioField left, RadioExpression right) => left.NotEqual(right);

    public static Bool operator ==(RadioExpression left, RadioField right) => right.Equal(left);

    public static Bool operator !=(RadioExpression left, RadioField right) => right.NotEqual(left);
}

public class RadioExpression : JqlValue, IJqlMembership<RadioExpression>
{
    public static implicit operator RadioExpression(string value) => new() { Value = value };
    public static implicit operator RadioExpression(int value) => new() { Value = value };
}