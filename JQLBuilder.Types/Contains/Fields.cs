namespace JQLBuilder.Types.Contains;

internal static class Fields
{
    internal const string Project = "project";
    internal const string FixVersion = "fixVersion";
    internal const string AffectedVersion = "affectedVersion";
    internal const string Due = "due";
    internal const string DueDate = "dueDate";
    internal static string Custom(int id) => $"cf[{id}]";
}