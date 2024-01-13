namespace JQLBuilder.Infrastructure;

using Abstract;

public record ChangeOperator(string Name, IJqlType Value);

public class JqlRange<T, T2> : JqlValue
    where T : JqlDate
    where T2 : JqlDate
{
    public JqlRange(T from, T2 to)
    {
        Value = Tuple.Create<IJqlType, IJqlType>(from, to);
    }
}
