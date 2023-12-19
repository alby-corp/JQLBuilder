namespace AlbyCorp.JQLBuilder.Queries;

using System.Text;
using Renders;
using Types;

public class Query(Bool? filter)
{
    internal Bool? Filter { get; } = filter;

    internal void Build(StringBuilder builder)
    {
        var renderer = new JqlTypeRenderer(builder);
        Filter?.Render(renderer);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        Build(builder);
        return builder.ToString();
    }
}