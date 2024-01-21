namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using Fields = Fields;
using FieldContestants = Constants.Fields;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class VersionTests
{
    const string Version = "1.10";
    const string ExpectedVersion = $@"""{Version}""";
    const int VersionId = 123;

    [TestMethod]
    public void Should_Cast_Version_Expression_From_String()
    {
        var expression = (VersionExpression)Version;

        Assert.AreEqual("String", expression.Value.GetType().Name);
        Assert.AreEqual(Version, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Version_Expression_From_Int()
    {
        var expression = (VersionExpression)VersionId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(VersionId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_AffectedVersion_Field()
    {
        const string expected = FieldContestants.AffectedVersion;

        var field = Fields.All.Version.Affected;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Cast_FixVersion_Field()
    {
        const string expected = FieldContestants.FixVersion;

        var field = Fields.All.Version.Fix;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected = $"{FieldContestants.FixVersion} {Operators.Equals} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.Equals} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.NotEquals} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.NotEquals} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.GreaterThanOrEqual} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.GreaterThanOrEqual} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.GreaterThan} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.GreaterThan} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.LessThanOrEqual} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.LessThanOrEqual} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.LessThan} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.LessThan} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.Equals} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.Equals} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.NotEquals} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.NotEquals} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.LessThanOrEqual} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.LessThanOrEqual} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.LessThan} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.LessThan} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.GreaterThanOrEqual} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.GreaterThanOrEqual} {VersionId} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.GreaterThan} {ExpectedVersion} {Keywords.And} " +
                       $"{FieldContestants.FixVersion} {Operators.GreaterThan} {VersionId}";


        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix == Version)
            .And(f => f.Version.Fix == VersionId)
            .And(f => f.Version.Fix != Version)
            .And(f => f.Version.Fix != VersionId)
            .And(f => f.Version.Fix >= Version)
            .And(f => f.Version.Fix >= VersionId)
            .And(f => f.Version.Fix > Version)
            .And(f => f.Version.Fix > VersionId)
            .And(f => f.Version.Fix <= Version)
            .And(f => f.Version.Fix <= VersionId)
            .And(f => f.Version.Fix < Version)
            .And(f => f.Version.Fix < VersionId)
            .And(f => Version == f.Version.Fix)
            .And(f => VersionId == f.Version.Fix)
            .And(f => Version != f.Version.Fix)
            .And(f => VersionId != f.Version.Fix)
            .And(f => Version >= f.Version.Fix)
            .And(f => VersionId >= f.Version.Fix)
            .And(f => Version > f.Version.Fix)
            .And(f => VersionId > f.Version.Fix)
            .And(f => Version <= f.Version.Fix)
            .And(f => VersionId <= f.Version.Fix)
            .And(f => Version < f.Version.Fix)
            .And(f => VersionId < f.Version.Fix)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected = $"{FieldContestants.FixVersion} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{FieldContestants.FixVersion} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
                                $"{FieldContestants.FixVersion} {Operators.Is} {Keywords.Null} {Keywords.And} " +
                                $"{FieldContestants.FixVersion} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{FieldContestants.FixVersion} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
                                $"{FieldContestants.FixVersion} {Operators.IsNot} {Keywords.Null}";
        
        var actual = JqlBuilder.Query
            .Where(f => f.Version.Fix.Is())
            .And(f => f.Version.Fix.Is(s => s.Empty))
            .And (f => f.Version.Fix.Is(s => s.Null))
            .And(f => f.Version.Fix.IsNot())
            .And(f => f.Version.Fix.IsNot(s => s.Empty))
            .And(f => f.Version.Fix.IsNot(s => s.Null))
            .ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected = $"{FieldContestants.AffectedVersion} {Operators.In} ({VersionId}, {VersionId}, {VersionId}) {Keywords.And} " +
                       $"{FieldContestants.AffectedVersion} {Operators.In} ({VersionId}, {VersionId}, {VersionId}) {Keywords.And} " +
                       $"{FieldContestants.AffectedVersion} {Operators.In} ({VersionId}, {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                       $"{FieldContestants.AffectedVersion} {Operators.In} ({VersionId}, {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                       $"{FieldContestants.AffectedVersion} {Operators.NotIn} ({VersionId}, {VersionId}, {VersionId}) {Keywords.And} " +
                       $"{FieldContestants.AffectedVersion} {Operators.NotIn} ({VersionId}, {VersionId}, {VersionId}) {Keywords.And} " +
                       $"{FieldContestants.AffectedVersion} {Operators.NotIn} ({VersionId}, {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                       $"{FieldContestants.AffectedVersion} {Operators.NotIn} ({VersionId}, {ExpectedVersion}, {VersionId})";
        
        var homogeneousFilter = new JqlCollection<VersionExpression> { VersionId, VersionId, VersionId };
        var heterogeneousFilter = new JqlCollection<VersionExpression> { VersionId, Version, VersionId };

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(VersionId, VersionId, VersionId))
            .And(f => f.Version.Affected.In(homogeneousFilter))
            .And(f => f.Version.Affected.In(VersionId, Version, VersionId))
            .And(f => f.Version.Affected.In(heterogeneousFilter))
            .And(f => f.Version.Affected.NotIn(VersionId, VersionId, VersionId))
            .And(f => f.Version.Affected.NotIn(homogeneousFilter))
            .And(f => f.Version.Affected.NotIn(VersionId, Version, VersionId))
            .And(f => f.Version.Affected.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} {FieldContestants.FixVersion} {Keywords.Ascending}, " +
                                $"{FieldContestants.AffectedVersion} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Version.Fix)
            .ThenBy(f => f.Version.Affected)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
        [TestMethod]
    public void Should_Parses_LatestReleasedVersion_And_LatestUnreleasedVersion()
    {
        const string expected = $"{FieldContestants.AffectedVersion} {Operators.Equals} {FunctionsConstants.LatestReleased}() {Keywords.And} " +
                                $"{FieldContestants.AffectedVersion} {Operators.NotEquals} {FunctionsConstants.LatestUnreleased}() {Keywords.And} " +
                                $"{FieldContestants.AffectedVersion} {Operators.Equals} {FunctionsConstants.LatestReleased}() {Keywords.And} " +
                                $"{FieldContestants.AffectedVersion} {Operators.NotEquals} {FunctionsConstants.LatestUnreleased}() {Keywords.And} " +
                                $"{FieldContestants.AffectedVersion} {Operators.Equals} {FunctionsConstants.LatestReleased}() {Keywords.And} " +
                                $"{FieldContestants.AffectedVersion} {Operators.NotEquals} {FunctionsConstants.LatestUnreleased}() {Keywords.And} " +
                                $"{FieldContestants.AffectedVersion} {Operators.Equals} {FunctionsConstants.LatestReleased}() {Keywords.And} " +
                                $"{FieldContestants.AffectedVersion} {Operators.NotEquals} {FunctionsConstants.LatestUnreleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected == f.Functions.Version.LatestReleased)
            .And(f => f.Version.Affected != f.Functions.Version.LatestUnreleased)
            .And(f => f.Version.Affected == Functions.Version.LatestReleased)
            .And(f => f.Version.Affected != Functions.Version.LatestUnreleased)
            .And(f => f.Functions.Version.LatestReleased == f.Version.Affected)
            .And(f => f.Functions.Version.LatestUnreleased != f.Version.Affected)
            .And(f => Functions.Version.LatestReleased == f.Version.Affected)
            .And(f => Functions.Version.LatestUnreleased != f.Version.Affected)
            .ToString();

        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Should_Parses_ReleasedVersions_And_UnreleasedVersions()
    {
        var expected = $"{FieldContestants.AffectedVersion} {Operators.In} ({FunctionsConstants.LatestReleased}(), {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.In} ({FunctionsConstants.LatestUnreleased}(), {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.In} {FunctionsConstants.Released}() {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.In} {FunctionsConstants.Unreleased}() {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.NotIn} ({FunctionsConstants.LatestReleased}(), {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.NotIn} ({FunctionsConstants.LatestUnreleased}(), {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.NotIn} {FunctionsConstants.Released}() {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.NotIn} {FunctionsConstants.Unreleased}() {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.In} ({FunctionsConstants.LatestReleased}(), {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.In} ({FunctionsConstants.LatestUnreleased}(), {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.In} {FunctionsConstants.Released}() {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.In} {FunctionsConstants.Unreleased}() {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.NotIn} ({FunctionsConstants.LatestReleased}(), {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.NotIn} ({FunctionsConstants.LatestUnreleased}(), {ExpectedVersion}, {VersionId}) {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.NotIn} {FunctionsConstants.Released}() {Keywords.And} " +
                            $"{FieldContestants.AffectedVersion} {Operators.NotIn} {FunctionsConstants.Unreleased}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Version.Affected.In(f.Functions.Version.LatestReleased, Version, VersionId))
            .And(f => f.Version.Affected.In(f.Functions.Version.LatestUnreleased, Version, VersionId))
            .And(f => f.Version.Affected.In(f.Functions.Version.Released))
            .And(f => f.Version.Affected.In(f.Functions.Version.Unreleased))
            .And(f => f.Version.Affected.NotIn(f.Functions.Version.LatestReleased, Version, VersionId))
            .And(f => f.Version.Affected.NotIn(f.Functions.Version.LatestUnreleased, Version, VersionId))
            .And(f => f.Version.Affected.NotIn(f.Functions.Version.Released))
            .And(f => f.Version.Affected.NotIn(f.Functions.Version.Unreleased))
            .And(f => f.Version.Affected.In(Functions.Version.LatestReleased, Version, VersionId))
            .And(f => f.Version.Affected.In(Functions.Version.LatestUnreleased, Version, VersionId))
            .And(f => f.Version.Affected.In(Functions.Version.Released))
            .And(f => f.Version.Affected.In(Functions.Version.Unreleased))
            .And(f => f.Version.Affected.NotIn(Functions.Version.LatestReleased, Version, VersionId))
            .And(f => f.Version.Affected.NotIn(Functions.Version.LatestUnreleased, Version, VersionId))
            .And(f => f.Version.Affected.NotIn(Functions.Version.Released))
            .And(f => f.Version.Affected.NotIn(Functions.Version.Unreleased))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}