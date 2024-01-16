namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;

#pragma warning disable CS0660, CS0661
public class TextField : JqlValue, IJqlField<TextExpression>, IJqlNullable;
#pragma warning restore CS0660, CS0661

public class TextExpression : JqlValue, IJqlMembership<TextExpression>, IJqlContains<TextExpression>
{
    public static implicit operator TextExpression(string value) => new() { Value = value };
}

public class TextArgument : JqlValue, IJqlArgument
{
    public static implicit operator TextArgument(string value) => new() { Value = value };
}
