namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Priority : PriorityField
{
    public Priority() => Value = new Field(Fields.Priority);
}

public class OrderingPriority : ProjectField
{
    public OrderingPriority() => Value = new Field(Fields.Priority);
}