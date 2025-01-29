using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class TrustAccount : SavingsAccount
    {
        private int counter = 0;
        public TrustAccount(string Name = "Unnamed Account", double Balance = 0.0, double interest = 0.05)
            : base(Name, Balance,interest)
        {}

        public override bool Deposit(double amount)
        {
            if (amount > 5000)
            {
                return base.Deposit(amount + 50);

            }
            else
            {
                return base.Deposit(amount);
            }
        }

        public override bool Withdraw(double amount)
        {
            counter++;

            if (amount <= (Balance * 0.2) && counter < 4)
            {
                
                return base.Withdraw(amount);
            }
            else
            {
                return false;
            }
 
        }

        public override string ToString()
        {
            return $"{Name} Balance:{Balance:C} Account Type: Trust Account ";
        }

    }
}
