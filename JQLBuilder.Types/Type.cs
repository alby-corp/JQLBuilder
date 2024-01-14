namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Type : TypeField
{
    public Type() => Value = new Field(Fields.Type);

    public VersionField Issue { get; } = Field.Custom<VersionField>(Fields.IssueType);
}

public class OrderingType : TypeField
{
    public OrderingType() => Value = new Field(Fields.Type);

    public VersionField Issue { get; } = Field.Custom<VersionField>(Fields.IssueType);
}