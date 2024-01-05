namespace JQLBuilder.Facade.Builders;

using Infrastructure.Operators;
using Render.Enums;
using Render.Queries;

public static class JqlBuilderExtensions
{
    public static FilterQuery Where(this InitialQuery initialQuery, Func<Fields, Bool> filter) =>
        new(filter(Fields.All));

    public static FilterQuery And(this FilterQuery filterQuery, Func<Fields, Bool> filter) =>
        filterQuery.Filter is null
            ? new FilterQuery(filter(Fields.All))
            : new FilterQuery(filterQuery.Filter & filter(Fields.All));

    public static FilterQuery Or(this FilterQuery filterQuery, Func<Fields, Bool> filter) =>
        filterQuery.Filter is null
            ? new FilterQuery(filter(Fields.All))
            : new FilterQuery(filterQuery.Filter | filter(Fields.All));

    public static OrderQuery OrderBy(this FilterQuery filterQuery, Func<Ordering, string> keySelector) =>
        new(filterQuery, [new ValueTuple<string, Order>(keySelector(Ordering.All), Order.Ascending)]);

    public static OrderQuery OrderByDescending(this FilterQuery filterQuery, Func<Ordering, string> keySelector) =>
        new(filterQuery, [new ValueTuple<string, Order>(keySelector(Ordering.All), Order.Descending)]);

    public static OrderQuery OrderBy(this InitialQuery _, Func<Ordering, string> keySelector) =>
        new(default, [new ValueTuple<string, Order>(keySelector(Ordering.All), Order.Ascending)]);

    public static OrderQuery OrderByDescending(this InitialQuery _, Func<Ordering, string> keySelector) =>
        new(default, [new ValueTuple<string, Order>(keySelector(Ordering.All), Order.Descending)]);

    public static OrderQuery ThenBy(this OrderQuery query, Func<Ordering, string> keySelector) =>
        new(query.Query, query.Orderings.Append(new ValueTuple<string, Order>(keySelector(Ordering.All), Order.Ascending)).ToArray());

    public static OrderQuery ThenByDescending(this OrderQuery query, Func<Ordering, string> keySelector) =>
        new(query.Query, query.Orderings.Append(new ValueTuple<string, Order>(keySelector(Ordering.All), Order.Descending)).ToArray());
}