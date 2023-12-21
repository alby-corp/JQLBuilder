namespace JQLBuilder.Renders;

using System.Text;
using Types.Abstract;
using Types.Enum;
using Types.Primitive;

internal class JqlTypeRenderer(StringBuilder builder) : IJqlTypeRender
{
    public void Field(string value) => builder.Append(value);

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
        if (direction == Direction.Prefix)
        {
            builder.Append(name).Append('(');
            left.Render(this);
            builder.Append(')');
        }
        else
        {
            builder.Append('(');
            left.Render(this);
            builder.Append(')').Append(' ').Append(name);
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

    public override string ToString() => builder.ToString();
}