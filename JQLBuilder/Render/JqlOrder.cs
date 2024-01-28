namespace JQLBuilder.Render;

using System.Text;
using Constants;
using Enums;
using Infrastructure.Abstract;
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

            builder.Append(Keywords.OrderBy).Append(' ');
        }

        for (var index = 0; index < Orderings.Count; index++)
        {
            var (value, direction) = Orderings[index];

            value.Render(new(builder));
            builder.Append(' ');
            builder.Append(direction switch
            {
                Order.Ascending => Keywords.Ascending,
                Order.Descending => Keywords.Descending,
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