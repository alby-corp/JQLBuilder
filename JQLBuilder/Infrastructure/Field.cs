namespace JQLBuilder.Infrastructure;

using Abstract;

public record Field(string Value, IReadOnlyList<IJqlArgument> Arguments) : IJqlType
{
    public Field(string value) : this(value, [])
    {
    }

    public static T Custom<T>(string field, IReadOnlyList<IJqlArgument> arguments) where T : JqlValue, new() => new()
    {
        Value = new Field(field, arguments)
    };

    public static T Custom<T>(string field) where T : JqlValue, new() => Custom<T>(field, []);
}