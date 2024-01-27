namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlArguments;
using JqlIssue = JqlTypes.JqlIssue;

public class IssueFunctions
{
    public IJqlCollection<JqlIssue> History => Function.Custom<JqlCollection<JqlIssue>>(Functions.IssueHistory, []);
    public IJqlCollection<JqlIssue> Voted => Function.Custom<JqlCollection<JqlIssue>>(Functions.VotedIssues, []);
    public IJqlCollection<JqlIssue> Watched => Function.Custom<JqlCollection<JqlIssue>>(Functions.WatchedIssues, []);
    public IJqlCollection<JqlIssue> LinkedIssues(JqlArguments.Special key) => Function.Custom<JqlCollection<JqlIssue>>(Functions.LinkedIssues, [key]);
    public IJqlCollection<JqlIssue> LinkedIssues(JqlArguments.Special key, JqlArguments.Text caseSensitiveLinkType) => Function.Custom<JqlCollection<JqlIssue>>(Functions.LinkedIssues, [key, caseSensitiveLinkType]);
}