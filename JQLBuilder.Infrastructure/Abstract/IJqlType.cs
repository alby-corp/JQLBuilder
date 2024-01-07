namespace JQLBuilder.Infrastructure.Abstract;

public interface IJqlType;

public interface IJqlField<TExp> : IJqlType;

public interface IJqlCollection<out T> : IJqlType where T : IJqlType;

public interface IJqlMembership<in T> : IJqlType where T : IJqlMembership<T>;

public interface IJqlHistorical<in T> : IJqlType where T : IJqlHistorical<T>;

public interface IJqlContains<in T> : IJqlType where T : IJqlContains<T>;

public interface IJqlNullable : IJqlType;