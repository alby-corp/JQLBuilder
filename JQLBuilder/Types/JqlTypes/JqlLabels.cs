namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class LabelsField : JqlValue, IJqlField<JqlLabels>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(LabelsField left, JqlLabels right) => left.Equal(right);
    public static Bool operator !=(LabelsField left, JqlLabels right) => left.NotEqual(right);
    public static Bool operator ==(JqlLabels left, LabelsField right) => right.Equal(left);
    public static Bool operator !=(JqlLabels left, LabelsField right) => right.NotEqual(left);
}

public class JqlLabels : JqlValue, IJqlMembership<JqlLabels>
{
    public static implicit operator JqlLabels(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlLabels(int value) => new() { Value = value };
}