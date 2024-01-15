namespace JQLBuilder.Infrastructure;

using Abstract;

public class JqlValue : IJqlType
{
    internal object Value { get; init; } = null!;
}
