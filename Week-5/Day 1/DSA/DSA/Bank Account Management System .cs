using System;

namespace DSA
{
    public class BankAccount
    {
        private int accountNumber;
        private double balance;

       
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        
        public double Balance
        {
            get { return balance; }
        }

   
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount.");
                return;
            }

            balance += amount;
            Console.WriteLine("Deposited: " + amount);
            Console.WriteLine("Current Balance = " + balance);
        }

     
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
            Console.WriteLine("Current Balance = " + balance);
        }
    }

    internal class Bank_Account_Management_System
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.AccountNumber = 101;

            account.Deposit(5000);
            account.Withdraw(2000);

            Console.WriteLine("Final Balance = " + account.Balance);
        }
    }
}