namespace JQLBuilder.Tests.TimeTracking;

using Constants;
using Infrastructure;
using Fields = Fields;
using FieldContestants = Constants.Fields;

[TestClass]
public class WorkLogCommentTests
{
    const string Comment = "MyText";
    const string ExpectedText = $@"""{Comment}""";

    [TestMethod]
    public void Should_Cast_Text_Field()
    {
        const string expected = Constants.Fields.WorklogComment;

        var field = Fields.All.TimeTracking.WorkLog.Comment;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        const string expected = 
            $"{FieldContestants.WorklogComment} {Operators.Equals} {ExpectedText} {Keywords.And} " +
            $"{FieldContestants.WorklogComment} {Operators.NotEquals} {ExpectedText} {Keywords.And} " +
            $"{FieldContestants.WorklogComment} {Operators.Equals} {ExpectedText} {Keywords.And} " +
            $"{FieldContestants.WorklogComment} {Operators.NotEquals} {ExpectedText}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Comment == Comment)
            .And(f => f.TimeTracking.WorkLog.Comment != Comment)
            .And(f => Comment == f.TimeTracking.WorkLog.Comment)
            .And(f => Comment != f.TimeTracking.WorkLog.Comment)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        var expected =
            $"{FieldContestants.WorklogComment} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorklogComment} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorklogComment} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.WorklogComment} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorklogComment} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.WorklogComment} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Comment.Is())
            .And(f => f.TimeTracking.WorkLog.Comment.Is(s => s.Empty))
            .And(f => f.TimeTracking.WorkLog.Comment.Is(s => s.Null))
            .And(f => f.TimeTracking.WorkLog.Comment.IsNot())
            .And(f => f.TimeTracking.WorkLog.Comment.IsNot(s => s.Empty))
            .And(f => f.TimeTracking.WorkLog.Comment.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Contains_Operators()
    {
        const string expected = 
            $"{FieldContestants.WorklogComment} {Operators.Contains} {ExpectedText}";

        var actual = JqlBuilder.Query
            .Where(f => f.TimeTracking.WorkLog.Comment.Contains(Comment))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}