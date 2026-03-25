using System;
using System.IO;

namespace Handling
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter folder path: ");
                string folderPath = Console.ReadLine();

                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid directory path.");
                    return;
                }

                string[] files = Directory.GetFiles(folderPath);
                int fileCount = 0;

                Console.WriteLine("\nFile Details:\n");

                foreach (string file in files)
                    fileCount = NewMethod(fileCount, file);

                Console.WriteLine("\nTotal Files: " + fileCount);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Access to the folder is denied.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }

        private static int NewMethod(int fileCount, string file)
        {
            FileInfo fi = new FileInfo(file);  

            Console.WriteLine("File Name      : " + fi.Name);
            Console.WriteLine("File Size (KB) : " + (fi.Length / 1024.0).ToString("F2"));
            Console.WriteLine("Created On     : " + fi.CreationTime);
            Console.WriteLine("-----");

            return fileCount + 1;
        }
    }
}