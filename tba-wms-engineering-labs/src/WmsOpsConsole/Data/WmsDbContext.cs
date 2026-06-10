using Microsoft.EntityFrameworkCore;
using WmsOpsConsole.Core.Models;

namespace WmsOpsConsole.Data;

public sealed class WmsDbContext(DbContextOptions<WmsDbContext> options) : DbContext(options)
{
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
    public DbSet<PickTask> PickTasks => Set<PickTask>();
    public DbSet<ServiceDeskTicket> ServiceDeskTickets => Set<ServiceDeskTicket>();
    public DbSet<GoLiveReadinessItem> GoLiveReadinessItems => Set<GoLiveReadinessItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryItem>().Property(item => item.Risk).HasConversion<string>();
        modelBuilder.Entity<WorkOrder>().Property(order => order.Status).HasConversion<string>();
        modelBuilder.Entity<PickTask>().Property(task => task.Status).HasConversion<string>();
        modelBuilder.Entity<ServiceDeskTicket>().Property(ticket => ticket.Priority).HasConversion<string>();
        modelBuilder.Entity<ServiceDeskTicket>().Property(ticket => ticket.Status).HasConversion<string>();
        modelBuilder.Entity<GoLiveReadinessItem>().Property(item => item.Status).HasConversion<string>();

        modelBuilder.Entity<InventoryItem>().HasIndex(item => item.Sku).IsUnique();
        modelBuilder.Entity<WorkOrder>().HasIndex(order => order.OrderNumber).IsUnique();
        modelBuilder.Entity<PickTask>().HasIndex(task => task.TaskNumber).IsUnique();
        modelBuilder.Entity<ServiceDeskTicket>().HasIndex(ticket => ticket.TicketNumber).IsUnique();
    }
}
