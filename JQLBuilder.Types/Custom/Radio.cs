namespace JQLBuilder.Types.Custom;

using Abstract;
using Support;
using Primitive;

#pragma warning disable CS0660, CS0661
public class Radio: JqlValue, IJqlMembership<Radio>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(Radio left, Radio right) => left.Equal(right);
    public static Bool operator !=(Radio left, Radio right) => left.NotEqual(right);
}