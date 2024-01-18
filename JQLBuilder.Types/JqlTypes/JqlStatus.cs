namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class StatusField : JqlValue, IJqlField<StatusExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(StatusField left, StatusExpression right) => left.Equal(right);

    public static Bool operator !=(StatusField left, StatusExpression right) => left.NotEqual(right);

    public static Bool operator ==(StatusExpression left, StatusField right) => right.Equal(left);

    public static Bool operator !=(StatusExpression left, StatusField right) => right.NotEqual(left);
}

public class StatusExpression : JqlValue, IJqlMembership<StatusExpression>, IJqlHistorical<StatusExpression>
{
    public static implicit operator StatusExpression(string value) => new() { Value = new Field(value) };
    public static implicit operator StatusExpression(int value) => new() { Value = new Field($"{value}") };
}