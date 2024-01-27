namespace JQLBuilder.Types.JqlTypes;

using Constants;
using Infrastructure;

public class JqlNoValue : JqlValue
{
    internal JqlNoValue(string? noValue = default) => Value = new Field(noValue ?? Operators.Empty);
}

public class JqlNoValues
{
    public JqlNoValue Empty { get; } = new();
    public JqlNoValue Null { get; } = new(Operators.Null);
}