namespace JQLBuilder.Types.Tests.Support;

using Abstract;
using Types.Support;

[TestClass]
public class NullableExtensionsTests
{
    class MyJql : JqlValue, IJqlNullable;
    
    readonly MyJql left = new(){ Value = DateTime.Now };
    readonly MyJql right = new(){ Value = 1 };
    
    [TestMethod]
    public void IS_EMPTY_TEST()
    {
        var actual = left.Is(f => f.Empty);

        throw new NullReferenceException();
    }
    
    [TestMethod]
    public void IS_NULL_TEST()
    {
        var actual = left.Is(f => f.Empty);

        throw new NullReferenceException();
    }
    
    [TestMethod]
    public void IS_NOT_EMPTY_TEST()
    {
        var actual = left.Is(f => f.Empty);

        throw new NullReferenceException();
    }
    
    [TestMethod]
    public void IS_NOT_NULL_TEST()
    {
        var actual = left.Is(f => f.Empty);

        throw new NullReferenceException();
    }
}