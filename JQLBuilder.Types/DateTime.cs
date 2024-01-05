namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using JqlTypes;

public class DateTime
{
    public DateFunctions<DateTimeExpression> Functions { get; } = new();

    public DateTimeField this[string field] => Field.Custom<DateTimeField>(field);
    public DateTimeField this[int field] => Field.Custom<DateTimeField>($"cf[{field}]");
}