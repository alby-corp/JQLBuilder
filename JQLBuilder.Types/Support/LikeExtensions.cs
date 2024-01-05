namespace JQLBuilder.Types.Support;

using Infrastructure.Abstract;
using Infrastructure.Constants;
using Infrastructure.Enum;
using Infrastructure.Operators;

internal static class LikeExtensions
{
    internal static Bool Like<T>(this IJqlField<T> left, T right) where T : IJqlLike<T> =>
        new BinaryOperator(left, JqlKeywords.Like, right, Priority.Equality);

    internal static Bool NotLike<T>(this IJqlField<T> left, T right) where T : IJqlLike<T> =>
        new BinaryOperator(left, JqlKeywords.NotLike, right, Priority.Equality);
}