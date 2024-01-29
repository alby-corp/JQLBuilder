namespace JQLBuilder;

using Types;

public class Fields
{
    public static Fields All { get; } = new();
    public Date Date { get; } = new();
    public Text Text { get; } = new();
    public Number Number { get; } = new();
    public Project Project { get; } = new();
    public Version Version { get; } = new();
    public Attachment Attachment { get; } = new();
    public Category Category { get; } = new();
    public Priority Priority { get; } = new();
    public Issue Issue { get; } = new();
    public Status Status { get; } = new();
    public User User { get; } = new();
    public Sprint Sprint { get; } = new();
    public Component Component { get; } = new();
    public Labels Labels { get; } = new();
    public Filter Filter { get; } = new();
    public InstanceFunctions Functions { get; } = new();
}