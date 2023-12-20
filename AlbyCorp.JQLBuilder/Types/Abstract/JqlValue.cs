namespace AlbyCorp.JQLBuilder.Types;

public abstract class JqlValue(object value)
{
    internal object Value { get; } = value;
}