namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;

public class Project : ProjectField
{
    public Project() => Value = new Field(JqlKeywords.Project);

    public ProjectFunctions Functions { get; } = new();
}

public class OrderingProject : ProjectField
{
    public OrderingProject() => Value = new Field(JqlKeywords.Project);
}