import { calculateTotal, generateInvoice } from "./cart.js";

const cartProducts = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 500, quantity: 2 },
    { name: "Keyboard", price: 1500, quantity: 1 }
];

const totalValue = calculateTotal(cartProducts);

const invoice = generateInvoice(cartProducts);

console.log(invoice);