namespace JQLBuilder.Render.Renders;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

internal static class JqlTypeExtensions
{
    internal static void Render(this IJqlType type, JqlTypeRenderer render)
    {
        switch (type)
        {
            case BinaryOperator f:
                render.BinaryOperator(f);
                break;
            case UnaryOperator f:
                render.UnaryOperator(f);
                break;
            case JqlValue { Value: Field s }:
                render.Field(s);
                break;
            case JqlValue { Value: Function s }:
                render.Function(s);
                break;
            case JqlValue { Value: Issue s }:
                render.Issue(s);
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
            case JqlValue { Value : IReadOnlyList<ChangeOperator> s }:
                render.ChangeOperator(s);
                break;
            case NoValueOperator s:
                render.NoValueOperator(s);
                break;
            case JqlValue { Value : Tuple<IJqlType, IJqlType> s }:
                render.Tuple(s);
                break;
            case JqlValue { Value : IReadOnlyList<IJqlType> s }:
                render.Collection(s);
                break;
            case JqlValue { Value : DateTime s }:
                render.DateTime(s);
                break;
            case JqlValue { Value : DateOnly s }:
                render.DateOnly(s);
                break;
            case JqlValue { Value : TimeOffset s }:
                render.TimeOffset(s);
                break;
            default:
                throw new InvalidOperationException($"Passed type '{type.GetType().Name}' is not mapped!");
        }
    }
}