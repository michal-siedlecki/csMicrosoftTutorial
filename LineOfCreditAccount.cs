using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string owners, decimal initialBalance) : base(owners, initialBalance)
        {

        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }
    }
}
