namespace WmsOpsConsole.Core.Models;

public sealed class WorkOrder
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public string Area { get; set; } = string.Empty;
    public WorkOrderStatus Status { get; set; }
    public DateTime DueUtc { get; set; }
    public string AcceptanceCriteria { get; set; } = string.Empty;
}
