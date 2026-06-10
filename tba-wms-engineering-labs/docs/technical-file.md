# Technical File

## Architecture

The solution separates UI, data access, and domain logic:

- `WmsOpsConsole`: Blazor web app and EF Core SQLite data layer.
- `WmsOpsConsole.Core`: domain models and business logic.
- `WmsOpsConsole.Tests`: xUnit tests for core logic.

## Data Model

Main entities:
- InventoryItem
- WorkOrder
- PickTask
- ServiceDeskTicket
- GoLiveReadinessItem

Enums are persisted as strings in SQLite for readable demo data.

## Business Logic

`WarehouseKpiCalculator` aggregates operational KPIs from domain lists.

`ServiceDeskTriageService` recommends ticket priority from operational keywords and ticket age.

`GoLiveReadinessEvaluator` converts readiness status into a percentage score.

## Database

The runnable app uses EF Core with SQLite and creates `wms-ops-console.db` on first run. The Oracle folder contains prototype scripts for enterprise-style mapping.

## Build

```powershell
dotnet restore
dotnet build
dotnet test
```

## Security Notes

This demo has no production authentication. The service desk and go-live views use sample data only. Do not enter real customer, employee, or warehouse data.
