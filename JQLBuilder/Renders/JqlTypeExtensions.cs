namespace JQLBuilder.Renders;

using Types.Abstract;
using Types.Primitive;

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
            case JqlValue { Value: Field s }:
                render.Field(s.Value);
                break;
            case JqlValue { Value : string s }:
                render.String(s);
                break;
            case JqlValue { Value : bool s }:
                render.Bool(s);
                break;
            case JqlValue { Value : int s }:
                render.Number(s);
                break;
            case JqlValue { Value : IReadOnlyList<IJqlType> s }:
                render.Collection(s);
                break;
            default:
                throw new InvalidOperationException("Passed type is not mapped!");
        }
    }
}