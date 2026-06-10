using Microsoft.EntityFrameworkCore;
using WmsOpsConsole.Components;
using WmsOpsConsole.Core.Services;
using WmsOpsConsole.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("WmsOpsConsole")
    ?? "Data Source=wms-ops-console.db";

builder.Services.AddDbContextFactory<WmsDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddScoped<WarehouseKpiCalculator>();
builder.Services.AddScoped<ServiceDeskTriageService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<WmsDbContext>>();
    await using var db = await dbFactory.CreateDbContextAsync();
    await WmsSeedData.InitializeAsync(db);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
