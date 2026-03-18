using System;

namespace DSA
{
    
    public class Vehicle
    {
        private double rentalRatePerDay;

        public string Brand { get; set; }

       
        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Rental rate cannot be negative.");
                }
                else
                {
                    rentalRatePerDay = value;
                }
            }
        }

        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days.");
                return 0;
            }

            return RentalRatePerDay * days;
        }
    }

    
    public class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = base.CalculateRental(days);
            return total + 500; // Insurance charge
        }
    }

    public class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = base.CalculateRental(days);
            return total - (total * 0.05); // 5% discount
        }
    }

    internal class Vehicle_Rental_System
    {
        static void Main(string[] args)
        {
            
            Vehicle car = new Car();
            car.Brand = "Toyota";
            car.RentalRatePerDay = 2000;

            int days = 3;

            Console.WriteLine("Car Total Rental = " + car.CalculateRental(days));

            Vehicle bike = new Bike();
            bike.Brand = "Yamaha";
            bike.RentalRatePerDay = 500;

            Console.WriteLine("Bike Total Rental = " + bike.CalculateRental(days));
        }
    }
}
