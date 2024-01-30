namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using JqlArguments;
using JqlTypes;

public class DateFunctions
{
    public JqlDate Now => Function.Custom<JqlDate>(Functions.Now, []);
    public JqlDate CurrentLogin => Function.Custom<JqlDate>(Functions.CurrentLogin, []);
    public JqlDate LastLogin => Function.Custom<JqlDate>(Functions.LastLogin, []);
    public JqlDate StartOfDay(JqlArguments.Duration value) => Function.Custom<JqlDate>(Functions.StartOfDay, [value]);
    public JqlDate StartOfWeek(JqlArguments.Duration value) => Function.Custom<JqlDate>(Functions.StartOfWeek, [value]);
    public JqlDate StartOfMonth(JqlArguments.Duration value) => Function.Custom<JqlDate>(Functions.StartOfMonth, [value]);
    public JqlDate StartOfYear(JqlArguments.Duration value) => Function.Custom<JqlDate>(Functions.StartOfYear, [value]);
    public JqlDate EndOfDay(JqlArguments.Duration value) => Function.Custom<JqlDate>(Functions.EndOfDay, [value]);
    public JqlDate EndOfWeek(JqlArguments.Duration value) => Function.Custom<JqlDate>(Functions.EndOfWeek, [value]);
    public JqlDate EndOfMonth(JqlArguments.Duration value) => Function.Custom<JqlDate>(Functions.EndOfMonth, [value]);
    public JqlDate EndOfYear(JqlArguments.Duration value) => Function.Custom<JqlDate>(Functions.EndOfYear, [value]);
}