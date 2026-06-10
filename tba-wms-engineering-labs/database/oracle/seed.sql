INSERT INTO wms_inventory_item (sku, description, zone_code, on_hand_qty, allocated_qty, reorder_point, risk_code)
VALUES ('PAL-100', 'Euro pallet', 'A1', 180, 42, 80, 'Healthy');

INSERT INTO wms_inventory_item (sku, description, zone_code, on_hand_qty, allocated_qty, reorder_point, risk_code)
VALUES ('LBL-220', 'Thermal location label', 'PACK', 55, 38, 40, 'Reorder');

INSERT INTO wms_service_ticket (ticket_number, summary, system_area, priority_code, status_code, opened_utc, root_cause_hypothesis, next_action)
VALUES ('SD-301', 'Label print queue blocked for outbound wave', 'Outbound', 'High', 'InProgress', SYSTIMESTAMP, 'Printer mapping changed after workstation replacement', 'Verify printer mapping and re-test label format');

COMMIT;
