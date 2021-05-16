using System;
using System.Text;

namespace BankApplication
{
    class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string owners, decimal initialBalance) : base(owners, initialBalance)
        {

        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = (Balance * 0.001m)/12;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
    }
}
