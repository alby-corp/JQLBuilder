namespace JQLBuilder.Infrastructure;

using Abstract;

public class JqlValue : IJqlType
{
    internal object Value { get; init; } = null!;
}

public abstract class JqlDate : JqlValue
{
    public class Only : JqlDate;

    public class Time : JqlDate;
}