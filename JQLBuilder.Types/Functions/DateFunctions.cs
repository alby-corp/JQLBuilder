namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using JqlTypes;

public class DateFunctions<T> where T : DateTimeExpression, new()
{
    public T Now => Function.Custom<T>(Functions.Now, []);
    public T CurrentLogin => Function.Custom<T>(Functions.CurrentLogin, []);
    public T LastLogin => Function.Custom<T>(Functions.LastLogin, []);
    public T StartOfDay(NumberArgument value) => Function.Custom<T>(Functions.StartOfDay, [value]);
    public T StartOfWeek(NumberArgument value) => Function.Custom<T>(Functions.StartOfWeek, [value]);
    public T StartOfMonth(NumberArgument value) => Function.Custom<T>(Functions.StartOfMonth, [value]);
    public T StartOfYear(NumberArgument value) => Function.Custom<T>(Functions.StartOfYear, [value]);
    public T EndOfDay(NumberArgument value) => Function.Custom<T>(Functions.EndOfDay, [value]);
    public T EndOfWeek(NumberArgument value) => Function.Custom<T>(Functions.EndOfWeek, [value]);
    public T EndOfMonth(NumberArgument value) => Function.Custom<T>(Functions.EndOfMonth, [value]);
    public T EndOfYear(NumberArgument value) => Function.Custom<T>(Functions.EndOfYear, [value]);
}
