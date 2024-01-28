namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class IssueType : TypeField
{
    public IssueType() => Value = new Field(Fields.Type);

    public TypeField Issue { get; } = Field.Custom<TypeField>(Fields.IssueType);
}

public class OrderingIssueType : TypeField
{
    public OrderingIssueType() => Value = new Field(Fields.Type);

    public TypeField Issue { get; } = Field.Custom<TypeField>(Fields.IssueType);
}