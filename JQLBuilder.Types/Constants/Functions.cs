namespace JQLBuilder.Types.Constants;

internal static class Functions
{
    #region Date

    internal const string Now = "now";
    internal const string CurrentLogin = "currentLogin";
    internal const string LastLogin = "lastLogin";
    internal const string StartOfDay = "startOfDay";
    internal const string StartOfWeek = "startOfWeek";
    internal const string StartOfMonth = "startOfMonth";
    internal const string StartOfYear = "startOfYear";
    internal const string EndOfDay = "endOfDay";
    internal const string EndOfWeek = "endOfWeek";
    internal const string EndOfMonth = "endOfMonth";
    internal const string EndOfYear = "endOfYear";

    #endregion

    #region Project

    internal const string LeadByUser = "projectsLeadByUser";

    internal const string WhereUserHasPermission = "projectsWhereUserHasPermission";
    internal const string WhereUserHasRole = "projectsWhereUserHasRole";

    #endregion

    #region Version

    internal const string LatestReleased = "latestReleasedVersion";
    internal const string LatestUnreleased = "latestUnreleasedVersion";
    internal const string Released = "releasedVersions";
    internal const string Unreleased = "unreleasedVersions";

    #endregion

    #region Issue

    internal const string History = "issueHistory";
    internal const string VotedIssues = "votedIssues";
    internal const string WatchedIssues = "watchedIssues";
    internal static string Linked = "linkedIssues";
    
    #endregion

    #region User

    internal const string MembersOf = "membersOf";
    internal const string CurrentUser = "currentUser";

    #endregion User
}
