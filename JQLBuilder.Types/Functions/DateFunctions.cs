namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using JqlTypes;

public class DateFunctions<T> where T : DateTimeExpression, new()
{
    public T Now => Field.Custom<T>(Functions.Now);
    public T CurrentLogin => Field.Custom<T>(Functions.CurrentLogin);
    public T LastLogin => Field.Custom<T>(Functions.LastLogin);
    public T StartOfDay(int value) => Field.Custom<T>(Functions.StartOfDay(value));
    public T StartOfWeek(int value) => Field.Custom<T>(Functions.StartOfWeek(value));
    public T StartOfMonth(int value) => Field.Custom<T>(Functions.StartOfMonth(value));
    public T StartOfYear(int value) => Field.Custom<T>(Functions.StartOfYear(value));
    public T EndOfDay(int value) => Field.Custom<T>(Functions.EndOfDay(value));
    public T EndOfWeek(int value) => Field.Custom<T>(Functions.EndOfWeek(value));
    public T EndOfMonth(int value) => Field.Custom<T>(Functions.EndOfMonth(value));
    public T EndOfYear(int value) => Field.Custom<T>(Functions.EndOfYear(value));
}
