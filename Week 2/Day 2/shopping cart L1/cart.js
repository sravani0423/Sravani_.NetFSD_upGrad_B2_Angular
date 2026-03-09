export const calculateTotal = (products) => {
    return products
        .map(product => product.price * product.quantity) 
        .reduce((total, value) => total + value, 0); 
};


export const generateInvoice = (products) => {
    const items = products.map(
        product => `
Product: ${product.name}
Price: ₹${product.price}
Quantity: ${product.quantity}
Subtotal: ₹${product.price * product.quantity}
`
    ).join("\n");

    const total = calculateTotal(products);

    return `
    invoice
${items}
Total Cart Value: ₹${total}
`;
};