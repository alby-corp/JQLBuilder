namespace JQLBuilder.Tests;

using System.Data;

[TestClass]
public class ApprovalTests
{
    const string User = "hulk@avengers.world";

    [TestMethod]
    public void TestMethod1()
    {
        var actual = JqlBuilder.Query.Where(f => f.Version != (e => e.Released()));

        Assert.ThrowsException<InvalidExpressionException>(() => actual.ToString(),
            "!= is not supported for Approvals");
    }

    [TestMethod]
    public void TestMethod2()
    {
        const string expected = "approvals = latestReleasedVersion()";

        var actual = JqlBuilder.Query.Where(f => f.Approval == (e => e.Approved())).ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestMethod3()
    {
        const string expected =
            $"""approvals = approved() AND approvals = approver("{User}") AND approvals = myApproval() OR approvals = myPending() AND approvals = myPendingApproval() OR approvals = pending() AND approvals = pendingBy("{User}")""";

        var actual = JqlBuilder.Query.Where(f =>
            ((f.Approval == (e => e.Approved())) &
             (f.Approval == (e => e.Approver(User))) &
             (f.Approval == (e => e.MyApproval()))) |
            ((f.Approval == (e => e.MyPending())) &
             (f.Approval == (e => e.MyPendingApproval()))) |
            ((f.Approval == (e => e.Pending())) &
             (f.Approval == (e => e.PendingBy(User))))
        ).ToString();

        Assert.AreEqual(expected, actual);
    }
}