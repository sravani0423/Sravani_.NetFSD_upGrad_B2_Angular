using System;

namespace Practice_of_Hands_on
{
    internal class Employee_Bonus_Calculator
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Experience (years): ");
            int experience = Convert.ToInt32(Console.ReadLine());

            double bonusPercentage;

        
            if (experience < 2)
            {
                bonusPercentage = 0.05;
            }
            else if (experience <= 5)
            {
                bonusPercentage = 0.10;
            }
            else
            {
                bonusPercentage = 0.15;
            }

   
            double bonus = salary > 0 ? salary * bonusPercentage : 0;

            double finalSalary = salary + bonus;

      
            Console.WriteLine("\nEmployee: " + name);
            Console.WriteLine("Bonus: " + bonus.ToString("F2"));
            Console.WriteLine("Final Salary: " + finalSalary.ToString("F2"));

            Console.ReadLine();
        }
    }
}