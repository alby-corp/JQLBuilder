namespace JQLBuilder.Types.JqlArguments;

using Infrastructure;
using Infrastructure.Abstract;

public class JqlArguments : JqlValue, IJqlArgument
{
    public class Text : JqlArguments
    {
        public static implicit operator Text(string value) => new() { Value = value };
    }

    public class Special : JqlArguments
    {
        public static implicit operator Special(string value) => new() { Value = new Field(value) };
        public static implicit operator Special(int value) => new() { Value = value };
    }

    public class Duration : JqlArguments
    {
        public static implicit operator Duration(string value) => new() { Value = ParseDuration(value) };
    }
}