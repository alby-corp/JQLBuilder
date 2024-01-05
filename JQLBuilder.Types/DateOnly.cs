namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using JqlTypes;

public class DateOnly
{
    public DateFunctions<DateExpression> Functions { get; } = new();

    public DateField this[string field] => Field.Custom<DateField>(field);
    public DateField this[int field] => Field.Custom<DateField>($"cf[{field}]");

    public DateField DueDate { get; } = Field.Custom<DateField>("dueDate");
    public DateField Due { get; } = Field.Custom<DateField>("due");
}