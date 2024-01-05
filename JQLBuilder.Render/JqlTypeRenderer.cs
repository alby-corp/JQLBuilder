namespace JQLBuilder.Render;

using System.Text;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal class JqlTypeRenderer(StringBuilder builder)
{
    public void Field(string value)
    {
        if (value.Contains(' '))
            builder.Append('"').Append(value).Append('"');
        else
            builder.Append(value);
    }

    public void String(string value) => builder.Append('"').Append(value).Append('"');

    public void Number(int value) => builder.Append(value);

    public void Bool(bool value) => builder.Append(value ? "true" : "false");

    public void BinaryOperator(IJqlType left, string name, IJqlType right, Priority priority)
    {
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

    public void UnaryOperator(IJqlType left, string name, Direction direction)
    {
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
    public void DateOnly(DateTime value) => builder.Append('"').Append($"{value:yyyy-MM-dd}").Append('"');

    public override string ToString() => builder.ToString();
}