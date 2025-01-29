namespace inheri
{
    internal class Program
    {
        public class Account
        {
            public string Name { get; set; }
            public double Balance { get; set; }

            public Account(string Name = "Unnamed Account", double Balance = 0.0)
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

            // Overloading + operator to sum balances of two accounts
            public static double operator +(Account acc1, Account acc2)
            {
                return acc1.Balance + acc2.Balance;
            }

            public override string ToString()
            {
                return $"{Name}: {Balance:C}";
            }
        }

        public class SavingsAccount : Account
        {
            public double InterestRate { get; set; }

            public SavingsAccount(string Name = "Unnamed Savings Account", double Balance = 0.0, double InterestRate = 0.01)
                : base(Name, Balance)
            {
                this.InterestRate = InterestRate;
            }

            public void ApplyInterest()
            {
                Balance += Balance * InterestRate;
            }

            public override string ToString()
            {
                return $"{base.ToString()} (Savings, Interest: {InterestRate:P})";
            }
        }

        public class CheckingAccount : Account
        {
            public double WithdrawalFee { get; set; } = 1.50;

            public CheckingAccount(string Name = "Unnamed Checking Account", double Balance = 0.0)
                : base(Name, Balance)
            {
            }

            public override bool Withdraw(double amount)
            {
                double totalAmount = amount + WithdrawalFee;
                return base.Withdraw(totalAmount);
            }

            public override string ToString()
            {
                return $"{base.ToString()} (Checking, Fee: {WithdrawalFee:C})";
            }
        }

        public class TrustAccount : Account
        {
            public double InterestRate { get; set; }
            private int withdrawalCount = 0;
            private const int MaxWithdrawals = 3;

            public TrustAccount(string Name = "Unnamed Trust Account", double Balance = 0.0, double InterestRate = 0.02)
                : base(Name, Balance)
            {
                this.InterestRate = InterestRate;
            }

            public override bool Deposit(double amount)
            {
                if (amount >= 5000)
                {
                    Balance += 50; // Bonus of $50
                }
                return base.Deposit(amount);
            }

            public override bool Withdraw(double amount)
            {
                if (withdrawalCount < MaxWithdrawals && amount <= Balance * 0.2)
                {
                    withdrawalCount++;
                    return base.Withdraw(amount);
                }
                return false; // Withdrawal fails if it exceeds limits
            }

            public override string ToString()
            {
                return $"{base.ToString()} (Trust, Interest: {InterestRate:P}, Withdrawals left: {MaxWithdrawals - withdrawalCount})";
            }
        }

        public static class AccountUtil
        {
            public static void Display(List<Account> accounts)
            {
                Console.WriteLine("\n=== Accounts ==========================================");
                foreach (var acc in accounts)
                {
                    Console.WriteLine(acc);
                }
            }

            public static void Deposit(List<Account> accounts, double amount)
            {
                Console.WriteLine("\n=== Depositing to Accounts =================================");
                foreach (var acc in accounts)
                {
                    if (acc.Deposit(amount))
                        Console.WriteLine($"Deposited {amount} to {acc}");
                    else
                        Console.WriteLine($"Failed Deposit of {amount} to {acc}");
                }
            }

            public static void Withdraw(List<Account> accounts, double amount)
            {
                Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
                foreach (var acc in accounts)
                {
                    if (acc.Withdraw(amount))
                        Console.WriteLine($"Withdrew {amount} from {acc}");
                    else
                        Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
                }
            }
        }

        
        
            static void Main()
            {
                // Accounts
                var accounts = new List<Account>();
                accounts.Add(new Account());
                accounts.Add(new Account("Larry"));
                accounts.Add(new Account("Moe", 2000));
                accounts.Add(new Account("Curly", 5000));

                AccountUtil.Display(accounts);
                AccountUtil.Deposit(accounts, 1000);
                AccountUtil.Withdraw(accounts, 2000);

                // Savings
                List<Account> savAccounts = new List<Account>();
                savAccounts.Add(new SavingsAccount());
                savAccounts.Add(new SavingsAccount("Superman"));
                savAccounts.Add(new SavingsAccount("Batman", 2000));
                savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

                AccountUtil.Display(savAccounts);
                AccountUtil.Deposit(savAccounts, 1000);
                AccountUtil.Withdraw(savAccounts, 2000);

                // Checking
                List<Account> checAccounts = new List<Account>();
                checAccounts.Add(new CheckingAccount());
                checAccounts.Add(new CheckingAccount("Larry2"));
                checAccounts.Add(new CheckingAccount("Moe2", 2000));
                checAccounts.Add(new CheckingAccount("Curly2", 5000));

                AccountUtil.Display(checAccounts);
                AccountUtil.Deposit(checAccounts, 1000);
                AccountUtil.Withdraw(checAccounts, 2000);
                AccountUtil.Withdraw(checAccounts, 2000);

                // Trust
                List<Account> trustAccounts = new List<Account>();
                trustAccounts.Add(new TrustAccount());
                trustAccounts.Add(new TrustAccount("Superman2"));
                trustAccounts.Add(new TrustAccount("Batman2", 2000));
                trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

                AccountUtil.Display(trustAccounts);
                AccountUtil.Deposit(trustAccounts, 1000);
                AccountUtil.Deposit(trustAccounts, 6000);
                AccountUtil.Withdraw(trustAccounts, 2000);
                AccountUtil.Withdraw(trustAccounts, 3000);
                AccountUtil.Withdraw(trustAccounts, 500);
                Console.WriteLine();
            }
        }

    
}
