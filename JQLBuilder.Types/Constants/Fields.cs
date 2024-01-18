namespace JQLBuilder.Types.Constants;

internal static class Fields
{
    internal const string Attachment = "attachments";
    internal const string Project = "project";
    internal const string FixVersion = "fixVersion";
    internal const string AffectedVersion = "affectedVersion";
    internal const string Due = "due";
    internal const string DueDate = "dueDate";
    internal const string Summary = "summary";
    internal const string Category = "category";
    internal const string Priority = "priority";
    internal const string Type = "type";
    internal const string IssueType = "issueType";
    internal const string Parent = "parent";
    internal const string Key = "key";
    internal const string IssueKey = "issueKey";
    internal const string Id = "id";
    internal const string Issue = "issue";
    internal const string Status = "status";
    internal static string Custom(int id) => $"cf[{id}]";
}