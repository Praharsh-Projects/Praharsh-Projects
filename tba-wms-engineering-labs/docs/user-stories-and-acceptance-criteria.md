# User Stories and Acceptance Criteria

## US-01: Dashboard KPI Review

As a warehouse software support analyst, I want a single dashboard of operational KPIs so that I can see whether the warehouse is ready for the next shift or go-live review.

Acceptance criteria:
- Total SKUs, reorder SKUs, pick completion, open work orders, overdue work orders, service desk load, and readiness score are visible.
- Priority exceptions include inventory, service desk, and go-live signals.
- Empty or unavailable data does not crash the page.

## US-02: Inventory Risk Review

As an operations user, I want to see available quantity and reorder risk by SKU so that replenishment and allocation issues can be reviewed quickly.

Acceptance criteria:
- Available quantity is calculated from on-hand minus allocated.
- Items at or below reorder point are visible.
- Blocked items are distinguishable from healthy items.

## US-03: Work Order Status Review

As an implementation engineer, I want work orders to include acceptance criteria so that requirements can be checked against operational status.

Acceptance criteria:
- Work order number, customer, area, due time, status, and acceptance criteria are listed.
- Overdue non-completed orders are included in the dashboard KPI calculation.

## US-04: Service Desk Triage

As a service desk analyst, I want tickets to receive a recommended priority so that urgent warehouse issues are escalated consistently.

Acceptance criteria:
- Go-live, outage, cannot-pick, and interface-down wording escalates to Critical.
- Aged tickets or blocked warehouse activity escalates appropriately.
- The existing ticket priority is still shown for comparison.

## US-05: Go-Live Readiness

As a project lead, I want a readiness checklist so that implementation, training, data, and support risks can be discussed before go-live.

Acceptance criteria:
- Each readiness item has an area, requirement, status, owner, and target date.
- The readiness score updates from item status.
- At-risk items are visible in dashboard exceptions.
