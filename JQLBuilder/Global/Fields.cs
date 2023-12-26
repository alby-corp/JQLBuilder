namespace JQLBuilder.Global;

using Types;
using Types.Abstract;
using Types.Custom;
using Types.Primitive;

public class Fields
{
    public static Fields All { get; } = new();

    public Project Project { get; } = new() { Value = new Field("project") };

    public Version Version { get; } = Custom<Version>("affectedVersion");
    public Date Date(string field) => Custom<Date>(field);
    public Date Now() => Custom<Date>("now()"); 
    public Date CurrentLogin() => Custom<Date>("currentLogin()"); 
    public Date LastLogin() => Custom<Date>("lastLogin()"); 
    public Date StartOfDay(int value) => Custom<Date>("startOfDay(${value})");
    public Date StartOfWeek(int value) => Custom<Date>($"startOfWeek({value})");
    public Date StartOfMonth(int value) => Custom<Date>($"startOfMonth({value})");
    public Date StartOfYear(int value) => Custom<Date>($"startOfYear({value})");
    public Date EndOfDay(int value) => Custom<Date>($"endOfDay({value})");
    public Date EndOfWeek(int value) => Custom<Date>($"endOfWeek({value})");
    public Date EndOfMonth(int value) => Custom<Date>($"endOfMonth({value})");
    public Date EndOfYear(int value) => Custom<Date>($"endOfYear({value})");
    
    public static T Custom<T>(string field) where T : JqlValue, new() => new()
    {
        Value = new Field(field)
    };
}