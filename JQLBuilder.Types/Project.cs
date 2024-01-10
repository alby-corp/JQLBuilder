namespace JQLBuilder.Types;

using Constants;
using Functions;
using Infrastructure;
using JqlTypes;

public class Project : ProjectField
{
    public Project() => Value = new Field(Fields.Project);

    public ProjectFunctions Functions { get; } = new();
}

public class OrderingProject : ProjectField
{
    public OrderingProject() => Value = new Field(Fields.Project);
}