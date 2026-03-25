using System;

namespace Asynchronous
{
    internal class Debugging_Incorrect_Discount_Calculation
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Discount Percentage: ");
                double discount = Convert.ToDouble(Console.ReadLine());

               
                double discountAmount = price * discount / 100;
                double finalPrice = price - discountAmount;

                Console.WriteLine("\n--- Bill Details ---");
                Console.WriteLine("Product Name   : " + productName);
                Console.WriteLine("Original Price : " + price);
                Console.WriteLine("Discount (%)   : " + discount);
                Console.WriteLine("Final Price    : " + finalPrice);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
