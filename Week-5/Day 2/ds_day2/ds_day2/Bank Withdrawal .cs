using System;

namespace ds_day2
{
    
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

   
    class BankAccount
    {
        private double balance;

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
              
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawal successful! Remaining Balance: {balance}");
        }
    }

    internal class Bank_Withdrawal
    {
        static void Main(string[] args)
        {
            double balance, withdrawAmount;

            Console.Write("Enter Balance: ");
            double.TryParse(Console.ReadLine(), out balance);

            Console.Write("Enter Withdrawal Amount: ");
            double.TryParse(Console.ReadLine(), out withdrawAmount);

            BankAccount account = new BankAccount(balance);

            try
            {
         
                account.Withdraw(withdrawAmount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                
                Console.WriteLine("Transaction process completed.");
            }

            Console.WriteLine("Program continues...");
        }
    }
}