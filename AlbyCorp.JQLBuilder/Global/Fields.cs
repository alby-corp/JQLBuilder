namespace JQLBuilder.Global;

using global::JqlBuilder.Types;
using global::JqlBuilder.Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new();

    public Project Project { get; } = new() { Value = new Field("project") };
    public Version Version { get; } = new() { Value = new Field("version") };
}