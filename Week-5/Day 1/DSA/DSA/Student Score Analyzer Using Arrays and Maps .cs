using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA
{
    internal class Student_Score_Analyzer_Using_Arrays_and_Maps
    {
        static void Main(string[] args)
        {
            // Store marks in array
            int[] marks = { 78, 85, 90, 67, 88 };
            int threshold = 80;

            // Total using Reduce equivalent (Sum)
            int total = marks.Sum();

            // Average
            double average = marks.Average();

            // Highest score
            int highest = marks.Max();

            // Filter students above threshold
            var aboveThreshold = marks.Where(m => m > threshold).ToArray();
            int countAboveThreshold = aboveThreshold.Length;

            // Map (Dictionary) for subject-highest score
            Dictionary<string, int> subjectHighest = new Dictionary<string, int>();
            subjectHighest["Math"] = 90;
            subjectHighest["Science"] = 88;
            subjectHighest["English"] = 85;

            // Display results
            Console.WriteLine("Total Marks: " + total);
            Console.WriteLine("Average Marks: " + average);
            Console.WriteLine("Students above " + threshold + ": " + countAboveThreshold);
            Console.WriteLine("Highest Score: " + highest);

            Console.WriteLine("\nSubject Highest Scores:");
            foreach (var subject in subjectHighest)
            {
                Console.WriteLine(subject.Key + " : " + subject.Value);
            }
        }
    }
}