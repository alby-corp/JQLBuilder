namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Component : ComponentField
{
    public Component() => Value = new Field(Fields.Component);
}

public class OrderingComponent : ComponentField
{
    public OrderingComponent() => Value = new Field(Fields.Component);
}