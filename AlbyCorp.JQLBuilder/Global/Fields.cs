// ReSharper disable CheckNamespace

namespace AlbyCorp.JQLBuilder.Global;

using Types;

public class Fields
{
    public static Fields All { get; } = new Fields();

    public Project Project { get; } = new Project(new JqlType.Field("project"));
    public Version Version { get; } = new Version(new JqlType.Field("version"));
}