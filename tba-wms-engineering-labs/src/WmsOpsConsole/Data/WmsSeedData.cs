using Microsoft.EntityFrameworkCore;
using WmsOpsConsole.Core.Models;

namespace WmsOpsConsole.Data;

public static class WmsSeedData
{
    public static async Task InitializeAsync(WmsDbContext db)
    {
        await db.Database.EnsureCreatedAsync();

        if (await db.InventoryItems.AnyAsync())
        {
            return;
        }

        var now = DateTime.UtcNow;

        db.InventoryItems.AddRange(
            new InventoryItem { Sku = "PAL-100", Description = "Euro pallet", Zone = "A1", OnHand = 180, Allocated = 42, ReorderPoint = 80, Risk = InventoryRisk.Healthy },
            new InventoryItem { Sku = "LBL-220", Description = "Thermal location label", Zone = "PACK", OnHand = 55, Allocated = 38, ReorderPoint = 40, Risk = InventoryRisk.Reorder },
            new InventoryItem { Sku = "WRP-450", Description = "Stretch wrap roll", Zone = "B2", OnHand = 12, Allocated = 8, ReorderPoint = 25, Risk = InventoryRisk.Watch },
            new InventoryItem { Sku = "SCN-900", Description = "Scanner cradle", Zone = "IT", OnHand = 3, Allocated = 3, ReorderPoint = 4, Risk = InventoryRisk.Blocked });

        db.WorkOrders.AddRange(
            new WorkOrder { OrderNumber = "WO-1001", Customer = "North Sea Retail", Area = "Outbound", Status = WorkOrderStatus.InProgress, DueUtc = now.AddHours(5), AcceptanceCriteria = "All pick tasks complete and carton labels verified" },
            new WorkOrder { OrderNumber = "WO-1002", Customer = "Baltic Components", Area = "Inbound", Status = WorkOrderStatus.WaitingOnDependency, DueUtc = now.AddHours(-2), AcceptanceCriteria = "ASN reconciled against received quantity" },
            new WorkOrder { OrderNumber = "WO-1003", Customer = "Port Spares", Area = "Returns", Status = WorkOrderStatus.Planned, DueUtc = now.AddHours(12), AcceptanceCriteria = "Disposition reason captured before put-away" });

        db.PickTasks.AddRange(
            new PickTask { TaskNumber = "PK-7001", Sku = "PAL-100", Picker = "Marta", Quantity = 12, Status = PickTaskStatus.Completed, ReleasedUtc = now.AddHours(-5), CompletedUtc = now.AddHours(-4) },
            new PickTask { TaskNumber = "PK-7002", Sku = "LBL-220", Picker = "Jon", Quantity = 24, Status = PickTaskStatus.Picking, ReleasedUtc = now.AddHours(-2) },
            new PickTask { TaskNumber = "PK-7003", Sku = "WRP-450", Picker = "Amir", Quantity = 8, Status = PickTaskStatus.Exception, ReleasedUtc = now.AddHours(-3) },
            new PickTask { TaskNumber = "PK-7004", Sku = "SCN-900", Picker = "Ops IT", Quantity = 2, Status = PickTaskStatus.Released, ReleasedUtc = now.AddHours(-1) });

        db.ServiceDeskTickets.AddRange(
            new ServiceDeskTicket { TicketNumber = "SD-301", Summary = "Label print queue blocked for outbound wave", SystemArea = "Outbound", Priority = ServiceDeskPriority.High, Status = ServiceDeskStatus.InProgress, OpenedUtc = now.AddHours(-6), RootCauseHypothesis = "Printer mapping changed after workstation replacement", NextAction = "Verify printer mapping and re-test label format with supervisor" },
            new ServiceDeskTicket { TicketNumber = "SD-302", Summary = "Go-live checklist missing RF scanner sign-off", SystemArea = "Devices", Priority = ServiceDeskPriority.Critical, Status = ServiceDeskStatus.New, OpenedUtc = now.AddHours(-1), RootCauseHypothesis = "Acceptance test evidence not attached", NextAction = "Attach scanner test run and update readiness owner" },
            new ServiceDeskTicket { TicketNumber = "SD-303", Summary = "User request for pick path training refresher", SystemArea = "Training", Priority = ServiceDeskPriority.Medium, Status = ServiceDeskStatus.WaitingForCustomer, OpenedUtc = now.AddHours(-9), RootCauseHypothesis = "New operator joined after first training session", NextAction = "Schedule 20 minute floor walk-through" });

        db.GoLiveReadinessItems.AddRange(
            new GoLiveReadinessItem { Area = "Functional", Requirement = "Outbound pick, pack, and despatch happy path signed off", Status = ReadinessStatus.Ready, Owner = "Product", TargetUtc = now.AddDays(2) },
            new GoLiveReadinessItem { Area = "Data", Requirement = "Item master and location master reconciliation complete", Status = ReadinessStatus.InProgress, Owner = "Data", TargetUtc = now.AddDays(1) },
            new GoLiveReadinessItem { Area = "Support", Requirement = "Service desk rota and escalation contacts confirmed", Status = ReadinessStatus.AtRisk, Owner = "Support", TargetUtc = now.AddHours(18) },
            new GoLiveReadinessItem { Area = "Training", Requirement = "Supervisor quick-reference guide issued", Status = ReadinessStatus.Ready, Owner = "Training", TargetUtc = now.AddDays(3) });

        await db.SaveChangesAsync();
    }
}
