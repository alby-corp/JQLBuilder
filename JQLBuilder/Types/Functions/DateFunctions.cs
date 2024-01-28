namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using JqlArguments;
using JqlTypes;

public class DateFunctions<T> where T : JqlDateTime, new()
{
    public T Now => Function.Custom<T>(Functions.Now, []);
    public T CurrentLogin => Function.Custom<T>(Functions.CurrentLogin, []);
    public T LastLogin => Function.Custom<T>(Functions.LastLogin, []);
    public T StartOfDay(JqlArguments.Duration value) => Function.Custom<T>(Functions.StartOfDay, [value]);
    public T StartOfWeek(JqlArguments.Duration value) => Function.Custom<T>(Functions.StartOfWeek, [value]);
    public T StartOfMonth(JqlArguments.Duration value) => Function.Custom<T>(Functions.StartOfMonth, [value]);
    public T StartOfYear(JqlArguments.Duration value) => Function.Custom<T>(Functions.StartOfYear, [value]);
    public T EndOfDay(JqlArguments.Duration value) => Function.Custom<T>(Functions.EndOfDay, [value]);
    public T EndOfWeek(JqlArguments.Duration value) => Function.Custom<T>(Functions.EndOfWeek, [value]);
    public T EndOfMonth(JqlArguments.Duration value) => Function.Custom<T>(Functions.EndOfMonth, [value]);
    public T EndOfYear(JqlArguments.Duration value) => Function.Custom<T>(Functions.EndOfYear, [value]);
}