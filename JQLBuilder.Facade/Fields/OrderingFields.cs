namespace JQLBuilder.Facade.Fields;

public class OrderingFields
{
    public static OrderingFields All { get; } = new();

    public static string Project => "project";
    public static string Assignee => "assignee";
    public static string Version => "affectedVersion";
}