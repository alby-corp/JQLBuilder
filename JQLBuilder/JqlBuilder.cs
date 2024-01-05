namespace JQLBuilder;

using Render;
using Render.Abstract;

public static class JqlBuilder
{
    public static IJqlQuery Query { get; } = new JqlQuery();
}