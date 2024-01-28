namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Project : ProjectField
{
    public Project() => Value = new Field(Fields.Project);
    
    public ProjectTypeField Type { get; } = Field.Custom<ProjectTypeField>(Fields.ProjectType);
}

public class OrderingProject : ProjectField
{
    public OrderingProject() => Value = new Field(Fields.Project);
}