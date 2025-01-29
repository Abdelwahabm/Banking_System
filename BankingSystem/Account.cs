using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace BankingSystem
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string Name = "Unnamed Account", double Balance = 0.05)
        {
            this.Name = Name;
            this.Balance = Balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Name} Balance:{Balance:C}";
        }

        /* public static Account operator+ (Account Lhs, Account Rhs)
         {
             return new Account(Lhs.Name + Rhs.Name, Lhs.Balance + Rhs.Balance);
         }**/

        public static double operator +(Account Lhs, Account Rhs)
        {
            return Lhs.Balance + Rhs.Balance ;
        }
    }
}
