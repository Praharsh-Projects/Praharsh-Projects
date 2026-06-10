namespace WmsOpsConsole.Core.Models;

public sealed class PickTask
{
    public int Id { get; set; }
    public string TaskNumber { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public string Picker { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public PickTaskStatus Status { get; set; }
    public DateTime ReleasedUtc { get; set; }
    public DateTime? CompletedUtc { get; set; }
}
