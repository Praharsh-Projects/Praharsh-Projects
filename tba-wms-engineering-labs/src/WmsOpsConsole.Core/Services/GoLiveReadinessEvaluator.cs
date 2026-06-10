using WmsOpsConsole.Core.Models;

namespace WmsOpsConsole.Core.Services;

public static class GoLiveReadinessEvaluator
{
    public static decimal CalculateScore(IEnumerable<GoLiveReadinessItem> items)
    {
        var readinessItems = items.ToList();
        if (readinessItems.Count == 0)
        {
            return 0m;
        }

        var weightedScore = readinessItems.Sum(item => item.Status switch
        {
            ReadinessStatus.Ready => 1m,
            ReadinessStatus.InProgress => 0.5m,
            ReadinessStatus.NotStarted => 0.1m,
            ReadinessStatus.AtRisk => 0m,
            _ => 0m
        });

        return Math.Round(weightedScore / readinessItems.Count * 100m, 1);
    }
}
