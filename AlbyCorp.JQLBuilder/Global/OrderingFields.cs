namespace AlbyCorp.JQLBuilder.Global;

public class OrderingFields
{
    public static OrderingFields All { get; } = new OrderingFields();

    public string Project { get; } = "project";
    public string Assignee { get; } = "assignee";
}