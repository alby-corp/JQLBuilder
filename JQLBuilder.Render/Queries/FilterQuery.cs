namespace JQLBuilder.Render.Queries;

using System.Text;
using Infrastructure.Operators;

public class FilterQuery(Bool? filter)
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