namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Project : ProjectField
{
    public Project() => Value = new Field(Fields.Project);
}

public class OrderingProject : ProjectField
{
    public OrderingProject() => Value = new Field(Fields.Project);
}