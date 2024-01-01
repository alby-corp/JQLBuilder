namespace JQLBuilder.Types.Custom;

using Abstract;

#pragma warning disable CS0660, CS0661
public class TextField : JqlValue, IJqlField<TextExpression>, IJqlNullable;
#pragma warning restore CS0660, CS0661

public class TextExpression : JqlValue, IJqlMembership<TextExpression>, IJqlLike<TextExpression>
{
    public static implicit operator TextExpression(string value) => new() { Value = value };
    public static implicit operator TextExpression(int value) => new() { Value = value };
}