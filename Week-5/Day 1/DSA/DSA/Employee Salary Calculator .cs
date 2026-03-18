using System;

namespace DSA
{
    // Base Class
    public class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        // Virtual method
        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    // Derived Class - Manager
    public class Manager : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20); // 20% bonus
        }
    }

    // Derived Class - Developer
    public class Developer : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10); // 10% bonus
        }
    }

    internal class Employee_Salary_Calculator
    {
        static void Main(string[] args)
        {
            // Polymorphism using base class reference
            Employee manager = new Manager();
            manager.Name = "Manager";
            manager.BaseSalary = 50000;

            Employee developer = new Developer();
            developer.Name = "Developer";
            developer.BaseSalary = 50000;

            Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
            Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
        }
    }
}
