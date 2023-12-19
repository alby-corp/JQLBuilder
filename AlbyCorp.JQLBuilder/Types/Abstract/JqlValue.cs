namespace AlbyCorp.JQLBuilder.Types.Abstract;

public abstract class JqlValue(object value)
{
    internal object Value { get; } = value;
}