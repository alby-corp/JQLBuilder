namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;

public class HistoricalUserField : UserField;

public class HistoricalUserExpression: UserExpression, IJqlHistorical<HistoricalUserExpression>
{
    public static implicit operator HistoricalUserExpression(string value) => new() { Value = new Field(value) };
}