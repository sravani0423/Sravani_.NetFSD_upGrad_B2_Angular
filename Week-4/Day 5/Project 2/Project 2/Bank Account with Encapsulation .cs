using System;

namespace Project_2
{
    // BankAccount class
    public class BankAccount
    {
        // Private balance field (Encapsulation)
        private double balance;

        // Deposit method
        public void Deposit(double amount)
        {
            balance += amount;
        }

        // Withdraw method
        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        // Method to get balance
        public double GetBalance()
        {
            return balance;
        }
    }

    internal class Bank_Account_with_Encapsulation
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.Deposit(1000);
            account.Withdraw(300);

            Console.WriteLine("Current Balance = " + account.GetBalance());
        }
    }
}