using System;

namespace BankApplication
{
    class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string OwnerId, decimal initialBalance) : base(OwnerId, initialBalance)
        {

        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = (Balance * 0.002m)/12;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
    }
}
