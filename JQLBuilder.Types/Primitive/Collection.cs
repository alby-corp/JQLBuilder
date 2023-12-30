namespace JQLBuilder.Types.Primitive;

using Abstract;

public class JqlCollection<T> : JqlValue, IJqlCollection<T> where T : IJqlType;
