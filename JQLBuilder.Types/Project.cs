namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using JqlTypes;

public class Projecto
{
    public ProjectFunctions Functions { get; } = new();

    public ProjectField Project { get; } = Field.Custom<ProjectField>("project");
}