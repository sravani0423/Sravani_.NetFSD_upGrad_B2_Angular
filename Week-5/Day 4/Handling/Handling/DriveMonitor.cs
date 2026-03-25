using System;
using System.IO;

namespace Handling
{
    internal class DriveMonitor
    {
        static void Main(string[] args)
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.WriteLine("Drive Information:\n");

                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady) // important check
                    {
                        double totalSize = drive.TotalSize;
                        double freeSpace = drive.AvailableFreeSpace;

                        double freePercent = (freeSpace / totalSize) * 100;

                        Console.WriteLine("Drive Name   : " + drive.Name);
                        Console.WriteLine("Drive Type   : " + drive.DriveType);
                        Console.WriteLine("Total Size   : " + (totalSize / (1024 * 1024 * 1024)) + " GB");
                        Console.WriteLine("Free Space   : " + (freeSpace / (1024 * 1024 * 1024)) + " GB");

                        if (freePercent < 15)
                        {
                            Console.WriteLine("⚠ Warning: Low disk space!");
                        }

                        Console.WriteLine("-----");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

