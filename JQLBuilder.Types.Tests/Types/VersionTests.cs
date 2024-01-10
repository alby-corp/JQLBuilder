namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;
using JqlTypes;

[TestClass]
public partial class VersionTests
{
    const string VersionName = "My Version";
    const int VersionId = 123;

    [TestMethod]
    public void Should_Cast_Project_Expression_By_String()
    {
        var expression = (VersionExpression)VersionName;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(VersionName, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Project_Expression_By_Int()
    {
        var expression = (VersionExpression)VersionId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(VersionId, expression.Value);
    }
    
    
    [TestMethod]
    public void Should_Cast_Affected_Version()
    {
        const string expected = "affectedVersion";
        var field = Fields.All.Version.Affected;
        var actual = ((Field)field.Value).Value;
        
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_Fix_Version_Field()
    {
        const string expected = "fixVersion";
        var field = Fields.All.Version.Fix;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}