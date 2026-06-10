namespace WmsOpsConsole.Core.Models;

public sealed record WarehouseKpiSnapshot(
    int TotalSkus,
    int ReorderSkus,
    int BlockedSkus,
    int OpenPickTasks,
    int PickExceptions,
    decimal PickCompletionRate,
    int OpenWorkOrders,
    int OverdueWorkOrders,
    int OpenTickets,
    int CriticalTickets,
    decimal GoLiveReadinessScore,
    int AtRiskReadinessItems);
