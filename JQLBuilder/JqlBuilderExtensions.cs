namespace JQLBuilder;

using Infrastructure.Abstract;
using Infrastructure.Operators;
using Render;
using Render.Abstract;
using Render.Enums;

public static class JqlBuilderExtensions
{
    public static JqlFilter Where(this IJqlQuery _, Func<Fields, Bool> filter) => new(filter(Fields.All));

    public static JqlFilter And(this JqlFilter filterQuery, Func<Fields, Bool> filter) =>
        filterQuery.Query is null
            ? new JqlFilter(filter(Fields.All))
            : new JqlFilter(filterQuery.Query & filter(Fields.All));

    public static JqlFilter Or(this JqlFilter filterQuery, Func<Fields, Bool> filter) =>
        filterQuery.Query is null
            ? new JqlFilter(filter(Fields.All))
            : new JqlFilter(filterQuery.Query | filter(Fields.All));

    public static JqlOrder OrderBy<T>(this JqlFilter filterQuery, Func<Ordering, IJqlField<T>> keySelector) =>
        new(filterQuery, [new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Ascending)]);

    public static JqlOrder OrderByDescending<T>(this JqlFilter filterQuery, Func<Ordering, IJqlField<T>> keySelector) =>
        new(filterQuery, [new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Descending)]);

    public static JqlOrder OrderBy<T>(this IJqlQuery _, Func<Ordering, IJqlField<T>> keySelector) =>
        new(default, [new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Ascending)]);

    public static JqlOrder OrderByDescending<T>(this IJqlQuery _, Func<Ordering, IJqlField<T>> keySelector) =>
        new(default, [new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Descending)]);

    public static JqlOrder ThenBy<T>(this JqlOrder query, Func<Ordering, IJqlField<T>> keySelector) =>
        new(query.Query, query.Orderings.Append(new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Ascending)).ToArray());

    public static JqlOrder ThenByDescending<T>(this JqlOrder query, Func<Ordering, IJqlField<T>> keySelector) =>
        new(query.Query, query.Orderings.Append(new ValueTuple<IJqlType, Order>(keySelector(Ordering.All), Order.Descending)).ToArray());
}