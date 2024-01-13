namespace JQLBuilder;

using Types;

public class Fields
{
    public static Fields All { get; } = new();

    public DateOnly DateOnly { get; } = new();
    public DateTime DateTime { get; } = new();

    public Text Text { get; } = new();

    public Number Number { get; } = new();

    public Project Project { get; } = new();

    public Version Version { get; } = new();

    public Attachment Attachment { get; } = new();

    public Category Category { get; } = new();

    public Priority Priority { get; } = new();
}