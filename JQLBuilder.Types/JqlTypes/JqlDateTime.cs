﻿namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;
using DateTime = System.DateTime;

#pragma warning disable CS0660, CS0661
public class DateTimeField : JqlValue, IJqlField<DateTimeExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(DateTimeField left, DateTimeExpression right) => left.Equal(right);

    public static Bool operator !=(DateTimeField left, DateTimeExpression right) => left.NotEqual(right);

    public static Bool operator >(DateTimeField left, DateTimeExpression right) => left.GreaterThan(right);

    public static Bool operator >=(DateTimeField left, DateTimeExpression right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(DateTimeField left, DateTimeExpression right) => left.LessThan(right);

    public static Bool operator <=(DateTimeField left, DateTimeExpression right) => left.LessThanOrEqual(right);

    public static Bool operator ==(DateTimeExpression left, DateTimeField right) => right.Equal(left);

    public static Bool operator !=(DateTimeExpression left, DateTimeField right) => right.NotEqual(left);

    public static Bool operator >(DateTimeExpression left, DateTimeField right) => right.GreaterThan(left);

    public static Bool operator >=(DateTimeExpression left, DateTimeField right) => right.GreaterThanOrEqual(left);

    public static Bool operator <(DateTimeExpression left, DateTimeField right) => right.LessThan(left);

    public static Bool operator <=(DateTimeExpression left, DateTimeField right) => right.LessThanOrEqual(left);
}

public class DateTimeExpression : JqlDate.Time, IJqlMembership<DateTimeExpression>
{
    public static implicit operator DateTimeExpression(string value) => new() { Value = Init(value) };

    public static implicit operator DateTimeExpression(DateTime value) => new() { Value = value };

    public static implicit operator DateTimeExpression(TimeSpan value) => new() { Value = DateTime.Now.Add(value) };
}