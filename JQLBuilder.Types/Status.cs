namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Status : StatusField
{
    public Status() => Value = new Field(Fields.Status);
}

public class OrderingStatus : ProjectField
{
    public OrderingStatus() => Value = new Field(Fields.Status);
}