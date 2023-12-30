namespace JQLBuilder.Global;

using Types.Custom;
using Types.Primitive;

public class CustomFields
{
    public CustomDate Date { get; } = new();

    public class CustomDate
    {
        public DateField this[string field] => Field.Custom<DateField>(field);
        public DateField this[int field] => Field.Custom<DateField>($"cf[{field}]");
    }
}
