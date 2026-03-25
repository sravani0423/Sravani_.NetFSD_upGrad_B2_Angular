using System;
using System.IO;

namespace Handling
{
    internal class DirectoryAnalyzer
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter root directory path: ");
                string path = Console.ReadLine();

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Invalid directory path.");
                    return;
                }

                DirectoryInfo dir = new DirectoryInfo(path);

                DirectoryInfo[] subDirs = dir.GetDirectories();

                Console.WriteLine("\nSubdirectories and File Count:\n");

                foreach (DirectoryInfo subDir in subDirs)
                {
                    int fileCount = subDir.GetFiles().Length;

                    Console.WriteLine("Folder Name : " + subDir.Name);
                    Console.WriteLine("File Count  : " + fileCount);
                    Console.WriteLine("---------");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to some folders.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}