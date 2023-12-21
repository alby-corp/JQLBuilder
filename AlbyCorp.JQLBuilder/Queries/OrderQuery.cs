namespace JQLBuilder.Queries;

using System.Text;
using Enums;

public class OrderQuery(FilterQuery? query, IReadOnlyList<(string Value, Order Order)> orderings)
{
    internal FilterQuery? Query { get; } = query;
    internal IReadOnlyList<(string Value, Order Order)> Orderings { get; } = orderings;

    void Build(StringBuilder builder)
    {
        if (Orderings.Count > 0)
        {
            if (Query is not null)
            {
                Query.Build(builder);
                builder.Append(' ');
            }

            builder.Append("order by ");
        }

        for (var index = 0; index < Orderings.Count; index++)
        {
            var (value, direction) = Orderings[index];

            builder.Append(value);
            builder.Append(' ');
            builder.Append(direction switch
            {
                Order.Ascending => "asc",
                Order.Descending => "desc",
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