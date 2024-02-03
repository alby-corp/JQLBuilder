namespace JQLBuilder;

using Types;

public class Ordering
{
    public static Ordering All { get; } = new();
    public OrderingProject Project { get; } = new();
    public OrderingVersion Version { get; } = new();
    public OrderingPriority Priority { get; } = new();
    public OrderingIssueType IssueType { get; } = new();
    public OrderingIssue Issue { get; } = new();
    public OrderingStatus Status { get; } = new();
    public OrderingUser User { get; } = new();
    public OrderingSprint Sprint { get; } = new();
    public OrderingComponent Component { get; } = new();
    public OrderingLabels Labels { get; } = new();
    public OrderingTimeTracking TimeTracking { get; } = new();
}