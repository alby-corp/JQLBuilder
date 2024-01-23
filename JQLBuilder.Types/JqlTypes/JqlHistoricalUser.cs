namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class HistoricalUserField : JqlValue, IJqlField<HistoricalUserExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(HistoricalUserField left, HistoricalUserExpression right) => left.Equal(right);
    public static Bool operator !=(HistoricalUserField left, HistoricalUserExpression right) => left.NotEqual(right);
    public static Bool operator ==(HistoricalUserExpression left, HistoricalUserField right) => right.Equal(left);
    public static Bool operator !=(HistoricalUserExpression left, HistoricalUserField right) => right.NotEqual(left);
}

public class HistoricalUserExpression: UserExpression, IJqlHistorical<HistoricalUserExpression>
{
    public static implicit operator HistoricalUserExpression(string value) => new() { Value = value };
    public static implicit operator HistoricalUserExpression(int value) => new() { Value = value };
}