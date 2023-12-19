namespace AlbyCorp.JQLBuilder.Queries;

using Enums;
using Global;
using Types;

public static class QueryExtensions
{
    public static Query Where(this QueryBuilder query, Func<Fields, Bool> filter)
        => new Query(filter(Fields.All));

    public static Query And(this Query query, Func<Fields, Bool> filter)
        => query.Filter is null
            ? new Query(filter(Fields.All))
            : new(query.Filter & filter(Fields.All));

    public static Query Or(this Query query, Func<Fields, Bool> filter)
        => query.Filter is null
            ? new Query(filter(Fields.All))
            : new(query.Filter | filter(Fields.All));

    public static OrderedQuery OrderBy(this Query query, Func<OrderingFields, string> keySelector)
        => new OrderedQuery(query, [new(keySelector(OrderingFields.All), Order.Ascending)]);

    public static OrderedQuery OrderByDescending(this Query query, Func<OrderingFields, string> keySelector)
        => new OrderedQuery(query, [new(keySelector(OrderingFields.All), Order.Descending)]);

    public static OrderedQuery OrderBy(this QueryBuilder _, Func<OrderingFields, string> keySelector)
        => new OrderedQuery(default, [new(keySelector(OrderingFields.All), Order.Ascending)]);

    public static OrderedQuery OrderByDescending(this QueryBuilder _, Func<OrderingFields, string> keySelector)
        => new OrderedQuery(default, [new(keySelector(OrderingFields.All), Order.Descending)]);

    public static OrderedQuery ThenBy(this OrderedQuery query, Func<OrderingFields, string> keySelector)
        => new OrderedQuery(query.Query,
            query.Orderings.Append(new(keySelector(OrderingFields.All), Order.Ascending)).ToArray());

    public static OrderedQuery ThenByDescending(this OrderedQuery query, Func<OrderingFields, string> keySelector)
        => new OrderedQuery(query.Query,
            query.Orderings.Append(new(keySelector(OrderingFields.All), Order.Descending)).ToArray());
}