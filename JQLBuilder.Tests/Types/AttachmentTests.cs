namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class AttachmentTests
{
    [TestMethod]
    public void Should_Cast_Attachment_Field()
    {
        const string expected = FieldContestants.Attachment;

        var field = Fields.All.Attachment;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Attachment} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Attachment} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Attachment} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Attachment} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Attachment} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Attachment} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Attachment.Is())
            .And(f => f.Attachment.Is(s => s.Empty))
            .And(f => f.Attachment.Is(s => s.Null))
            .And(f => f.Attachment.IsNot())
            .And(f => f.Attachment.IsNot(s => s.Empty))
            .And(f => f.Attachment.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}