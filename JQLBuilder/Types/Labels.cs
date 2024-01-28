namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Labels : LabelsField
{
    public Labels() => Value = new Field(Fields.Labels);
}

public class OrderingLabels : LabelsField
{
    public OrderingLabels() => Value = new Field(Fields.Labels);
}