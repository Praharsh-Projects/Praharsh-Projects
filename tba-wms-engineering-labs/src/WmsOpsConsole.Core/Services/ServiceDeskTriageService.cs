using WmsOpsConsole.Core.Models;

namespace WmsOpsConsole.Core.Services;

public sealed class ServiceDeskTriageService
{
    public ServiceDeskPriority RecommendPriority(ServiceDeskTicket ticket, DateTime utcNow)
    {
        var ageHours = (utcNow - ticket.OpenedUtc).TotalHours;
        var text = $"{ticket.Summary} {ticket.SystemArea}".ToLowerInvariant();

        if (text.Contains("go-live") || text.Contains("outage") || text.Contains("cannot pick") || text.Contains("interface down"))
        {
            return ServiceDeskPriority.Critical;
        }

        if (ageHours >= 24 || text.Contains("blocked") || text.Contains("stock mismatch") || text.Contains("label print"))
        {
            return ServiceDeskPriority.High;
        }

        if (ageHours >= 8 || text.Contains("slow") || text.Contains("training"))
        {
            return ServiceDeskPriority.Medium;
        }

        return ServiceDeskPriority.Low;
    }
}
