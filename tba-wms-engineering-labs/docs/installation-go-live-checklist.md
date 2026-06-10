# Installation and Go-Live Checklist

## Local Installation

- Install .NET 8 SDK.
- Restore packages with `dotnet restore`.
- Build with `dotnet build`.
- Run tests with `dotnet test`.
- Start app with `dotnet run --project src/WmsOpsConsole/WmsOpsConsole.csproj`.
- Confirm the SQLite seed database is created.

## Functional Go-Live Checks

- Inventory view loads and available quantity is correct.
- Work-order statuses match expected workflow states.
- Pick-task exceptions appear in KPI cards.
- Service desk priority recommendations are visible.
- Go-live readiness score is calculated.

## Data Checks

- SKU values are unique.
- Work order numbers are unique.
- Ticket numbers are unique.
- Reorder point is not negative.
- Allocated quantity does not exceed on-hand unless intentionally used as an exception scenario.

## Support Checks

- Service desk triage rules reviewed.
- Escalation owners assigned.
- Training guide issued.
- Known limitations communicated.
- Rollback path documented for demo database reset.

## Reset Demo Database

Stop the app, delete `wms-ops-console.db`, and run the app again. The seed routine recreates the database.
