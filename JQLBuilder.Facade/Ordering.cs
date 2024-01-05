namespace JQLBuilder.Facade;

public class Ordering
{
    public static Ordering All { get; } = new();

    public static string Project => "project";
    public static string Assignee => "assignee";
    public static string Version => "affectedVersion";
}