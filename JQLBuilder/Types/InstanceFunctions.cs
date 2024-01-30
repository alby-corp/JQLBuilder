namespace JQLBuilder.Types;

using Functions;

public class InstanceFunctions
{
    public DateFunctions Date { get; } = new();
    public ProjectFunctions Project { get; } = new();
    public VersionFunctions Version { get; } = new();
    public IssueFunctions Issues { get; } = new();
    public UserFunctions User { get; } = new();
    public SprintFunctions Sprint { get; } = new();
    public ComponentFunctions Component { get; } = new();
}