namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlArguments;
using JqlTypes;

public class IssueFunctions
{
    public IJqlCollection<IssueExpression> History => Function.Custom<JqlCollection<IssueExpression>>(Functions.IssueHistory, []);
    public IJqlCollection<IssueExpression> Voted => Function.Custom<JqlCollection<IssueExpression>>(Functions.VotedIssues, []);
    public IJqlCollection<IssueExpression> Watched => Function.Custom<JqlCollection<IssueExpression>>(Functions.WatchedIssues, []);
    public IJqlCollection<IssueExpression> LinkedIssues(JqlArguments.Special key) => Function.Custom<JqlCollection<IssueExpression>>(Functions.LinkedIssues, [key]);
    public IJqlCollection<IssueExpression> LinkedIssues(JqlArguments.Special key, JqlArguments.Text caseSensitiveLinkType) => Function.Custom<JqlCollection<IssueExpression>>(Functions.LinkedIssues, [key, caseSensitiveLinkType]);
}
