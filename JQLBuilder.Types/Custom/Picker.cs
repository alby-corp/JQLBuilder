namespace JQLBuilder.Types.Custom;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class PickerField : JqlValue, IJqlField<PickerExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(PickerField left, PickerExpression right) => left.Equal(right);

    public static Bool operator !=(PickerField left, PickerExpression right) => left.NotEqual(right);

    public static Bool operator ==(PickerExpression left, PickerField right) => right.Equal(left);

    public static Bool operator !=(PickerExpression left, PickerField right) => right.NotEqual(left);
}

public class PickerExpression : JqlValue, IJqlMembership<PickerExpression>
{
    public static implicit operator PickerExpression(string value) => new() { Value = value };
    public static implicit operator PickerExpression(int value) => new() { Value = value };
}