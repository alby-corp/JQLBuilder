namespace JQLBuilder.Types.Abstract;

public interface IJqlType;

public interface IJqlNullable : IJqlType;

public interface IJqlCollection<out T> : IJqlType where T : IJqlType;

public interface IJqlMembership<in T> : IJqlType where T : IJqlMembership<T>;

public abstract class JqlValue() : IJqlType
{
    internal virtual object? Value { get; init; }
}