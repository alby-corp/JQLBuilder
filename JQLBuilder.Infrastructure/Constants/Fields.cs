namespace JQLBuilder.Infrastructure.Constants;

internal static partial class JqlKeywords
{
    internal const string Project = "project";
    internal const string FixVersion = "fixVersion";
    internal const string AffectedVersion = "affectedVersion";
    internal const string Due = "due";
    internal const string DueDate = "dueDate";
    internal static string Custom(int id) => $"cf[{id}]";
}