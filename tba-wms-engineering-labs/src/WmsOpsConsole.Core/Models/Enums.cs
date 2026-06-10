namespace WmsOpsConsole.Core.Models;

public enum InventoryRisk
{
    Healthy,
    Watch,
    Reorder,
    Blocked
}

public enum WorkOrderStatus
{
    Planned,
    InProgress,
    WaitingOnDependency,
    Completed,
    Blocked
}

public enum PickTaskStatus
{
    Released,
    Picking,
    Packed,
    Completed,
    Exception
}

public enum ServiceDeskPriority
{
    Low,
    Medium,
    High,
    Critical
}

public enum ServiceDeskStatus
{
    New,
    InProgress,
    WaitingForCustomer,
    Resolved
}

public enum ReadinessStatus
{
    NotStarted,
    InProgress,
    Ready,
    AtRisk
}
