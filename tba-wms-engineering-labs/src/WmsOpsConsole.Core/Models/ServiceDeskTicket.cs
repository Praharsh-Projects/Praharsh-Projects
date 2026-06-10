namespace WmsOpsConsole.Core.Models;

public sealed class ServiceDeskTicket
{
    public int Id { get; set; }
    public string TicketNumber { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string SystemArea { get; set; } = string.Empty;
    public ServiceDeskPriority Priority { get; set; }
    public ServiceDeskStatus Status { get; set; }
    public DateTime OpenedUtc { get; set; }
    public string RootCauseHypothesis { get; set; } = string.Empty;
    public string NextAction { get; set; } = string.Empty;
}
