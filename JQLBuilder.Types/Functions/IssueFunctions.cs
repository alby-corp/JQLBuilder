namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;
using Constants;

public class IssueFunctions
{
    public IJqlCollection<IssueExpression> History => Field.Custom<JqlCollection<IssueExpression>>(Functions.History);
    public IJqlCollection<IssueExpression> Voted => Field.Custom<JqlCollection<IssueExpression>>(Functions.VotedIssues);
    public IJqlCollection<IssueExpression> Watched => Field.Custom<JqlCollection<IssueExpression>>(Functions.WatchedIssues);
    public IJqlCollection<IssueExpression> Linked(string key, string? caseSensitiveLinkType = default) => Field.Custom<JqlCollection<IssueExpression>>(Functions.Linked(key, caseSensitiveLinkType));
}