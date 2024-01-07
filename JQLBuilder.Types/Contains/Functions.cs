namespace JQLBuilder.Types.Contains;

internal static class Functions
{
    #region Date

    internal const string Now = "now()";
    internal const string CurrentLogin = "currentLogin()";
    internal const string LastLogin = "lastLogin()";
    internal static string StartOfDay(int value) => $"startOfDay({value})";
    internal static string StartOfWeek(int value) => $"startOfWeek({value})";
    internal static string StartOfMonth(int value) => $"startOfMonth({value})";
    internal static string StartOfYear(int value) => $"startOfYear({value})";
    internal static string EndOfDay(int value) => $"endOfDay({value})";
    internal static string EndOfWeek(int value) => $"endOfWeek({value})";
    internal static string EndOfMonth(int value) => $"endOfMonth({value})";
    internal static string EndOfYear(int value) => $"endOfYear({value})";

    #endregion

    #region Project

    internal static string LeadByUser(string user) => $"""projectsLeadByUser("{user}")""";
    internal static string WhereUserHasPermission(string user) => $"""projectsWhereUserHasPermission("{user}")""";
    internal static string WhereUserHasRole(string user) => $"""projectsWhereUserHasRole("{user}")""";

    #endregion

    #region Version

    internal const string LatestReleased = "latestReleasedVersion()";
    internal const string LatestUnreleased = "latestUnreleasedVersion()";
    internal const string Released = "releasedVersions()";
    internal const string Unreleased = "unreleasedVersions()";

    #endregion
}