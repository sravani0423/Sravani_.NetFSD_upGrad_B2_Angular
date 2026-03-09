USE EcommAppDb;
GO

-- Drop trigger if exists
DROP TRIGGER IF EXISTS trg_update_stock_after_insert;
GO

-- Create Trigger
CREATE TRIGGER trg_update_stock_after_insert
ON order_items
AFTER INSERT
AS
BEGIN
    DECLARE @product_id INT;
    DECLARE @quantity INT;
    DECLARE @order_id INT;
    DECLARE @store_id INT;
    DECLARE @current_stock INT;

    SELECT 
        @product_id = product_id,
        @quantity = quantity,
        @order_id = order_id
    FROM inserted;

    SELECT @store_id = store_id
    FROM orders
    WHERE order_id = @order_id;

    SELECT @current_stock = quantity
    FROM stocks
    WHERE product_id = @product_id
    AND store_id = @store_id;

    IF @current_stock < @quantity
    BEGIN
        RAISERROR('Stock is insufficient for this order',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE stocks
    SET quantity = quantity - @quantity
    WHERE product_id = @product_id
    AND store_id = @store_id;
END
GO


-- Insert order (order_id auto generated)
INSERT INTO orders(customer_id, order_status, order_date, store_id)
VALUES (1,1,GETDATE(),1);

-- Store generated order_id
DECLARE @last_order_id INT = SCOPE_IDENTITY();

-- Insert order item
INSERT INTO order_items(item_id, order_id, product_id, quantity, list_price)
VALUES (30, @last_order_id, 5, 3, 200);

-- Check stock
SELECT *
FROM stocks
WHERE product_id = 5;