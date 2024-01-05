namespace JQLBuilder.Types;

using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;

public class Number
{
    public NumberField this[string field] => Field.Custom<NumberField>(field);
    public NumberField this[int field] => Field.Custom<NumberField>(JqlKeywords.Custom(field));
}