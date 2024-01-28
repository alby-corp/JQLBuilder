namespace JQLBuilder.Types.Abstract;

using Infrastructure.Abstract;

public interface IJqlHistorical<in T> : IJqlType where T : IJqlHistorical<T>;