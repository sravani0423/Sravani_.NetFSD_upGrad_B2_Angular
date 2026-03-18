using System;

namespace Project_1
{
    
    public class Calculator
    {
      
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    internal class Simple_Calculator_Using_Methods
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

           
            int num1 = 10;
            int num2 = 5;

            
            int addition = calc.Add(num1, num2);
            int subtraction = calc.Subtract(num1, num2);

           
            Console.WriteLine("Addition = " + addition);
            Console.WriteLine("Subtraction = " + subtraction);
        }
    }
}