CREATE OR REPLACE TRIGGER trg_wms_inventory_qty_check
BEFORE INSERT OR UPDATE ON wms_inventory_item
FOR EACH ROW
BEGIN
    IF :NEW.on_hand_qty < 0 OR :NEW.allocated_qty < 0 OR :NEW.reorder_point < 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Inventory quantities must not be negative');
    END IF;
END;
/

CREATE OR REPLACE TRIGGER trg_wms_ticket_priority_check
BEFORE INSERT OR UPDATE ON wms_service_ticket
FOR EACH ROW
BEGIN
    IF :NEW.priority_code NOT IN ('Low', 'Medium', 'High', 'Critical') THEN
        RAISE_APPLICATION_ERROR(-20002, 'Invalid service ticket priority');
    END IF;
END;
/
