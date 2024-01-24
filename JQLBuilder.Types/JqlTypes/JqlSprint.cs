namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class SprintField : JqlValue, IJqlField<SprintExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(SprintField left, SprintExpression right) => left.Equal(right);

    public static Bool operator !=(SprintField left, SprintExpression right) => left.NotEqual(right);

    public static Bool operator ==(SprintExpression left, SprintField right) => right.Equal(left);

    public static Bool operator !=(SprintExpression left, SprintField right) => right.NotEqual(left);
}

public class SprintExpression : JqlValue, IJqlMembership<SprintExpression>, IJqlHistorical<SprintExpression>
{
    public static implicit operator SprintExpression(string value) => new() { Value = new Field(value) };
    public static implicit operator SprintExpression(int value) => new() { Value = value };
}