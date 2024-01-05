namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;

public class DateOnly
{
    public DateFunctions<DateExpression> Functions { get; } = new();

    public DateField this[string field] => Field.Custom<DateField>(field);
    public DateField this[int field] => Field.Custom<DateField>(JqlKeywords.Custom(field));

    public DateField DueDate { get; } = Field.Custom<DateField>(JqlKeywords.DueDate);
    public DateField Due { get; } = Field.Custom<DateField>(JqlKeywords.Due);
}