﻿namespace JQLBuilder.Types;

using Functions;
using JqlTypes;

public class InstanceFunctions
{
    public DateFunctions<DateExpression> Date { get; } = new();
    public ProjectFunctions Project { get; } = new();
    public VersionFunctions Version { get; } = new();
    
    public IssueFunctions Issues { get; } = new();
    
    public UserFunctions User { get; } = new();
}