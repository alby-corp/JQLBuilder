namespace JQLBuilder.Global;

using Types;
using Types.Custom;
using Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new();

    public Project Project { get; } = Field.Custom<Project>("project");

    public Version Version { get; } = Field.Custom<Version>("affectedVersion");

    public CustomFields Custom { get; } = new();
}