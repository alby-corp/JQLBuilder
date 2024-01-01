namespace JQLBuilder.Types.Custom;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class CheckboxField : JqlValue, IJqlField<CheckboxExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(CheckboxField left, CheckboxExpression right) => left.Equal(right);

    public static Bool operator !=(CheckboxField left, CheckboxExpression right) => left.NotEqual(right);

    public static Bool operator ==(CheckboxExpression left, CheckboxField right) => right.Equal(left);

    public static Bool operator !=(CheckboxExpression left, CheckboxField right) => right.NotEqual(left);
}

public class CheckboxExpression : JqlValue, IJqlMembership<CheckboxExpression>
{
    public static implicit operator CheckboxExpression(string value) => new() { Value = value };
    public static implicit operator CheckboxExpression(int value) => new() { Value = value };
}