namespace AlbyCorp.JQLBuilder.Renders;

using System.Text;
using Enums;
using Types;

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

    public void Operator(IJqlType left, string name, IJqlType right, Priority priority)
    {
        var render = right is JqlType.Operator o && o.Priority <= priority;
        
        left.Render(this);
        builder.Append(' ');
        builder.Append(name);
        builder.Append(' ');
        if(render) builder.Append('(');
        right.Render(this);
        if(render) builder.Append(')');
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