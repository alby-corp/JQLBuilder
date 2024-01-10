namespace JQLBuilder;

using Types.Functions;
using Types.JqlTypes;

public static class Functions
{
    public static DateFunctions<DateExpression> DateOnly { get; } = new();
    public static DateFunctions<DateTimeExpression> DateTime { get; } = new();
    public static ProjectFunctions Project { get; } = new();
    public static VersionFunctions Version { get; } = new();
}