namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Number
{
    public NumberField this[string field] => Field.Custom<NumberField>(field);
    public NumberField this[int field] => Field.Custom<NumberField>(Fields.Custom(field));
}