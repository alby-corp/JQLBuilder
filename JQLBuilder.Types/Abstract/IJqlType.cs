namespace JQLBuilder.Types.Abstract;

public interface IJqlType;

public interface IJqlNullable : IJqlType;

public interface IJqlCollection<out T> : IJqlType where T : IJqlType;

public interface IJqlMembership<in T> : IJqlType where T : IJqlMembership<T>;

public interface IJqlValue : IJqlType
{
    object Value { get; }
}