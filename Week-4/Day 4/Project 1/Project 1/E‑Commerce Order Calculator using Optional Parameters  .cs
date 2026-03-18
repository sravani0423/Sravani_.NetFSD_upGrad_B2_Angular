using System;

namespace Project_1
{
    public class OrderCalculator
    {
     
        public void CalculateFinalAmount(double price, int quantity, double discountPercent = 0, double shippingCharge = 50)
        {
            double subtotal = price * quantity;
            double discountAmount = subtotal * discountPercent / 100;
            double finalAmount = subtotal - discountAmount + shippingCharge;

            Console.WriteLine("Subtotal = " + subtotal);
            Console.WriteLine("Discount Applied = " + discountAmount);
            Console.WriteLine("Shipping Charge = " + shippingCharge);
            Console.WriteLine("Final Payable Amount = " + finalAmount);
            Console.WriteLine();
        }
    }

    internal class E_Commerce_Order_Calculator_using_Optional_Parameters
    {
        static void Main(string[] args)
        {
            OrderCalculator order = new OrderCalculator();

            Console.WriteLine("Order 1 (No discount, default shipping)");
            order.CalculateFinalAmount(500, 2);

            Console.WriteLine("Order 2 (10% discount, default shipping)");
            order.CalculateFinalAmount(500, 2, 10);

            Console.WriteLine("Order 3 (10% discount, custom shipping)");
            order.CalculateFinalAmount(500, 2, 10, 100);
        }
    }
}