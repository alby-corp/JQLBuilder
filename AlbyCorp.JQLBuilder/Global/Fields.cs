// ReSharper disable CheckNamespace

namespace AlbyCorp.JQLBuilder.Global;

using Types;
using Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new Fields();

    public Project Project { get; } = new Project { Value = new Field("project") };
    public Version Version { get; } = new Version { Value = new Field("version") };
}