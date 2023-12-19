namespace AlbyCorp.JQLBuilder.Renders;

using System.Text;
using Types.Abstract;

internal class JqlTypeRenderer(StringBuilder builder) : IJqlTypeRender
{
    public void Field(string value) => builder.Append(value);

    public void String(string value)
    {
        builder.Append('"');
        builder.Append(value);
        builder.Append('"');
    }

    public void Bool(bool value)
        => builder.Append(value ? "true" : "false");

    public void Number(int value)
        => builder.Append(value);

    public void Operator(IJqlType left, string name, IJqlType right)
    {
        builder.Append('(');
        left.Render(this);
        builder.Append(' ');
        builder.Append(name);
        builder.Append(' ');
        right.Render(this);
        builder.Append(')');
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