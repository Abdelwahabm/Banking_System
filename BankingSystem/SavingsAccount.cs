using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string Name = "Unnamed Account", double Balance = 0.0, double interest = 0.05)
            : base (Name,Balance)
        {
            Interest = interest;
        }

        public override bool Deposit(double amount)
        {
            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount);
        }

        public double Interest { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Account Type: Saving Account ";
        }

    }
}
