namespace JQLBuilder.Types.Custom;

using Abstract;
using Support;
using Primitive;

#pragma warning disable CS0660, CS0661
public class Checkbox: JqlValue, IJqlMembership<Checkbox>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(Checkbox left, Checkbox right) => left.Equal(right);
    public static Bool operator !=(Checkbox left, Checkbox right) => left.NotEqual(right);
}