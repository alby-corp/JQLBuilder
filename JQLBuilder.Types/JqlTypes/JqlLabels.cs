namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class LabelsField : JqlValue, IJqlField<LabelsExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(LabelsField left, LabelsExpression right) => left.Equal(right);
    public static Bool operator !=(LabelsField left, LabelsExpression right) => left.NotEqual(right);

    public static Bool operator ==(LabelsExpression left, LabelsField right) => right.Equal(left);
    public static Bool operator !=(LabelsExpression left, LabelsField right) => right.NotEqual(left);
}

public class LabelsExpression : JqlValue, IJqlMembership<LabelsExpression>
{
    public static implicit operator LabelsExpression(string value) => new() { Value = new Field(value) };
    public static implicit operator LabelsExpression(int value) => new() { Value = value };
}