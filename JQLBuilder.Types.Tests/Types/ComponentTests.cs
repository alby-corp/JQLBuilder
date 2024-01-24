namespace JQLBuilder.Types.Tests.Types;

using Constants;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;
using Support;
using FieldContestants = Constants.Fields;
using Fields = Fields;
using Functions = JQLBuilder.Functions;
using FunctionsConstants = Constants.Functions;

[TestClass]
public class ComponentTests
{
    const string Lead = "Me";
    const string Component = "ABS";
    const int ComponentId = 123;

    [TestMethod]
    public void Should_Cast_Component_Expression_From_String()
    {
        var expression = (ComponentExpression)Component;

        Assert.AreEqual("Field", expression.Value.GetType().Name);
        Assert.AreEqual(new Field(Component), expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Component_Expression_Form_Int()
    {
        var expression = (ComponentExpression)ComponentId;

        Assert.AreEqual("Int32", expression.Value.GetType().Name);
        Assert.AreEqual(ComponentId, expression.Value);
    }

    [TestMethod]
    public void Should_Cast_Component_Field()
    {
        const string expected = FieldContestants.Component;

        var field = Fields.All.Component;
        var actual = ((Field)field.Value).Value;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Equality_Operators()
    {
        var expected =
            $"{FieldContestants.Component} {Operators.Equals} {Component} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.Equals} {ComponentId} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.NotEquals} {Component} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.NotEquals} {ComponentId} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.Equals} {Component} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.Equals} {ComponentId} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.NotEquals} {Component} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.NotEquals} {ComponentId}";

        var actual = JqlBuilder.Query
            .Where(f => f.Component == Component)
            .And(f => f.Component == ComponentId)
            .And(f => f.Component != Component)
            .And(f => f.Component != ComponentId)
            .And(f => Component == f.Component)
            .And(f => ComponentId == f.Component)
            .And(f => Component != f.Component)
            .And(f => ComponentId != f.Component)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Nullable_Operators()
    {
        const string expected =
            $"{FieldContestants.Component} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.Is} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.Is} {Keywords.Null} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.IsNot} {Keywords.Empty} {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.IsNot} {Keywords.Null}";

        var actual = JqlBuilder.Query
            .Where(f => f.Component.Is())
            .And(f => f.Component.Is(s => s.Empty))
            .And(f => f.Component.Is(s => s.Null))
            .And(f => f.Component.IsNot())
            .And(f => f.Component.IsNot(s => s.Empty))
            .And(f => f.Component.IsNot(s => s.Null))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Membership_Operators()
    {
        var expected =
            $"{FieldContestants.Component} {Operators.In} ({ComponentId}, {ComponentId}, {ComponentId}) {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.In} ({ComponentId}, {ComponentId}, {ComponentId}) {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.In} ({ComponentId}, {Component}, {ComponentId}) {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.In} ({ComponentId}, {Component}, {ComponentId}) {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.NotIn} ({ComponentId}, {ComponentId}, {ComponentId}) {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.NotIn} ({ComponentId}, {ComponentId}, {ComponentId}) {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.NotIn} ({ComponentId}, {Component}, {ComponentId}) {Keywords.And} " +
            $"{FieldContestants.Component} {Operators.NotIn} ({ComponentId}, {Component}, {ComponentId})";

        var homogeneousFilter = new JqlCollection<ComponentExpression> { ComponentId, ComponentId, ComponentId };
        var heterogeneousFilter = new JqlCollection<ComponentExpression> { ComponentId, Component, ComponentId };

        var actual = JqlBuilder.Query
            .Where(f => f.Component.In(ComponentId, ComponentId, ComponentId))
            .And(f => f.Component.In(homogeneousFilter))
            .And(f => f.Component.In(ComponentId, Component, ComponentId))
            .And(f => f.Component.In(heterogeneousFilter))
            .And(f => f.Component.NotIn(ComponentId, ComponentId, ComponentId))
            .And(f => f.Component.NotIn(homogeneousFilter))
            .And(f => f.Component.NotIn(ComponentId, Component, ComponentId))
            .And(f => f.Component.NotIn(heterogeneousFilter))
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_Ordering_Fields()
    {
        const string expected = $"{Keywords.OrderBy} {FieldContestants.Component} {Keywords.Ascending}";

        var actual = JqlBuilder.Query
            .OrderBy(f => f.Component)
            .ToString();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Should_Parses_ComponentsLeadByUser_Function()
    {
        const string expected =
            $"""{FieldContestants.Component} {Operators.In} {FunctionsConstants.ComponentsLeadByUser}("{Lead}") {Keywords.And} """ +
            $"{FieldContestants.Component} {Operators.In} {FunctionsConstants.ComponentsLeadByUser}() {Keywords.And} " +
            $"""{FieldContestants.Component} {Operators.NotIn} {FunctionsConstants.ComponentsLeadByUser}("{Lead}") {Keywords.And} """ +
            $"{FieldContestants.Component} {Operators.NotIn} {FunctionsConstants.ComponentsLeadByUser}() {Keywords.And} " +
            $"""{FieldContestants.Component} {Operators.In} {FunctionsConstants.ComponentsLeadByUser}("{Lead}") {Keywords.And} """ +
            $"{FieldContestants.Component} {Operators.In} {FunctionsConstants.ComponentsLeadByUser}() {Keywords.And} " +
            $"""{FieldContestants.Component} {Operators.NotIn} {FunctionsConstants.ComponentsLeadByUser}("{Lead}") {Keywords.And} """ +
            $"{FieldContestants.Component} {Operators.NotIn} {FunctionsConstants.ComponentsLeadByUser}()";

        var actual = JqlBuilder.Query
            .Where(f => f.Component.In(f.Functions.Component.LeadByUser(Lead)))
            .And(f => f.Component.In(f.Functions.Component.LeadByUser()))
            .And(f => f.Component.NotIn(f.Functions.Component.LeadByUser(Lead)))
            .And(f => f.Component.NotIn(f.Functions.Component.LeadByUser()))
            .And(f => f.Component.In(Functions.Component.LeadByUser(Lead)))
            .And(f => f.Component.In(Functions.Component.LeadByUser()))
            .And(f => f.Component.NotIn(Functions.Component.LeadByUser(Lead)))
            .And(f => f.Component.NotIn(Functions.Component.LeadByUser()))
            .ToString();

        Assert.AreEqual(expected, actual);
    }
}