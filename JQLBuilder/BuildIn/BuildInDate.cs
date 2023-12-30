namespace JQLBuilder.BuildIn;

using Types.Custom;
using Types.Primitive;

public class BuildInDate
{
    public  DateExpression Now => Field.Custom<DateExpression>("now()"); 
    public  DateExpression CurrentLogin => Field.Custom<DateExpression>("currentLogin()"); 
    public  DateExpression LastLogin => Field.Custom<DateExpression>("lastLogin()"); 
    public  DateExpression StartOfDay(int value) => Field.Custom<DateExpression>("startOfDay(${value})");
    public  DateExpression StartOfWeek(int value) => Field.Custom<DateExpression>($"startOfWeek({value})");
    public  DateExpression StartOfMonth(int value) => Field.Custom<DateExpression>($"startOfMonth({value})");
    public  DateExpression StartOfYear(int value) => Field.Custom<DateExpression>($"startOfYear({value})");
    public  DateExpression EndOfDay(int value) => Field.Custom<DateExpression>($"endOfDay({value})");
    public  DateExpression EndOfWeek(int value) => Field.Custom<DateExpression>($"endOfWeek({value})");
    public  DateExpression EndOfMonth(int value) => Field.Custom<DateExpression>($"endOfMonth({value})");
    public  DateExpression EndOfYear(int value) => Field.Custom<DateExpression>($"endOfYear({value})");   
}
