namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class SelectField : JqlValue, IJqlField<SelectExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(SelectField left, SelectExpression right) => left.Equal(right);

    public static Bool operator !=(SelectField left, SelectExpression right) => left.NotEqual(right);

    public static Bool operator ==(SelectExpression left, SelectField right) => right.Equal(left);

    public static Bool operator !=(SelectExpression left, SelectField right) => right.NotEqual(left);
}

public class SelectExpression : JqlValue, IJqlMembership<SelectExpression>
{
    public static implicit operator SelectExpression(string value) => new() { Value = value };
    public static implicit operator SelectExpression(int value) => new() { Value = value };
}