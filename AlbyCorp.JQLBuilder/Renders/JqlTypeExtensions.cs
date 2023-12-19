namespace AlbyCorp.JQLBuilder.Renders;

using System.Diagnostics;
using Types.Abstract;

internal static class JqlTypeExtensions
{
    internal static void Render(this IJqlType type, IJqlTypeRender render)
    {
        switch (type)
        {
            case JqlType.Operator f:
                render.Operator(f.Left, f.Name, f.Right);
                break;
            case JqlValue { Value: JqlType.Field s }:
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
                throw new UnreachableException();
        }
    }
}