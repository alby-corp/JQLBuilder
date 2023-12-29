namespace JQLBuilder.Types.Abstract;

public interface IJqlType;
public interface IJqlCollection<out T> : IJqlType where T : IJqlType;
public interface IJqlMembership<in T> : IJqlType where T : IJqlMembership<T>;
public interface IJqlHistorical<in T> : IJqlType where T : IJqlHistorical<T>;
public interface IJqlLike<in T> : IJqlType where T : IJqlLike<T>;
public interface IJqlNullable : IJqlType;

public abstract class JqlValue : IJqlType
{
    internal virtual object? Value { get; init; }
}