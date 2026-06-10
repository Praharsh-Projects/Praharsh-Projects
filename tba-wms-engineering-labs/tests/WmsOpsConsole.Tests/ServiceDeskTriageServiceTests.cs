using WmsOpsConsole.Core.Models;
using WmsOpsConsole.Core.Services;

namespace WmsOpsConsole.Tests;

public sealed class ServiceDeskTriageServiceTests
{
    [Fact]
    public void RecommendPriorityEscalatesGoLiveAndPickingOutages()
    {
        var service = new ServiceDeskTriageService();
        var ticket = new ServiceDeskTicket
        {
            Summary = "Go-live user cannot pick orders after interface down alert",
            SystemArea = "Outbound",
            OpenedUtc = DateTime.UtcNow
        };

        var priority = service.RecommendPriority(ticket, DateTime.UtcNow);

        Assert.Equal(ServiceDeskPriority.Critical, priority);
    }

    [Fact]
    public void RecommendPriorityEscalatesAgedTickets()
    {
        var now = new DateTime(2026, 6, 10, 12, 0, 0, DateTimeKind.Utc);
        var service = new ServiceDeskTriageService();
        var ticket = new ServiceDeskTicket
        {
            Summary = "Operator training request",
            SystemArea = "Inbound",
            OpenedUtc = now.AddHours(-10)
        };

        var priority = service.RecommendPriority(ticket, now);

        Assert.Equal(ServiceDeskPriority.Medium, priority);
    }
}
