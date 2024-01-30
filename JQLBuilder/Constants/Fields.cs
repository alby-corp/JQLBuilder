namespace JQLBuilder.Constants;

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
    internal const string IssueLink = "issueLink";
    internal const string IssueLinkType = "IssueLinkType";
    internal const string Id = "id";
    internal const string Issue = "issue";
    internal const string Status = "status";
    internal const string Creator = "creator";
    internal const string Reporter = "reporter";
    internal const string Assignee = "assignee";
    internal const string Voter = "voter";
    internal const string Watcher = "watcher";
    internal const string Sprint = "sprint";
    internal const string Component = "component";
    internal const string Labels = "labels";
    internal const string Text = "text";
    internal const string Description = "description";
    internal const string Comment = "comment";
    internal const string Environment = "environment";
    internal const string Created = "created";
    internal const string Updated = "updated";
    internal const string CreatedDate = "createdDate";
    internal const string UpdatedDate = "updatedDate";
    internal const string Resolved = "resolved";
    internal const string ResolutionDate = "resolutionDate ";
    internal const string LastViewed = "lastViewed";
    internal const string Votes = "votes";
    internal const string Watchers = "watchers";
    internal const string HierarchicalLevel = "hierarchicalLevel";
    internal const string ProjectType = "projectType";
    internal const string EpicLink = "Epic Link";
    internal const string Filter = "filter";
    internal const string Request = "request";
    internal const string SavedFilter = "savedFilter";
    internal const string SearchRequest = "searchRequest";

    internal static string Custom(int id) => $"cf[{id}]";
}