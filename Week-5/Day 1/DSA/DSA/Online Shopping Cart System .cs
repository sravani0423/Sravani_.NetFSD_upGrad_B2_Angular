using System;

namespace DSA
{
   
    public class Product
    {
        private double price;

        public string Name { get; set; }

        
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative.");
                }
                else
                {
                    price = value;
                }
            }
        }

      
        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }

    
    public class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05); // 5% discount
        }
    }

   
    public class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15); // 15% discount
        }
    }

    internal class Online_Shopping_Cart_System
    {
        static void Main(string[] args)
        {
           
            Product electronics = new Electronics();
            electronics.Name = "Laptop";
            electronics.Price = 20000;

            Product clothing = new Clothing();
            clothing.Name = "Jacket";
            clothing.Price = 2000;

            Console.WriteLine("Electronics Final Price after 5% discount = " + electronics.CalculateDiscount());
            Console.WriteLine("Clothing Final Price after 15% discount = " + clothing.CalculateDiscount());
        }
    }
}