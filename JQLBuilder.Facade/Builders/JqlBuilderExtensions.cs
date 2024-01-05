namespace JQLBuilder.Facade.Builders;

using Infrastructure.Abstract;
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

    public static OrderQuery OrderBy<T>(this FilterQuery filterQuery, Func<Ordering, IJqlField<T>> keySelector) =>
        new(filterQuery, [new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Ascending)]);

    public static OrderQuery OrderByDescending<T>(this FilterQuery filterQuery, Func<Ordering, IJqlField<T>> keySelector) =>
        new(filterQuery, [new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Descending)]);

    public static OrderQuery OrderBy<T>(this InitialQuery _, Func<Ordering, IJqlField<T>> keySelector) =>
        new(default, [new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Ascending)]);

    public static OrderQuery OrderByDescending<T>(this InitialQuery _, Func<Ordering, IJqlField<T>> keySelector) =>
        new(default, [new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Descending)]);

    public static OrderQuery ThenBy<T>(this OrderQuery query, Func<Ordering, IJqlField<T>> keySelector) =>
        new(query.Query, query.Orderings.Append(new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Ascending)).ToArray());

    public static OrderQuery ThenByDescending<T>(this OrderQuery query, Func<Ordering, IJqlField<T>> keySelector) =>
        new(query.Query, query.Orderings.Append(new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Descending)).ToArray());
}