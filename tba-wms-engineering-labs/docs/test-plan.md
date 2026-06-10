# Test Plan

## Objectives

- Confirm business logic for KPI calculation.
- Confirm service desk priority recommendations.
- Confirm the application builds and runs from a clean checkout.
- Confirm documentation matches implemented behavior.

## Automated Tests

Run:

```powershell
dotnet test
```

Current coverage:
- KPI aggregation flags reorder SKUs, blocked SKUs, overdue work orders, pick exceptions, critical tickets, and readiness risk.
- Ticket triage escalates go-live and operational outage language.
- Ticket triage escalates aged support requests.

## Manual Smoke Tests

1. Run the app.
2. Open the dashboard.
3. Confirm KPI cards and priority exceptions load.
4. Open Operations and confirm inventory, work orders, and pick tasks are visible.
5. Open Service Desk and confirm recommended priority is shown.
6. Open Go-Live and confirm readiness score and items are visible.

## Regression Areas

- Enum conversion in SQLite.
- Seed data idempotency.
- KPI calculations when lists are empty.
- UI rendering when a ticket has missing optional detail.

## Known Gaps

- No browser automation yet.
- No Oracle execution test.
- No JRXML rendering test.
- No compiled Pro*C test.
