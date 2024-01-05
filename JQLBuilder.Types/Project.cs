namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using JqlTypes;

public class Project : ProjectField
{
    public Project() => Value = new Field("project");

    public ProjectFunctions Functions { get; } = new();
}

public class OrderingProject : ProjectField
{
    public OrderingProject() => Value = new Field("project");
}