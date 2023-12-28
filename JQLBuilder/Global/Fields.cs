namespace JQLBuilder.Global;

using BuildIn;
using Types;
using Types.Custom;
using Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new();

    public Project Project { get; } = Field.Custom<Project>("project");

    public Version Version { get; } = Field.Custom<Version>("affectedVersion");
    
    public Date DueDate { get; } = Field.Custom<Date>("dueDate");
    
    public Date Due { get; } = Field.Custom<Date>("due");

    public CustomFields Custom { get; } = new();
    public BuildInDate Date { get; } = new();
    public BuildInVersion.Equality VersionBuildIn { get; } = new();
    public BuildInVersion.Membership MembershipVersionBuildIn { get; } = new();
}