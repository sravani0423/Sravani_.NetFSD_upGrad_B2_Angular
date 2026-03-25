using System;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class AsynchronousFileLogger  
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started...\n");

            Task log1 = WriteLogAsync("User logged in");
            Task log2 = WriteLogAsync("File uploaded");
            Task log3 = WriteLogAsync("Error occurred");

            Console.WriteLine("Main thread is free to do other work...\n");

            await Task.WhenAll(log1, log2, log3);

            Console.WriteLine("\nAll logs written successfully.");
        }

        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Starting log: {message}");

            await Task.Delay(2000); 

            Console.WriteLine($"Log written: {message}");
        }
    }
}