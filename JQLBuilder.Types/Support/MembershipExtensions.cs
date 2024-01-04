// ReSharper disable once CheckNamespace

namespace JQLBuilder;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Constants;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class MembershipExtensions
{
    internal static Bool In<T>(this IJqlField<T> value, IJqlCollection<T> jqlCollection) where T : IJqlType, IJqlMembership<T> => 
        new BinaryOperator(value, JqlKeywords.In, jqlCollection, Priority.Powerful);

    internal static Bool In<T>(this IJqlField<T> value, params T[] collection) where T : IJqlType, IJqlMembership<T> => 
        new BinaryOperator(value, JqlKeywords.In, new JqlValue { Value = collection }, Priority.Powerful);

    internal static Bool NotIn<T>(this IJqlField<T> value, IJqlCollection<T> jqlCollection) where T : IJqlType, IJqlMembership<T> => 
        new BinaryOperator(value, JqlKeywords.NotIn, jqlCollection, Priority.Powerful);

    internal static Bool NotIn<T>(this IJqlField<T> value, params T[] collection) where T : IJqlType, IJqlMembership<T> => 
        new BinaryOperator(value, JqlKeywords.NotIn, new JqlValue { Value = collection }, Priority.Powerful);
}