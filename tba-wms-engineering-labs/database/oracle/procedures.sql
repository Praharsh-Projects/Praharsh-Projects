CREATE OR REPLACE PROCEDURE wms_recalculate_inventory_risk AS
BEGIN
    UPDATE wms_inventory_item
       SET risk_code = CASE
            WHEN on_hand_qty - allocated_qty <= 0 THEN 'Blocked'
            WHEN on_hand_qty - allocated_qty <= reorder_point THEN 'Reorder'
            WHEN on_hand_qty - allocated_qty <= reorder_point * 2 THEN 'Watch'
            ELSE 'Healthy'
       END,
       updated_utc = SYSTIMESTAMP;
END;
/

CREATE OR REPLACE PROCEDURE wms_mark_ticket_in_progress (
    p_ticket_number IN VARCHAR2
) AS
BEGIN
    UPDATE wms_service_ticket
       SET status_code = 'InProgress'
     WHERE ticket_number = p_ticket_number
       AND status_code = 'New';
END;
/
