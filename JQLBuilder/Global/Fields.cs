namespace JQLBuilder.Global;

using BuildIn;
using Types;
using Types.Custom;
using Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new();

    public CustomFields Custom { get; } = new();

    public Project Project { get; } = Field.Custom<Project>("project");

    
    public Date DueDate { get; } = Field.Custom<Date>("dueDate");
    
    public Date Due { get; } = Field.Custom<Date>("due");

    public BuildInDate Date { get; } = new();

    public Base.Version AffectedVersion { get; } = Field.Custom<Base.Version>("affectedVersion");
    public Base.Version FixVersion { get; } = Field.Custom<Base.Version>("fixVersion");
    public Versions Versions { get; } = new();
}