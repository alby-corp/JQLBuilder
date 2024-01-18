namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using Infrastructure.Abstract;

public class DurationArgument : JqlValue, IJqlArgument
{
    public static implicit operator DurationArgument(string value) => new() { Value = ParseDuration(value) };
}
