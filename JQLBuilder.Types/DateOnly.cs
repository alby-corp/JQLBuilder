namespace JQLBuilder.Types;

using Constants;
using Functions;
using Infrastructure;
using JqlTypes;

public class DateOnly
{
    public DateFunctions<DateExpression> Functions { get; } = new();

    public DateField this[string field] => Field.Custom<DateField>(field);
    public DateField this[int field] => Field.Custom<DateField>(Fields.Custom(field));

    public DateField DueDate { get; } = Field.Custom<DateField>(Fields.DueDate);
    public DateField Due { get; } = Field.Custom<DateField>(Fields.Due);
}