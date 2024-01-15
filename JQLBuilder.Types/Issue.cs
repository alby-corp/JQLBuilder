namespace JQLBuilder.Types;

using Constants;
using Functions;
using Infrastructure;
using JqlTypes;

public class Issue : IssueField
{
    public IssueFunctions Functions { get; } = new();
    
    public Issue() => Value = new Field(Fields.Issue);

    public IssueField IssueKey { get; } = Field.Custom<IssueField>(Fields.IssueKey);
    public IssueField Id { get; } = Field.Custom<IssueField>(Fields.Id);
    public IssueField Key { get; } = Field.Custom<IssueField>(Fields.Key);
}

public class OrderingIssue : IssueField
{
    public OrderingIssue() => Value = new Field(Fields.Issue);

    public IssueField IssueKey { get; } = Field.Custom<IssueField>(Fields.IssueKey);
    public IssueField Id { get; } = Field.Custom<IssueField>(Fields.Id);
    public IssueField Key { get; } = Field.Custom<IssueField>(Fields.Key);
}