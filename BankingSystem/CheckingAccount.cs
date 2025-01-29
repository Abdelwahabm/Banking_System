using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string Name = "Unnamed Account", double Balance = 0.0, double fee= 1.5)
            : base (Name,Balance)
        {
            Fee = fee;
        }

        public double Fee { get;  set; }

        public override bool Deposit(double amount)
        {
            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount+Fee);
        }

        public override string ToString()
        {
            return $"{base.ToString()} Account Type: Checking Account ";
        }

    }
}
