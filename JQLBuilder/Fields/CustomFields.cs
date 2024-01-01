namespace JQLBuilder.Fields;

using Types.Custom;
using Types.Primitive;

public class CustomFields
{
    public CustomDate Date { get; } = new();
    public CustomDateTime DateTime { get; } = new();
    public CustomNumber Number { get; } = new();

    public class CustomDate
    {
        public DateField this[string field] => Field.Custom<DateField>(field);
        public DateField this[int field] => Field.Custom<DateField>($"cf[{field}]");
    }
    
    public class CustomDateTime
    {
        public DateTimeField this[string field] => Field.Custom<DateTimeField>(field);
        public DateTimeField this[int field] => Field.Custom<DateTimeField>($"cf[{field}]");
    }
    
    public class CustomNumber
    {
        public NumberField this[string field] => Field.Custom<NumberField>(field);
        public NumberField this[int field] => Field.Custom<NumberField>($"cf[{field}]");
    }
    
public class CustomPicker
    {
        public PickerField this[string field] => Field.Custom<PickerField>(field);
        public PickerField this[int field] => Field.Custom<PickerField>($"cf[{field}]");
    }
}