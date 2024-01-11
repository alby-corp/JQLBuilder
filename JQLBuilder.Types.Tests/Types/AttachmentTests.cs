namespace JQLBuilder.Types.Tests.Types;

using Infrastructure;

[TestClass]
public partial class AttachmentTests
{
    [TestMethod]
    public void Should_Cast_Attachment()
    {
        const string expected = Constants.Fields.Attachment;

        var field = Fields.All.Attachment;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
}