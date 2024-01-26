namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;

#pragma warning disable CS0660, CS0661
public class TextField : JqlValue, IJqlField<JqlText>, IJqlNullable;
#pragma warning restore CS0660, CS0661

public class JqlText : JqlValue, IJqlMembership<JqlText>, IJqlContains<JqlText>
{
    public static implicit operator JqlText(string value) => new() { Value = value };
}