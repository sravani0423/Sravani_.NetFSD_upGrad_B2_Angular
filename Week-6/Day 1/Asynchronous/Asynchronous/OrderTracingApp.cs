using System;
using System.Diagnostics;
using System.IO;

namespace Asynchronous
{
    internal class OrderTracingApp
    {
        static void Main(string[] args)
        {
          
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener("OrderLog.txt"));
            Trace.AutoFlush = true;

            try
            {
                Trace.WriteLine("Order processing started...");

                ValidateOrder();
                ProcessPayment();
                UpdateInventory();
                GenerateInvoice();

                Trace.TraceInformation("Order processed successfully.");
                Console.WriteLine("Order completed successfully. Check log file.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine("Order processing failed. Check log file.");
            }
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Step 1: Validating order...");
            Console.WriteLine("Validating order...");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Step 2: Processing payment...");
            Console.WriteLine("Processing payment...");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Step 3: Updating inventory...");
            Console.WriteLine("Updating inventory...");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Generating invoice...");
            Console.WriteLine("Generating invoice...");
        }
    }
}