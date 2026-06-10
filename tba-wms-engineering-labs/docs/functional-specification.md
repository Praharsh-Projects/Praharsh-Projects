# Functional Specification

## Purpose

WMS Ops Console provides a compact internal dashboard for warehouse software support teams. It helps analysts review operational status, identify risks, and prepare structured support or go-live conversations.

## Users

- Software engineer supporting a WMS product.
- Service desk analyst diagnosing warehouse software issues.
- Implementation consultant preparing go-live readiness checks.
- Product owner reviewing customer requirements and acceptance criteria.

## Functional Areas

### Dashboard

- Shows total SKUs, reorder risk, pick completion, open work orders, overdue work orders, service desk load, and go-live readiness.
- Lists priority exceptions with the operational area, signal, and next action.

### Operations

- Lists inventory items by SKU, zone, available quantity, reorder point, and risk.
- Lists work orders with customer, area, status, due date, and acceptance criteria.
- Lists pick tasks with picker, quantity, status, and release time.

### Service Desk

- Lists tickets with current priority, status, root-cause context, and next action.
- Recommends ticket priority from operational keywords and ticket age.

### Go-Live Readiness

- Tracks readiness requirements by area, owner, status, and target date.
- Calculates a readiness score from item status.

## Non-Functional Requirements

- The app must run locally from a clean .NET 8 restore/build.
- The data layer must use a reproducible seed path.
- Business logic must be covered by unit tests.
- Documentation must make limitations explicit.

## Out Of Scope

- Production authentication and role-based access control.
- Live integration with a commercial WMS, ERP, TOS, or Oracle instance.
- Real customer data.
- Compiled Pro*C or rendered Jaspersoft reports.
