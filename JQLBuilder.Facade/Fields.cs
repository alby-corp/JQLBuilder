namespace JQLBuilder.Facade;

using Types;

public class Fields
{
    public static Fields All { get; } = new();

    public DateOnly DateOnly { get; } = new();
    public DateTime DateTime { get; } = new();

    public Text Text { get; } = new();

    public Number Number { get; } = new();

    public Projecto Project { get; } = new();

    public Version Version { get; } = new();
}