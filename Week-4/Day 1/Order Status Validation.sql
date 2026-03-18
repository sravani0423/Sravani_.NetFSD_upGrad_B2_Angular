USE EcommAppDb;
-- order status validation
GO

CREATE TRIGGER trg_validate_order_status
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY

        -- Check if order_status is set to Completed (4)
        IF EXISTS (
            SELECT 1
            FROM inserted
            WHERE order_status = 4 AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR ('Cannot mark order as Completed. shipped_date cannot be NULL',16,1);
            ROLLBACK TRANSACTION;
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- test the trigger

UPDATE orders
SET order_status = 4
WHERE order_id = 101;

-- reset status
UPDATE orders
SET order_status = 1
WHERE order_id = 101;