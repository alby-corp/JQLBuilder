namespace AlbyCorp.JQLBuilder.Types;

public interface IJqlType
{
    public interface ICollection<out T> : IJqlType where T : IJqlType;

    public interface IEquatable<in T> : IJqlType where T : IEquatable<T>
    {
        public static abstract Bool operator ==(T left, T right);
        public static abstract Bool operator !=(T left, T right);
    }

    public interface IComparable<in T> : IJqlType where T : IComparable<T>
    {
        public static abstract Bool operator >(T left, T right);
        public static abstract Bool operator >=(T left, T right);
        public static abstract Bool operator <(T left, T right);
        public static abstract Bool operator <=(T left, T right);
    }
}