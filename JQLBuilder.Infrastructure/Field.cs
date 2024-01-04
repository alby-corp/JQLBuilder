namespace JQLBuilder.Infrastructure;

using Abstract;

public record Field(string Value) : IJqlType
{
    public static T Custom<T>(string field) where T : JqlValue, new() => new()
    {
        Value = new Field(field)
    };
}