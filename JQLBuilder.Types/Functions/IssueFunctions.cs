namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class IssueFunctions
{
    public IJqlCollection<IssueExpression> History => Function.Custom<JqlCollection<IssueExpression>>(Functions.History, []);
    public IJqlCollection<IssueExpression> Voted => Function.Custom<JqlCollection<IssueExpression>>(Functions.VotedIssues, []);
    public IJqlCollection<IssueExpression> Watched => Function.Custom<JqlCollection<IssueExpression>>(Functions.WatchedIssues, []);

    public IJqlCollection<IssueExpression> Linked(TextArgument key, TextArgument? caseSensitiveLinkType = default) =>
        Function.Custom<JqlCollection<IssueExpression>>(Functions.Linked, caseSensitiveLinkType is null ? [key] : [key, caseSensitiveLinkType]);

    public IJqlCollection<IssueExpression> Linked(NumberArgument key, TextArgument? caseSensitiveLinkType = default) =>
        Function.Custom<JqlCollection<IssueExpression>>(Functions.Linked, caseSensitiveLinkType is null ? [key] : [key, caseSensitiveLinkType]);
}
