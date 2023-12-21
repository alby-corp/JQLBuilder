namespace JQLBuilder.Types.Primitive;

using Abstract;

public class JqlCollection<T>(object value) : IJqlValue, IJqlCollection<T> where T : IJqlType
{
    object IJqlValue.Value { get; init; } = value;
}