namespace JQLBuilder.Types.Functions;

using Infrastructure;

public class DateFunctions<T> where T : JqlDate, new()
{
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