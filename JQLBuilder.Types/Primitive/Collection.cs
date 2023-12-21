namespace JQLBuilder.Types.Primitive;

using Abstract;

public class JqlCollection<T> : IJqlValue, IJqlCollection<T> where T : IJqlType
{
    public required object Value { get; init; }
}