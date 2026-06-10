using WmsOpsConsole.Core.Models;
using WmsOpsConsole.Core.Services;

namespace WmsOpsConsole.Tests;

public sealed class WarehouseKpiCalculatorTests
{
    [Fact]
    public void BuildSnapshotFlagsOperationalRisks()
    {
        var now = new DateTime(2026, 6, 10, 12, 0, 0, DateTimeKind.Utc);
        var calculator = new WarehouseKpiCalculator();

        var snapshot = calculator.BuildSnapshot(
            new[]
            {
                new InventoryItem { Sku = "PAL-100", OnHand = 10, Allocated = 8, ReorderPoint = 5, Risk = InventoryRisk.Watch },
                new InventoryItem { Sku = "LBL-200", OnHand = 0, Allocated = 0, ReorderPoint = 10, Risk = InventoryRisk.Blocked },
                new InventoryItem { Sku = "BOX-300", OnHand = 100, Allocated = 10, ReorderPoint = 20, Risk = InventoryRisk.Healthy }
            },
            new[]
            {
                new WorkOrder { OrderNumber = "WO-1", Status = WorkOrderStatus.InProgress, DueUtc = now.AddHours(-1) },
                new WorkOrder { OrderNumber = "WO-2", Status = WorkOrderStatus.Completed, DueUtc = now.AddHours(-2) }
            },
            new[]
            {
                new PickTask { TaskNumber = "PK-1", Status = PickTaskStatus.Completed },
                new PickTask { TaskNumber = "PK-2", Status = PickTaskStatus.Exception },
                new PickTask { TaskNumber = "PK-3", Status = PickTaskStatus.Picking }
            },
            new[]
            {
                new ServiceDeskTicket { TicketNumber = "SD-1", Priority = ServiceDeskPriority.Critical, Status = ServiceDeskStatus.New },
                new ServiceDeskTicket { TicketNumber = "SD-2", Priority = ServiceDeskPriority.Medium, Status = ServiceDeskStatus.Resolved }
            },
            new[]
            {
                new GoLiveReadinessItem { Status = ReadinessStatus.Ready },
                new GoLiveReadinessItem { Status = ReadinessStatus.InProgress },
                new GoLiveReadinessItem { Status = ReadinessStatus.AtRisk }
            },
            now);

        Assert.Equal(3, snapshot.TotalSkus);
        Assert.Equal(2, snapshot.ReorderSkus);
        Assert.Equal(1, snapshot.BlockedSkus);
        Assert.Equal(1, snapshot.OverdueWorkOrders);
        Assert.Equal(1, snapshot.PickExceptions);
        Assert.Equal(33.3m, snapshot.PickCompletionRate);
        Assert.Equal(1, snapshot.CriticalTickets);
        Assert.Equal(50.0m, snapshot.GoLiveReadinessScore);
        Assert.Equal(1, snapshot.AtRiskReadinessItems);
    }
}
