namespace JQLBuilder.Global;

using Types.Custom;
using Types.Primitive;

public class CustomFields
{
        public CustomDate Date { get; } = new();
        
        public class CustomDate
        {
            public Date this[string field] => Field.Custom<Date>(field);
            public Date this[int field] => Field.Custom<Date>($"cf[{field}]");
        }
}