USE EcommAppDb;
GO

-- Remove procedure if it already exists
DROP PROCEDURE IF EXISTS sp_total_sales_per_store;
GO

-- Total sales per store
CREATE PROCEDURE sp_total_sales_per_store
AS
BEGIN
    SELECT 
        s.store_id,
        SUM(oi.quantity * oi.list_price) AS total_sales
    FROM stores s
    JOIN orders o ON s.store_id = o.store_id
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY s.store_id;
END
GO

EXEC sp_total_sales_per_store;
GO


-- Remove procedure if exists
DROP PROCEDURE IF EXISTS sp_orders_by_date_range;
GO

-- Orders by date range
CREATE PROCEDURE sp_orders_by_date_range
    @p_start_date DATE,
    @p_end_date DATE
AS
BEGIN
    SELECT 
        order_id,
        customer_id,
        order_date,
        order_status
    FROM orders
    WHERE order_date BETWEEN @p_start_date AND @p_end_date;
END
GO

EXEC sp_orders_by_date_range '2016-01-01','2016-12-31';
GO


-- Remove function if exists
DROP FUNCTION IF EXISTS fn_total_price_after_discount;
GO

-- Scalar function for price after discount
CREATE FUNCTION fn_total_price_after_discount
(
    @price DECIMAL(10,2),
    @discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @final_price DECIMAL(10,2);

    SET @final_price = @price - (@price * ISNULL(@discount,0));

    RETURN @final_price;
END
GO

SELECT dbo.fn_total_price_after_discount(1000,0.10) AS final_price;
GO


-- Remove function if exists
DROP FUNCTION IF EXISTS fn_top5_selling_products;
GO

-- Table valued function for top 5 selling products
CREATE FUNCTION fn_top5_selling_products()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_id,
        p.product_name,
        SUM(oi.quantity) AS total_sold
    FROM products p
    JOIN order_items oi ON p.product_id = oi.product_id
    GROUP BY p.product_id, p.product_name
    ORDER BY total_sold DESC
);
GO

SELECT * FROM dbo.fn_top5_selling_products();