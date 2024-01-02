namespace JQLBuilder.Fields.BuildIn;

using Types.Abstract;
using Types.Custom;
using Types.Primitive;

public class BuildInDate<T> where T : JqlValue, new()
{
    internal static BuildInDate<T> Date { get; } = new();
    
    public T Now => Field.Custom<T>("now()");
    public T CurrentLogin => Field.Custom<T>("currentLogin()");
    public T LastLogin => Field.Custom<T>("lastLogin()");
    public T StartOfDay(int value) => Field.Custom<T>("startOfDay(${value})");
    public T StartOfWeek(int value) => Field.Custom<T>($"startOfWeek({value})");
    public T StartOfMonth(int value) => Field.Custom<T>($"startOfMonth({value})");
    public T StartOfYear(int value) => Field.Custom<T>($"startOfYear({value})");
    public T EndOfDay(int value) => Field.Custom<T>($"endOfDay({value})");
    public T EndOfWeek(int value) => Field.Custom<T>($"endOfWeek({value})");
    public T EndOfMonth(int value) => Field.Custom<T>($"endOfMonth({value})");
    public T EndOfYear(int value) => Field.Custom<T>($"endOfYear({value})");
}

public static class Date
{
    public static readonly BuildInDate<DateExpression> DateOnly = BuildInDate<DateExpression>.Date;
    public static readonly BuildInDate<DateTimeExpression> DateTime = BuildInDate<DateTimeExpression>.Date;
}