namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class IssueField : JqlIssue, IJqlField<IssueExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(IssueField left, IssueExpression right) => left.Equal(right);

    public static Bool operator !=(IssueField left, IssueExpression right) => left.NotEqual(right);

    public static Bool operator >(IssueField left, IssueExpression right) => left.GreaterThan(right);

    public static Bool operator >=(IssueField left, IssueExpression right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(IssueField left, IssueExpression right) => left.LessThan(right);

    public static Bool operator <=(IssueField left, IssueExpression right) => left.LessThanOrEqual(right);

    public static Bool operator ==(IssueExpression left, IssueField right) => right.Equal(left);

    public static Bool operator !=(IssueExpression left, IssueField right) => right.NotEqual(left);

    public static Bool operator >(IssueExpression left, IssueField right) => right.LessThan(left);

    public static Bool operator >=(IssueExpression left, IssueField right) => right.LessThanOrEqual(left);

    public static Bool operator <(IssueExpression left, IssueField right) => right.GreaterThan(left);

    public static Bool operator <=(IssueExpression left, IssueField right) => right.GreaterThanOrEqual(left);
}

public class IssueExpression : JqlIssue, IJqlMembership<IssueExpression>
{
    public static implicit operator IssueExpression(string value) => new() { Value = new Field(value) };
    public static implicit operator IssueExpression(int value) => new() { Value = value };
}

