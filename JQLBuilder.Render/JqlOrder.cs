namespace JQLBuilder.Render;

using System.Text;
using Enums;
using Infrastructure.Abstract;
using Infrastructure.Constants;
using Renders;

public class JqlOrder(JqlFilter? query, IReadOnlyList<(IJqlType Value, Order Order)> orderings)
{
    internal JqlFilter? Query { get; } = query;
    internal IReadOnlyList<(IJqlType Value, Order Order)> Orderings { get; } = orderings;

    void Build(StringBuilder builder)
    {
        if (Orderings.Count > 0)
        {
            if (Query is not null)
            {
                Query.Build(builder);
                builder.Append(' ');
            }

            builder.Append(JqlKeywords.OrderBy).Append(' ');
        }

        for (var index = 0; index < Orderings.Count; index++)
        {
            var (value, direction) = Orderings[index];

            value.Render(new JqlTypeRenderer(builder));
            builder.Append(' ');
            builder.Append(direction switch
            {
                Order.Ascending => JqlKeywords.Ascending,
                Order.Descending => JqlKeywords.Descending,
                _ => string.Empty
            });

            if (index < Orderings.Count - 1) builder.Append(", ");
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        Build(builder);
        return builder.ToString();
    }
}