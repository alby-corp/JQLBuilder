namespace JQLBuilder.Render.Renders;

using System.Text;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal class JqlTypeRenderer(StringBuilder builder)
{
    public void Field(Field field)
    {
        var (value, arguments) = field;

        if (value.Contains(' '))
            builder.Append('"').Append(value).Append('"');
        else
            builder.Append(value);

        if (arguments.Count <= 0) return;
        
        builder.Append('[');

        for (var index = 0; index < arguments.Count; index++)
        {
            arguments[index].Render(this);

            if (index < arguments.Count - 1) builder.Append(", ");
        }

        builder.Append(']');
    }

    public void Function(Function function)
    {
        var (name, arguments) = function;

        builder.Append(name).Append('(');

        for (var index = 0; index < arguments.Count; index++)
        {
            var value = arguments[index];
            value.Render(this);

            if (index < arguments.Count - 1) builder.Append(", ");
        }

        builder.Append(')');
    }

    public void String(string value) => builder.Append('"').Append(value).Append('"');

    public void Number(int value) => builder.Append(value);

    public void Issue(Issue value) => builder.Append(value.Key);

    public void Bool(bool value) => builder.Append(value ? "true" : "false");

    public void BinaryOperator(BinaryOperator @operator)
    {
        var (left, name, right, priority) = @operator;

        left.Render(this);
        builder.Append(' ').Append(name).Append(' ');

        if (right is BinaryOperator o && o.Priority <= priority)
        {
            builder.Append('(');
            right.Render(this);
            builder.Append(')');
        }
        else
            right.Render(this);
    }

    public void UnaryOperator(UnaryOperator @operator)
    {
        var (name, left, direction) = @operator;

        if (left is BinaryOperator ||
            (direction == Direction.Suffix && left is UnaryOperator { Direction: Direction.Prefix }))
        {
            if (direction == Direction.Prefix) builder.Append(name);
            builder.Append('(');

            left.Render(this);

            builder.Append(')');
            if (direction == Direction.Suffix) builder.Append(' ').Append(name);
        }
        else
        {
            if (direction == Direction.Prefix) builder.Append(name).Append(' ');

            left.Render(this);

            if (direction == Direction.Suffix) builder.Append(' ').Append(name);
        }
    }

    public void Collection(IReadOnlyList<IJqlType> values)
    {
        builder.Append('(');

        for (var index = 0; index < values.Count; index++)
        {
            var value = values[index];
            value.Render(this);

            if (index < values.Count - 1) builder.Append(", ");
        }

        builder.Append(')');
    }

    public void DateTime(DateTime value) => builder.Append('"').Append($"{value:yyyy-MM-dd HH:mm}").Append('"');
    public void DateOnly(DateOnly value) => builder.Append('"').Append($"{value:yyyy-MM-dd}").Append('"');

    public void TimeOffset(TimeOffset value)
    {
        var years = value.Years != 0;
        var months = value.Months != 0;
        var weeks = value.Weeks != 0;
        var days = value.Days != 0;
        var hours = value.Hours != 0;
        var minutes = value.Minutes != 0;

        var complex = (years ? 1 : 0) + (months ? 1 : 0) + (weeks ? 1 : 0) + (days ? 1 : 0) + (hours ? 1 : 0) + (minutes ? 1 : 0) >= 2;

        if (complex) builder.Append('"');

        if (years) builder.Append(value.Years).Append("y ");
        if (months) builder.Append(value.Months).Append("M ");
        if (weeks) builder.Append(value.Weeks).Append("w ");
        if (days) builder.Append(value.Days).Append("d ");
        if (hours) builder.Append(value.Hours).Append("h ");
        if (minutes) builder.Append(value.Minutes).Append("m ");

        builder.Length--;

        if (complex) builder.Append('"');
    }

    public override string ToString() => builder.ToString();

    public void ChangeOperator(IReadOnlyList<ChangeOperator> readOnlyList)
    {
        for (var index = 0; index < readOnlyList.Count; index++)
        {
            var (name, value) = readOnlyList[index];
            builder.Append(name).Append(' ');
            value.Render(this);

            if (index < readOnlyList.Count - 1) builder.Append(' ');
        }
    }

    public void NoValueOperator(NoValueOperator @operator)
    {
        @operator.Field.Render(this);
        builder.Append(' ');
        builder.Append(@operator.Name).Append(' ');
        @operator.Value.Render(this);
    }

    public void Tuple(Tuple<IJqlType, IJqlType> tuple)
    {
        builder.Append('(');
        tuple.Item1.Render(this);
        builder.Append(", ");
        tuple.Item2.Render(this);
        builder.Append(')');
    }
}