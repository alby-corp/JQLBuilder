namespace JQLBuilder.Types.Abstract;

using Infrastructure.Abstract;

public interface IJqlContains<in T> : IJqlType where T : IJqlContains<T>;