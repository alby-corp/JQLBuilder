namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Constants;

public class DateFunctions<T> where T : JqlDate, new()
{
    public T Now => Field.Custom<T>(JqlKeywords.Now);
    public T CurrentLogin => Field.Custom<T>(JqlKeywords.CurrentLogin);
    public T LastLogin => Field.Custom<T>(JqlKeywords.LastLogin);
    public T StartOfDay(int value) => Field.Custom<T>(JqlKeywords.StartOfDay(value));
    public T StartOfWeek(int value) => Field.Custom<T>(JqlKeywords.StartOfWeek(value));
    public T StartOfMonth(int value) => Field.Custom<T>(JqlKeywords.StartOfMonth(value));
    public T StartOfYear(int value) => Field.Custom<T>(JqlKeywords.StartOfYear(value));
    public T EndOfDay(int value) => Field.Custom<T>(JqlKeywords.EndOfDay(value));
    public T EndOfWeek(int value) => Field.Custom<T>(JqlKeywords.EndOfWeek(value));
    public T EndOfMonth(int value) => Field.Custom<T>(JqlKeywords.EndOfMonth(value));
    public T EndOfYear(int value) => Field.Custom<T>(JqlKeywords.EndOfYear(value));
}