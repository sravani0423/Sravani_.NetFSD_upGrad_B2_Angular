using System;

namespace Project_1
{
   
    public class Student
    {
        
        public double CalculateAverage(int m1, int m2, int m3)
        {
            double avg = (m1 + m2 + m3) / 3.0;
            return avg;
        }

       
        public string GetGrade(double average)
        {
            if (average >= 80)
                return "A";
            else if (average >= 60)
                return "B";
            else if (average >= 50)
                return "C";
            else
                return "F";
        }
    }

    internal class Student_Grade_Calculator
    {
        static void Main(string[] args)
        {
            Student s = new Student();

            Console.Write("Enter marks for subject 1: ");
            int m1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter marks for subject 2: ");
            int m2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter marks for subject 3: ");
            int m3 = Convert.ToInt32(Console.ReadLine());

            double average = s.CalculateAverage(m1, m2, m3);
            string grade = s.GetGrade(average);

            Console.WriteLine("Average = " + average);
            Console.WriteLine("Grade = " + grade);
        }
    }
}