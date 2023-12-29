namespace JQLBuilder.Types;

using Abstract;
using Primitive;
using Support;

public class Base : JqlValue, IJqlMembership<Base>
{
    public class Version : Base, IJqlNullable
    {
        public static implicit operator Version(string value) => new() { Value = value };
        public static implicit operator Version(int value) => new() { Value = value };
        public static implicit operator Version(BuildIn collection) => new() { Value = collection.Value };
    
        public static Bool operator ==(Version left, Version right) => left.Equal(right);
        public static Bool operator !=(Version left, Version right) => left.NotEqual(right);

        public static Bool operator >(Version left, Version right) => left.GreaterThan(right);
        public static Bool operator >=(Version left, Version right) => left.GreaterThanOrEqual(right);
    
        public static Bool operator <(Version left, Version right) => left.LessThan(right);
        public static Bool operator <=(Version left, Version right) => left.LessThanOrEqual(right);   
    }

    public class BuildIn : Base
    {
        public static Bool operator ==(Version left, BuildIn right) => left.Equal(right);
        public static Bool operator !=(Version left, BuildIn right) => left.NotEqual(right);
        
        public static Bool operator >(Version left, BuildIn right) => left.Equal(right);
        public static Bool operator >=(Version left, BuildIn right) => left.NotEqual(right);
        
        public static Bool operator <(Version left, BuildIn right) => left.Equal(right);
        public static Bool operator <=(Version left, BuildIn right) => left.NotEqual(right);        
    };
}