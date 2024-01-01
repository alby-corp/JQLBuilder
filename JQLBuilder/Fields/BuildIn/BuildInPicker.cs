namespace JQLBuilder.Fields.BuildIn;

using Types.Custom;
using Types.Primitive;

public class BuildInPicker
{
    public PickerExpression ReleasedVersions() => Field.Custom<PickerExpression>($"releasedVersions()");
    public PickerExpression LatestReleasedVersion() => Field.Custom<PickerExpression>($"latestReleasedVersion()");
    public PickerExpression UnreleasedVersions() => Field.Custom<PickerExpression>($"unreleasedVersions()");
    public PickerExpression EarliestUnreleasedVersion() => Field.Custom<PickerExpression>($"earliestUnreleasedVersion()");
}