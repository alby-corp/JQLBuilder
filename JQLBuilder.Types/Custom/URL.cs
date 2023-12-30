namespace JQLBuilder.Types.Custom;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class Url : JqlValue, IJqlMembership<Url>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(Url left, Url right) => left.Equal(right);
    public static Bool operator !=(Url left, Url right) => left.NotEqual(right);
}