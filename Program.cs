using System;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            var account = new BankAccount("michal", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owners} with {account.Balance} initial balance.");
        
            var account2 = new BankAccount("michal", 1000);
            Console.WriteLine($"Account {account2.Number} was created for {account2.Owners} with {account2.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            try
            {
                var account3 = new BankAccount("john", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(account2.GetAccountHistory());
        }
    }
}
