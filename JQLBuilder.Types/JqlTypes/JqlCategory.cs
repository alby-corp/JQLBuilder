namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class CategoryField: JqlValue, IJqlField<CategoryExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(CategoryField left, ProjectExpression right) => left.Equal(right);
    public static Bool operator !=(CategoryField left, ProjectExpression right) => left.NotEqual(right);

    public static Bool operator ==(CategoryExpression left, CategoryField right) => right.Equal(left);
    public static Bool operator !=(CategoryExpression left, CategoryField right) => right.NotEqual(left);
}

public class CategoryExpression : JqlValue, IJqlMembership<CategoryExpression>
{
    public static implicit operator CategoryExpression(string value) => new() { Value = value };
    public static implicit operator CategoryExpression(int value) => new() { Value = value };
}