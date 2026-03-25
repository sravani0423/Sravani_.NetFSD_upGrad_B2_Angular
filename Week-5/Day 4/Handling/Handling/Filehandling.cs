using System;
using System.IO;
using System.Text;

namespace Handling
{
    internal class Filehandling
    {
        static void Main(string[] args)
        {
            string filePath = "log.txt";

            try
            {
                while (true)
                {
                    Console.Write("Enter a message (or type 'exit' to stop): ");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                        break;

                    
                    byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    }

                    Console.WriteLine("Message written to file successfully.\n");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: You do not have permission to access the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }

            Console.WriteLine("Program ended.");
        }
    }
}
