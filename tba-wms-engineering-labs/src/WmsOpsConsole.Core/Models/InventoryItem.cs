namespace WmsOpsConsole.Core.Models;

public sealed class InventoryItem
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Zone { get; set; } = string.Empty;
    public int OnHand { get; set; }
    public int Allocated { get; set; }
    public int ReorderPoint { get; set; }
    public InventoryRisk Risk { get; set; }

    public int Available => OnHand - Allocated;
}
