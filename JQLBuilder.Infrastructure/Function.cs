namespace JQLBuilder.Infrastructure;

using Abstract;

public record Function(string Name, IReadOnlyList<IJqlArgument> Arguments) : IJqlType
{
    public static T Custom<T>(string name, IReadOnlyList<IJqlArgument> arguments) where T : JqlValue, new() => new()
    {
        Value = new Function(name, arguments)
    };
}
