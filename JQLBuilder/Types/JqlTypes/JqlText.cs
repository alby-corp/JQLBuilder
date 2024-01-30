namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class TextField : JqlValue, IJqlField<JqlText>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(TextField left, JqlText right) => left.Equal(right);
    public static Bool operator !=(TextField left, JqlText right) => left.NotEqual(right);
    public static Bool operator ==(JqlText left, TextField right) => right.Equal(left);
    public static Bool operator !=(JqlText left, TextField right) => right.NotEqual(left);
}

public class JqlText : JqlValue, IJqlMembership<JqlText>, IJqlContains<JqlText>
{
    public static implicit operator JqlText(string value) => new() { Value = value };
}