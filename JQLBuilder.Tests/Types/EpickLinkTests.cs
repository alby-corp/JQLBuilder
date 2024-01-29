namespace JQLBuilder.Tests.Types;

using Constants;
using Infrastructure;
using JQLBuilder.Types.JqlTypes;
using FieldContestants = Constants.Fields;
using Fields = Fields;
using Functions = Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class EpicLinkTests
{
    const string EpicLink = "ABS-123";
    const int EpicLinkId = 123;
    const string ExpectedEpicLinkField = $@"""{FieldContestants.EpicLink}""";

    [TestMethod]
    public void Should_Cast_EpicLink_Expression_From_String()
    {
        var expression = (JqlEpicLink)EpicLink;

        Assert.AreEqual("Field", expression.Value.GetType().Name);
        Assert.AreEqual(new Field(EpicLink), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_EpicLink_Expression_Form_Int()
    {
        var expression = (JqlEpicLink)EpicLinkId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(EpicLinkId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_EpicLink_Field()
    {
        var field = Fields.All.Issue.EpicLink;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(FieldContestants.EpicLink, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{ExpectedEpicLinkField} {Operators.Equals} {EpicLink} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.Equals} {EpicLinkId} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.NotEquals} {EpicLink} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.NotEquals} {EpicLinkId} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.Equals} {EpicLink} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.Equals} {EpicLinkId} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.NotEquals} {EpicLink} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.NotEquals} {EpicLinkId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink == EpicLink)
            .And(f => f.Issue.EpicLink == EpicLinkId)
            .And(f => f.Issue.EpicLink != EpicLink)
            .And(f => f.Issue.EpicLink != EpicLinkId)
            .And(f => EpicLink == f.Issue.EpicLink)
            .And(f => EpicLinkId == f.Issue.EpicLink)
            .And(f => EpicLink != f.Issue.EpicLink)
            .And(f => EpicLinkId != f.Issue.EpicLink)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{ExpectedEpicLinkField} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink.Is())
            .And(f => f.Issue.EpicLink.Is(s => s.Empty))
            .And(f => f.Issue.EpicLink.Is(s => s.Null))
            .And(f => f.Issue.EpicLink.IsNot())
            .And(f => f.Issue.EpicLink.IsNot(s => s.Empty))
            .And(f => f.Issue.EpicLink.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{ExpectedEpicLinkField} {Operators.In} ({EpicLinkId}, {EpicLinkId}, {EpicLinkId}) {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.In} ({EpicLinkId}, {EpicLinkId}, {EpicLinkId}) {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.In} ({EpicLinkId}, {EpicLink}, {EpicLinkId}) {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.In} ({EpicLinkId}, {EpicLink}, {EpicLinkId}) {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.NotIn} ({EpicLinkId}, {EpicLinkId}, {EpicLinkId}) {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.NotIn} ({EpicLinkId}, {EpicLinkId}, {EpicLinkId}) {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.NotIn} ({EpicLinkId}, {EpicLink}, {EpicLinkId}) {Keywords.And} " +
            $"{ExpectedEpicLinkField} {Operators.NotIn} ({EpicLinkId}, {EpicLink}, {EpicLinkId})";

        var homogeneousFilter = new JqlCollection<JqlEpicLink> { EpicLinkId, EpicLinkId, EpicLinkId };
        var heterogeneousFilter = new JqlCollection<JqlEpicLink> { EpicLinkId, EpicLink, EpicLinkId };

        var actual = JqlBuilder.Query
            .Where(f => f.Issue.EpicLink.In(EpicLinkId, EpicLinkId, EpicLinkId))
            .And(f => f.Issue.EpicLink.In(homogeneousFilter))
            .And(f => f.Issue.EpicLink.In(EpicLinkId, EpicLink, EpicLinkId))
            .And(f => f.Issue.EpicLink.In(heterogeneousFilter))
            .And(f => f.Issue.EpicLink.NotIn(EpicLinkId, EpicLinkId, EpicLinkId))
            .And(f => f.Issue.EpicLink.NotIn(homogeneousFilter))
            .And(f => f.Issue.EpicLink.NotIn(EpicLinkId, EpicLink, EpicLinkId))
            .And(f => f.Issue.EpicLink.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}