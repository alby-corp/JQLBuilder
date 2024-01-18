namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using JqlTypes;

public class DateFunctions<T> where T : DateTimeExpression, new()
{
    public T Now => Function.Custom<T>(Functions.Now, []);
    public T CurrentLogin => Function.Custom<T>(Functions.CurrentLogin, []);
    public T LastLogin => Function.Custom<T>(Functions.LastLogin, []);
    public T StartOfDay(DurationArgument value) => Function.Custom<T>(Functions.StartOfDay, [value]);
    public T StartOfWeek(DurationArgument value) => Function.Custom<T>(Functions.StartOfWeek, [value]);
    public T StartOfMonth(DurationArgument value) => Function.Custom<T>(Functions.StartOfMonth, [value]);
    public T StartOfYear(DurationArgument value) => Function.Custom<T>(Functions.StartOfYear, [value]);
    public T EndOfDay(DurationArgument value) => Function.Custom<T>(Functions.EndOfDay, [value]);
    public T EndOfWeek(DurationArgument value) => Function.Custom<T>(Functions.EndOfWeek, [value]);
    public T EndOfMonth(DurationArgument value) => Function.Custom<T>(Functions.EndOfMonth, [value]);
    public T EndOfYear(DurationArgument value) => Function.Custom<T>(Functions.EndOfYear, [value]);
}
