namespace JQLBuilder.Types.Support;

using Abstract;
using Enum;
using Primitive;

public static class LikeExtensions
{
    public static Bool Like<T>(this T left, T right) where T : IJqlLike<T> => new BinaryOperator(left, Constants.Like, right, Priority.Powerful);
    public static Bool NotLike<T>(this T left, T right) where T : IJqlLike<T> => new BinaryOperator(left, Constants.NotLike, right, Priority.Powerful);
}