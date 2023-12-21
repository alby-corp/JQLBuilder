namespace JQLBuilder.Renders;

using System.Diagnostics;
using global::JqlBuilder.Types.Abstract;
using global::JqlBuilder.Types.Primitive;

internal static class JqlTypeExtensions
{
    internal static void Render(this IJqlType type, IJqlTypeRender render)
    {
        switch (type)
        {
            case BinaryOperator f:
                render.BinaryOperator(f.Left, f.Name, f.Right, f.Priority);
                break;
            case UnaryOperator f:
                render.UnaryOperator(f.Value, f.Name, f.Direction);
                break;
            case IJqlValue { Value: Field s }:
                render.Field(s.Value);
                break;
            case IJqlValue { Value : string s }:
                render.String(s);
                break;
            case IJqlValue { Value : bool s }:
                render.Bool(s);
                break;
            case IJqlValue { Value : int s }:
                render.Number(s);
                break;
            case IJqlValue { Value : IReadOnlyList<IJqlType> s }:
                render.Collection(s);
                break;
            default:
                throw new UnreachableException();
        }
    }
}