namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class IssueFunctions
{
    public IJqlCollection<IssueExpression> History => Function.Custom<JqlCollection<IssueExpression>>(Functions.IssueHistory, []);
    public IJqlCollection<IssueExpression> Voted => Function.Custom<JqlCollection<IssueExpression>>(Functions.VotedIssues, []);
    public IJqlCollection<IssueExpression> Watched => Function.Custom<JqlCollection<IssueExpression>>(Functions.WatchedIssues, []);
    public IJqlCollection<IssueExpression> LinkedIssues(IssueArgument key, TextArgument? caseSensitiveLinkType = default) => Function.Custom<JqlCollection<IssueExpression>>(Functions.LinkedIssues, caseSensitiveLinkType is null ? [key] : [key, caseSensitiveLinkType]);
}
