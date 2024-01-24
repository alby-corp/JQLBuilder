namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Sprint : SprintField
{
    public Sprint() => Value = new Field(Fields.Sprint);
}

public class OrderingSprint : SprintField
{
    public OrderingSprint() => Value = new Field(Fields.Sprint);
}