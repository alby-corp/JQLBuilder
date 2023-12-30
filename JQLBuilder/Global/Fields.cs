namespace JQLBuilder.Global;

using BuildIn;
using Types;
using Types.Custom;
using Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new();

    public CustomFields Custom { get; } = new();

    public ProjectField Project { get; } = Field.Custom<ProjectField>("project");

    
    public DateField DueDate { get; } = Field.Custom<DateField>("dueDate");
    
    public DateField Due { get; } = Field.Custom<DateField>("due");

    public BuildInDate Date { get; } = new();

    public VersionField AffectedVersion { get; } = Field.Custom<VersionField>("affectedVersion");
    public VersionField FixVersion { get; } = Field.Custom<VersionField>("fixVersion");
    public Versions Versions { get; } = new();
}
