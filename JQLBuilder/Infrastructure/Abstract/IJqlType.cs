namespace JQLBuilder.Infrastructure.Abstract;

public interface IJqlType;

public interface IJqlField<TExp> : IJqlType;

public interface IJqlArgument : IJqlType;

public interface IJqlCollection<out T> : IJqlType where T : IJqlType;