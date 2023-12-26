namespace JQLBuilder.Types.Custom;

using Abstract;
using Support;
using Primitive;

#pragma warning disable CS0660, CS0661
public class Select: JqlValue, IJqlMembership<Select>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(Select left, Select right) => left.Equal(right);
    public static Bool operator !=(Select left, Select right) => left.NotEqual(right);
}