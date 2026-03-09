USE EcommAppDb;
GO

CREATE PROCEDURE sp_store_revenue_cursor
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        DECLARE @order_id INT
        DECLARE @store_id INT
        DECLARE @revenue DECIMAL(10,2)

        -- Cursor declaration
        DECLARE order_cursor CURSOR FOR
        SELECT order_id, store_id
        FROM orders
        WHERE order_status = 4;

        -- Temporary table
        CREATE TABLE #temp_revenue
        (
            store_id INT,
            order_id INT,
            revenue DECIMAL(10,2)
        );

        OPEN order_cursor

        FETCH NEXT FROM order_cursor INTO @order_id, @store_id

        WHILE @@FETCH_STATUS = 0
        BEGIN

            -- Calculate revenue
            SELECT @revenue =
            SUM(quantity * list_price * (1 - discount))
            FROM order_items
            WHERE order_id = @order_id;

            -- Insert result
            INSERT INTO #temp_revenue
            VALUES(@store_id, @order_id, ISNULL(@revenue,0));

            FETCH NEXT FROM order_cursor INTO @order_id, @store_id

        END

        CLOSE order_cursor
        DEALLOCATE order_cursor

        COMMIT TRANSACTION

        -- Store wise revenue summary
        SELECT
            store_id,
            SUM(revenue) AS total_store_revenue
        FROM #temp_revenue
        GROUP BY store_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

EXEC sp_store_revenue_cursor;