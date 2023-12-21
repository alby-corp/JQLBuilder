namespace JQLBuilder.Global;

using Types;
using Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new();

    public Project Project { get; } = new() { Value = new Field("project") };
    public Version Version { get; } = new() { Value = new Field("version") };
}