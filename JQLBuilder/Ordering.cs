namespace JQLBuilder;

using Types;

public class Ordering
{
    public static Ordering All { get; } = new();

    public OrderingProject Project { get; } = new();

    public OrderingVersion Version { get; } = new();
    
    public OrderingPriority Priority { get; } = new();

    public OrderingType Type { get; } = new();
    
    public OrderingIssue Issue { get; } = new();
}