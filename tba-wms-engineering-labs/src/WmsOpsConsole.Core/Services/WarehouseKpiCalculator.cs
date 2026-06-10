using WmsOpsConsole.Core.Models;

namespace WmsOpsConsole.Core.Services;

public sealed class WarehouseKpiCalculator
{
    public WarehouseKpiSnapshot BuildSnapshot(
        IEnumerable<InventoryItem> inventory,
        IEnumerable<WorkOrder> workOrders,
        IEnumerable<PickTask> pickTasks,
        IEnumerable<ServiceDeskTicket> tickets,
        IEnumerable<GoLiveReadinessItem> readinessItems,
        DateTime utcNow)
    {
        var inventoryList = inventory.ToList();
        var workOrderList = workOrders.ToList();
        var pickTaskList = pickTasks.ToList();
        var ticketList = tickets.ToList();
        var readinessList = readinessItems.ToList();

        var completedPickTasks = pickTaskList.Count(task => task.Status == PickTaskStatus.Completed);
        var pickCompletionRate = pickTaskList.Count == 0
            ? 100m
            : Math.Round((decimal)completedPickTasks / pickTaskList.Count * 100m, 1);

        return new WarehouseKpiSnapshot(
            TotalSkus: inventoryList.Count,
            ReorderSkus: inventoryList.Count(item => item.Available <= item.ReorderPoint || item.Risk == InventoryRisk.Reorder),
            BlockedSkus: inventoryList.Count(item => item.Risk == InventoryRisk.Blocked),
            OpenPickTasks: pickTaskList.Count(task => task.Status is PickTaskStatus.Released or PickTaskStatus.Picking or PickTaskStatus.Packed),
            PickExceptions: pickTaskList.Count(task => task.Status == PickTaskStatus.Exception),
            PickCompletionRate: pickCompletionRate,
            OpenWorkOrders: workOrderList.Count(order => order.Status != WorkOrderStatus.Completed),
            OverdueWorkOrders: workOrderList.Count(order => order.Status != WorkOrderStatus.Completed && order.DueUtc < utcNow),
            OpenTickets: ticketList.Count(ticket => ticket.Status != ServiceDeskStatus.Resolved),
            CriticalTickets: ticketList.Count(ticket => ticket.Priority == ServiceDeskPriority.Critical && ticket.Status != ServiceDeskStatus.Resolved),
            GoLiveReadinessScore: GoLiveReadinessEvaluator.CalculateScore(readinessList),
            AtRiskReadinessItems: readinessList.Count(item => item.Status == ReadinessStatus.AtRisk));
    }
}
