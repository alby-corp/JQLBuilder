namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class CategoryField : JqlValue, IJqlField<JqlCategory>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(CategoryField left, JqlCategory right) => left.Equal(right);
    public static Bool operator !=(CategoryField left, JqlCategory right) => left.NotEqual(right);
    public static Bool operator ==(JqlCategory left, CategoryField right) => right.Equal(left);
    public static Bool operator !=(JqlCategory left, CategoryField right) => right.NotEqual(left);
}

public class JqlCategory : JqlValue, IJqlMembership<JqlCategory>
{
    public static implicit operator JqlCategory(string value) => new() { Value = value };
    public static implicit operator JqlCategory(int value) => new() { Value = value };
}