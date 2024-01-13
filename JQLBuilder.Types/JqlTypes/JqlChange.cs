namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

public class JqlChange<T> : JqlValue where T : IJqlType
{
    public JqlChange(IReadOnlyList<ChangeOperator> operators)
    {
        Value = operators;
        Operators = operators;
    }

    IReadOnlyList<ChangeOperator> Operators { get; }

    public JqlChange<T> After<TDate>(TDate value)
        where TDate : JqlDate =>
        new([..Operators, new("AFTER", value)]);

    public JqlChange<T> Before<TDate>(TDate value)
        where TDate : JqlDate =>
        new([..Operators, new("BEFORE", value)]);

    public JqlChange<T> During<T1, T2>(T1 from, T2 to)
        where T1 : JqlDate
        where T2 : JqlDate =>
        new([..Operators, new("DURING", new JqlRange<T1, T2>(from, to))]);
}

public class JqlRange<T, T2> : JqlValue where T : JqlDate where T2 : JqlDate
{
    public JqlRange(T from, T2 to) => Value = Tuple.Create<IJqlType, IJqlType>(from, to);
}