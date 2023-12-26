namespace JQLBuilder.Types.Custom;

using Abstract;
using Support;
using Primitive;

#pragma warning disable CS0660, CS0661
public class Picker: JqlValue, IJqlMembership<Picker>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(Picker left, Picker right) => left.Equal(right);
    public static Bool operator !=(Picker left, Picker right) => left.NotEqual(right);
}