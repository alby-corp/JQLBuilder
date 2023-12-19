namespace AlbyCorp.JQLBuilder.Types;

using Abstract;

public class String(object value) : JqlValue(value), IJqlType, IJqlType.IEquatable<String>
{
    public static Bool operator ==(String left, String right) => JqlType.Equals(left, right);
    public static Bool operator !=(String left, String right) => JqlType.NotEquals(left, right);

    public static implicit operator String(string value) => new String(value);
}