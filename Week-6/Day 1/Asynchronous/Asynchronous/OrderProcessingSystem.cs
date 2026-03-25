using System;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class OrderProcessingSystem
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Order Processing Started...\n");

            await ProcessOrderAsync();

            Console.WriteLine("\nOrder completed successfully!");
        }

        static async Task ProcessOrderAsync()
        {
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();
        }

     
        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying payment...");
            await Task.Delay(2000); 
            Console.WriteLine("Payment verified \n");
        }

      
        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking inventory...");
            await Task.Delay(3000); 
            Console.WriteLine("Inventory available \n");
        }

      
        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming order...");
            await Task.Delay(1500); 
            Console.WriteLine("Order confirmed \n");
        }
    }
}