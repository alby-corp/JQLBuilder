﻿// ReSharper disable once CheckNamespace

namespace JQLBuilder;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Enum;
using Infrastructure.Operators;
using Types.Abstract;
using Types.JqlTypes;

public static class HistoricalExtensions
{
    public static Bool Was<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.Was, right, Priority.Powerful);

    public static Bool WasIn<T>(this IJqlField<T> value, params T[] collection) where T : IJqlType, IJqlHistorical<T> =>
        new BinaryOperator(value, Operators.WasIn, new JqlValue { Value = collection }, Priority.Powerful);

    public static Bool WasIn<T>(this IJqlField<T> left, JqlCollection<T> right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasIn, right, Priority.Powerful);

    public static Bool WasNot<T>(this IJqlField<T> left, T right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasNot, right, Priority.Powerful);

    public static Bool WasNotIn<T>(this IJqlField<T> value, params T[] collection) where T : IJqlType, IJqlHistorical<T> =>
        new BinaryOperator(value, Operators.WasNotIn, new JqlValue { Value = collection }, Priority.Powerful);

    public static Bool WasNotIn<T>(this IJqlField<T> left, JqlCollection<T> right) where T : IJqlHistorical<T> =>
        new BinaryOperator(left, Operators.WasNotIn, right, Priority.Powerful);

    public static Bool Changed<T>(this IJqlField<T> field, Func<JqlChange<T>, JqlChange<T>>? operators = default)
        where T : IJqlType, IJqlHistorical<T>
    {
        if (operators is null) return new UnaryOperator(Operators.Changed, field, Direction.Suffix);

        var changes = operators(new([]));
        return new BinaryOperator(field, Operators.Changed, changes, Priority.Powerful);
    }
}