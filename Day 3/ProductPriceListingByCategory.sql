INSERT INTO categories (category_name) VALUES
('Electronics'),
('Mobiles'),
('Laptops'),
('Accessories');
INSERT INTO brands (brand_name) VALUES
('Apple'),
('Samsung'),
('Dell'),
('HP'),
('Sony');
INSERT INTO products (product_name, brand_id, category_id, model_year, list_price) VALUES
('iPhone 14', 1, 2, 2023, 999.00),
('Galaxy S23', 2, 2, 2023, 899.00),
('Dell XPS 13', 3, 3, 2022, 1200.00),
('HP Pavilion', 4, 3, 2021, 700.00),
('Sony Headphones', 5, 4, 2022, 300.00),
('MacBook Air', 1, 3, 2023, 1300.00),
('Samsung Tablet', 2, 1, 2022, 650.00);

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;