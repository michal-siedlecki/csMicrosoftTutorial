using System;
using System.Collections.Generic;

namespace BankApplication
{
    class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
          
        }
       
        private List<Transaction> allTransactions = new List<Transaction>();
        private static int accountNumberSeed = 1234567890;
        public virtual void PerformMonthEndTransactions() { }
        private readonly decimal minimumBalance;
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            this.minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public void MakeDeposit (decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal (decimal amonut, DateTime date, string note)
        {
            if (amonut < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amonut), "Amount of withdrawal must be positive");
            }
            if (Balance - amonut < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var transaction = new Transaction(amonut, date, note);
            allTransactions.Add(transaction);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

    }
}
