namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Issue : IssueField
{
    public Issue() => Value = new Field(Fields.Issue);
    public IssueField this[string field] => Field.Custom<IssueField>(field);
    public IssueField this[int field] => Field.Custom<IssueField>(Fields.Custom(field));

    public IssueField IssueKey { get; } = Field.Custom<IssueField>(Fields.IssueKey);
    public IssueField Id { get; } = Field.Custom<IssueField>(Fields.Id);
    public IssueField Key { get; } = Field.Custom<IssueField>(Fields.Key);
    public ParentField Parent { get; } = Field.Custom<ParentField>(Fields.Parent);
    public TypeField IssueType { get; } = Field.Custom<TypeField>(Fields.IssueType);
    public TypeField Type { get; } = Field.Custom<TypeField>(Fields.Type);
    public EpicLinkField EpicLink { get; } = Field.Custom<EpicLinkField>(Fields.EpicLink);
}

public class OrderingIssue : IssueField
{
    public OrderingIssue() => Value = new Field(Fields.Issue);

    public IssueField IssueKey { get; } = Field.Custom<IssueField>(Fields.IssueKey);
    public IssueField Id { get; } = Field.Custom<IssueField>(Fields.Id);
    public IssueField Key { get; } = Field.Custom<IssueField>(Fields.Key);
    public TypeField IssueType { get; } = Field.Custom<TypeField>(Fields.IssueType);
    public TypeField Type { get; } = Field.Custom<TypeField>(Fields.Type);
    public EpicLinkField EpicLink { get; } = Field.Custom<EpicLinkField>(Fields.EpicLink);
}