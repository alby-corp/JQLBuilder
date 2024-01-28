namespace JQLBuilder.Render;

using System.Text;
using Infrastructure.Operators;
using Renders;

public class JqlFilter(Bool? query)
{
    internal Bool? Query { get; } = query;

    internal void Build(StringBuilder builder)
    {
        var renderer = new JqlTypeRenderer(builder);
        Query?.Render(renderer);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        Build(builder);
        return builder.ToString();
    }
}