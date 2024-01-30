namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using JqlArguments;

#pragma warning disable CS0660, CS0661
public class IssueField : JqlValue, IJqlField<JqlIssue>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(IssueField left, JqlIssue right) => left.Equal(right);
    public static Bool operator !=(IssueField left, JqlIssue right) => left.NotEqual(right);
    public static Bool operator >(IssueField left, JqlIssue right) => left.GreaterThan(right);
    public static Bool operator >=(IssueField left, JqlIssue right) => left.GreaterThanOrEqual(right);
    public static Bool operator <(IssueField left, JqlIssue right) => left.LessThan(right);
    public static Bool operator <=(IssueField left, JqlIssue right) => left.LessThanOrEqual(right);
    public static Bool operator ==(JqlIssue left, IssueField right) => right.Equal(left);
    public static Bool operator !=(JqlIssue left, IssueField right) => right.NotEqual(left);
    public static Bool operator >(JqlIssue left, IssueField right) => right.LessThan(left);
    public static Bool operator >=(JqlIssue left, IssueField right) => right.LessThanOrEqual(left);
    public static Bool operator <(JqlIssue left, IssueField right) => right.GreaterThan(left);
    public static Bool operator <=(JqlIssue left, IssueField right) => right.GreaterThanOrEqual(left);
}

public class JqlIssue : JqlEpicLink, IJqlMembership<JqlIssue>
{
    public static implicit operator JqlIssue(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlIssue(int value) => new() { Value = value };
}

public class IssueLinkField : IssueField
{
    public IssueField this[JqlArguments.Text linkType] => Field.Custom<IssueField>(Fields.IssueLink, [linkType]);
}