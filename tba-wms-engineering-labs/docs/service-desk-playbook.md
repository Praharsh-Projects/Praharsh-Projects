# Service Desk and Problem Management Playbook

## Intake

Capture:
- affected warehouse area
- user or role
- customer/order reference if available
- exact error message or visible symptom
- time first observed
- whether picking, packing, receiving, label printing, or dispatch is blocked

## Triage

Priority guidance:
- Critical: go-live blocker, full outage, cannot pick, interface down.
- High: label print blocked, stock mismatch, aged ticket over 24 hours.
- Medium: training issue, slow workflow, aged ticket over 8 hours.
- Low: informational request or cosmetic issue.

## Root-Cause Notes

Record the current hypothesis without overclaiming certainty:
- configuration change
- data mismatch
- user permission issue
- device/printer mapping issue
- upstream interface failure
- workflow misunderstanding

## Change and Release Support

Before change:
- document the user story or defect
- list acceptance criteria
- identify data and interface impact
- agree test evidence

After change:
- run smoke checks
- update release notes
- close or reclassify service desk tickets
- update the training note if user workflow changed

## Go-Live Support

During go-live:
- monitor open tickets
- review critical and high issues first
- keep an escalation contact list visible
- log every workaround and its owner
- separate data issues from code defects where possible
