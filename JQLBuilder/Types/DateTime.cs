namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class DateTime
{
    public DateTimeField this[string field] => Field.Custom<DateTimeField>(field);
    public DateTimeField this[int field] => Field.Custom<DateTimeField>(Fields.Custom(field));
}