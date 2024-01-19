namespace JQLBuilder;

using Types.Functions;
using Types.JqlTypes;

public static class Functions
{
    public static DateFunctions<DateExpression> Date { get; } = new();
    public static ProjectFunctions Project { get; } = new();
    public static VersionFunctions Version { get; } = new();
    
    public static IssueFunctions Issues { get; } = new();
    
    public static UserFunctions User { get; } = new();
}