using System;

namespace BankApplication
{
    class GiftCardAccount : BankAccount
    {
        private decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string OwnerId, decimal initialBalance, decimal monthlyDeposit = 0) : base(OwnerId, initialBalance)
            => _monthlyDeposit = monthlyDeposit;

        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }

    } 
}
