namespace JQLBuilder.Fields;

using Infrastructure;
using Types.Functions;
using Types.JqlTypes;

public class Fields
{
    public static Fields All { get; } = new();

    #region Custom

    public CustomFields Custom { get; } = new();

    public DateFunctions<DateExpression> DateOnly { get; } = Date.Only;
    public DateFunctions<DateTimeExpression> DateTime { get; } =  Date.Time;
    
    public BuildInPicker Picker { get; } = new();

    #endregion

    #region Standard

    public DateField DueDate { get; } = Field.Custom<DateField>("dueDate");
    public DateField Due { get; } = Field.Custom<DateField>("due");

    public BuildInProjects Projects { get; } = new();
    public ProjectField Project { get; } = Field.Custom<ProjectField>("project");

    public BuildInVersions BuildInVersions { get; } = new();
    public VersionField FixVersion { get; } = Field.Custom<VersionField>("fixVersion");
    public VersionField AffectedVersion { get; } = Field.Custom<VersionField>("affectedVersion");

    #endregion
}