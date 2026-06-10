# WMS Ops Console

WMS Ops Console is a portfolio engineering project for warehouse software support and full-stack development practice. It models the kind of operational tooling used around WMS implementations: inventory risk, work orders, pick tasks, service desk issues, and go-live readiness.

The runnable application is a .NET 8 Blazor web app backed by SQLite. Oracle SQL, Jaspersoft, and Pro*C-style artifacts are included as integration prototypes to show how the same model could map toward enterprise warehouse environments.

## What It Demonstrates

- C# and .NET 8 solution structure compatible with Visual Studio.
- Blazor UI pages for dashboard, operations, service desk, and go-live readiness.
- SQLite-backed seed data and SQL-style operational workflows.
- xUnit tests for KPI calculation and service desk triage logic.
- User stories, acceptance criteria, test plan, functional specification, technical file, support playbook, training notes, and go-live checklist.
- Oracle-style schema, stored procedure, trigger, and seed scripts.
- Jaspersoft-style JRXML report template for warehouse KPIs.
- Pro*C-style illustrative adapter for exporting open service tickets.

## Truthful Limitations

- The runnable demo uses SQLite, not Oracle.
- Oracle SQL files are prototype scripts and are not executed by the .NET app.
- The `.pc` file is an illustrative Pro*C adapter and requires Oracle Pro*C tooling to compile.
- The JRXML file is a reporting template and is not rendered by the Blazor app.
- This is a portfolio project, not a production WMS implementation or customer deployment.

## Project Structure

```text
tba-wms-engineering-labs/
  src/
    WmsOpsConsole/          # Blazor app, EF Core SQLite data layer
    WmsOpsConsole.Core/     # Domain models and business logic
  tests/
    WmsOpsConsole.Tests/    # xUnit tests
  database/oracle/          # Oracle-style schema, procedures, triggers, seed data
  integration/proc/         # Pro*C-style integration sample
  reports/jaspersoft/       # JRXML KPI report template
  docs/                     # Product, test, support, training, and go-live docs
```

## Run Locally

Prerequisite: .NET 8 SDK.

```powershell
dotnet restore
dotnet build
dotnet test
dotnet run --project src/WmsOpsConsole/WmsOpsConsole.csproj
```

Open the printed local URL. The app creates and seeds `wms-ops-console.db` on first run.

## Main User Flows

- Review warehouse KPIs on the dashboard.
- Inspect inventory risk, work orders, and pick tasks.
- Triage service desk tickets with recommended priority.
- Track go-live readiness items by owner, target date, and status.

## Stack

- C#, .NET 8, Blazor
- EF Core with SQLite
- xUnit
- SQL, Oracle-style DDL/DML prototypes
- Jaspersoft JRXML template
- Pro*C-style integration sample
- GitHub Actions
