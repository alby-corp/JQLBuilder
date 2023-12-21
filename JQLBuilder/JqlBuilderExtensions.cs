namespace JQLBuilder;

using Enums;
using Global;
using Queries;
using Types.Primitive;

public static class JqlBuilderExtensions
{
    public static FilterQuery Where(this InitialQuery initialQuery, Func<Fields, Bool> filter) =>
        new(filter(Fields.All));

    public static FilterQuery And(this FilterQuery filterQuery, Func<Fields, Bool> filter)
        => filterQuery.Filter is null
            ? new FilterQuery(filter(Fields.All))
            : new FilterQuery(filterQuery.Filter & filter(Fields.All));

    public static FilterQuery Or(this FilterQuery filterQuery, Func<Fields, Bool> filter)
        => filterQuery.Filter is null
            ? new FilterQuery(filter(Fields.All))
            : new FilterQuery(filterQuery.Filter | filter(Fields.All));

    public static OrderQuery OrderBy(this FilterQuery filterQuery, Func<OrderingFields, string> keySelector)
        => new(filterQuery, [new ValueTuple<string, Order>(keySelector(OrderingFields.All), Order.Ascending)]);

    public static OrderQuery OrderByDescending(this FilterQuery filterQuery, Func<OrderingFields, string> keySelector)
        => new(filterQuery, [new ValueTuple<string, Order>(keySelector(OrderingFields.All), Order.Descending)]);

    public static OrderQuery OrderBy(this InitialQuery _, Func<OrderingFields, string> keySelector)
        => new(default, [new ValueTuple<string, Order>(keySelector(OrderingFields.All), Order.Ascending)]);

    public static OrderQuery OrderByDescending(this InitialQuery _, Func<OrderingFields, string> keySelector)
        => new(default, [new ValueTuple<string, Order>(keySelector(OrderingFields.All), Order.Descending)]);

    public static OrderQuery ThenBy(this OrderQuery query, Func<OrderingFields, string> keySelector)
        => new(query.Query,
            query.Orderings.Append(new ValueTuple<string, Order>(keySelector(OrderingFields.All), Order.Ascending))
                .ToArray());

    public static OrderQuery ThenByDescending(this OrderQuery query, Func<OrderingFields, string> keySelector)
        => new(query.Query,
            query.Orderings.Append(new ValueTuple<string, Order>(keySelector(OrderingFields.All), Order.Descending))
                .ToArray());
}