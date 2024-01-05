namespace JQLBuilder.Facade;

using Types;

public class Ordering
{
    public static Ordering All { get; } = new();

    public Project Project { get; } = new();

    public OrderingVersion Version { get; } = new();
}