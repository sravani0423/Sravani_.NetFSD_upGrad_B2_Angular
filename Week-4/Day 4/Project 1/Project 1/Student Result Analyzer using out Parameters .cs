using System;

namespace Project_1
{
    public class ResultAnalyzer
    {
        
        public void CalculateResult(int m1, int m2, int m3, out int totalMarks, out double averageMarks)
        {
            totalMarks = m1 + m2 + m3;
            averageMarks = totalMarks / 3.0;
        }
    }

    internal class Student_Result_Analyzer_using_out_Parameters
    {
        static void Main(string[] args)
        {
            ResultAnalyzer analyzer = new ResultAnalyzer();
            char choice;

            do
            {
                int m1, m2, m3;

             
                Console.Write("Enter marks for Subject 1 (0-100): ");
                m1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter marks for Subject 2 (0-100): ");
                m2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter marks for Subject 3 (0-100): ");
                m3 = Convert.ToInt32(Console.ReadLine());

                if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
                {
                    Console.WriteLine("Invalid marks! Please enter marks between 0 and 100.");
                }
                else
                {
                    int total;
                    double average;

                    analyzer.CalculateResult(m1, m2, m3, out total, out average);

                    Console.WriteLine("Total Marks = " + total);
                    Console.WriteLine("Average Marks = " + average);

                    if (average >= 40)
                        Console.WriteLine("Result: Pass");
                    else
                        Console.WriteLine("Result: Fail");
                }

                Console.Write("Do you want to enter another student? (y/n): ");
                choice = Convert.ToChar(Console.ReadLine());

            } while (choice == 'y' || choice == 'Y');
        }
    }
}