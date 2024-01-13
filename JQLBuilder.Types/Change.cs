namespace JQLBuilder.Types;

using Infrastructure;
using Infrastructure.Abstract;


public class Change<T> : JqlValue
    where T : IJqlType
{
    public Change(IReadOnlyList<ChangeOperator> operators)
    {
        Value = operators;
        Operators = operators;
    }

    public IReadOnlyList<ChangeOperator> Operators { get; }

    public Change<T> After<TDate>(TDate value)
        where TDate : JqlDate =>
        new([..Operators, new ChangeOperator("AFTER", value)]);

    public Change<T> Before<TDate>(TDate value)
        where TDate : JqlDate =>
        new([..Operators, new ChangeOperator("BEFORE", value)]);

    public Change<T> During<T1, T2>(T1 from, T2 to)
        where T1 : JqlDate
        where T2 : JqlDate =>
        new([..Operators, new ChangeOperator("DURING", new JqlRange<T1, T2>(from, to))]);
}
