USE ecommappdb;
GO

SELECT 
    c.first_name + ' ' + c.last_name AS full_name,
    t.total_value,
    CASE 
        WHEN t.total_value > 10000 THEN 'Premium'
        WHEN t.total_value BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS customer_type
FROM customers c
JOIN
(
    SELECT 
        o.customer_id, 
        SUM(oi.quantity * oi.list_price) AS total_value
    FROM orders o
    INNER JOIN order_items oi 
        ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) t
ON c.customer_id = t.customer_id

UNION

SELECT 
    first_name + ' ' + last_name AS full_name,
    0 AS total_value,
    'No Orders' AS customer_type
FROM customers
WHERE customer_id NOT IN (SELECT customer_id FROM orders);