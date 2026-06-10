namespace WmsOpsConsole.Core.Models;

public sealed class GoLiveReadinessItem
{
    public int Id { get; set; }
    public string Area { get; set; } = string.Empty;
    public string Requirement { get; set; } = string.Empty;
    public ReadinessStatus Status { get; set; }
    public string Owner { get; set; } = string.Empty;
    public DateTime TargetUtc { get; set; }
}
