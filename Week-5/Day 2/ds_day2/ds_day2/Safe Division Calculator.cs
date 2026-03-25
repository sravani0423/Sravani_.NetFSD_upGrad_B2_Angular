using System;

namespace ds_day2
{
    
    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    internal class Safe_Division_Calculator
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            int numerator, denominator;

            Console.Write("Enter Numerator: ");
            int.TryParse(Console.ReadLine(), out numerator);

            Console.Write("Enter Denominator: ");
            int.TryParse(Console.ReadLine(), out denominator);

            calc.Divide(numerator, denominator);

            
            Console.WriteLine("Program is still running...");
        }
    }
}