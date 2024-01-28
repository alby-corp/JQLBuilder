namespace JQLBuilder.Types.Abstract;

using Infrastructure.Abstract;

public interface IJqlMembership<in T> : IJqlType where T : IJqlMembership<T>;