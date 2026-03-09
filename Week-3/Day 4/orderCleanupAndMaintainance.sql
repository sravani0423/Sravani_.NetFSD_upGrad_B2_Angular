USE EcommAppDb;

SELECT *
INTO archived_orders
FROM orders
WHERE 1 = 0;

SET IDENTITY_INSERT archived_orders ON;

INSERT INTO archived_orders
(order_id, customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
SELECT 
order_id, customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

SET IDENTITY_INSERT archived_orders OFF;

DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) =
(
    SELECT COUNT(*)
    FROM orders o2
    WHERE o2.customer_id = orders.customer_id
    AND o2.order_status = 4
);

SELECT 
order_id,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders;

SELECT 
order_id,
order_date,
required_date,
shipped_date,
CASE
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS delivery_status
FROM orders;