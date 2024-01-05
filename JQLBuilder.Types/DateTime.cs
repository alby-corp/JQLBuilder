namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;

public class DateTime
{
    public DateFunctions<DateTimeExpression> Functions { get; } = new();

    public DateTimeField this[string field] => Field.Custom<DateTimeField>(field);
    public DateTimeField this[int field] => Field.Custom<DateTimeField>(JqlKeywords.Custom(field));
}