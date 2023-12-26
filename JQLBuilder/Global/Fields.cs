namespace JQLBuilder.Global;

using Types;
using Types.Abstract;
using Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new();

    public Project Project { get; } = new() { Value = new Field("project") };

    public Version Version { get; } = Custom<Version>("affectedVersion");
    
    public static T Custom<T>(string field) where T : JqlValue, new() => new()
    {
        Value = new Field(field)
    };
}