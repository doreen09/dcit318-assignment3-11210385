using System;
using System.Collections.Generic;

namespace FinanceManagementSystem
{
    public record Transaction(
        int Id,
        DateTime Date,
        decimal Amount,
        string Category
        );

    //created an interface
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }

    //Created three concrete classes implementing the interface
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[BankTransfer] {transaction.Category}: {transaction.Amount:C}");
        }
    }

    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[MobileMoney] {transaction.Category}: {transaction.Amount:C}");
        }
    }

    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[CryptoWallet] {transaction.Category}: {transaction.Amount:C}");
        }
    }


    //created a General Account and Seal a Specialized Account
    public class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public virtual void ApplyTransaction(Transaction transaction)
        {
            Balance -= transaction.Amount;
        }
    }

    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance) { }

        public override void ApplyTransaction(Transaction transaction)
        {
            if (transaction.Amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                Balance -= transaction.Amount;
                Console.WriteLine($"Updated balance: {Balance:C}");
            }
        }
    }
    
    
//integration
    public class FinanceApp
    {
        private readonly List<Transaction> _transactions = new();

        public void Run()
        {
            //instantiated savings account
            var savings = new SavingsAccount("SA-001", 1000m);

            //created three transactions
            var t1 = new Transaction(1, DateTime.Today, 120m, "Groceries");
            var t2 = new Transaction(2, DateTime.Today, 250m, "Utilities");
            var t3 = new Transaction(3, DateTime.Today, 80m, "Entertainment");

            //processors
            ITransactionProcessor p1 = new MobileMoneyProcessor();
            ITransactionProcessor p2 = new BankTransferProcessor();
            ITransactionProcessor p3 = new CryptoWalletProcessor();

            p1.Process(t1);
            p2.Process(t2);
            p3.Process(t3);

            //applying transaction to the savingsaccount
            savings.ApplyTransaction(t1);
            savings.ApplyTransaction(t2);
            savings.ApplyTransaction(t3);

            //tracking transactions
            _transactions.AddRange(new[] { t1, t2, t3 });
        }
    }

    public static class FinanceManagementApp
    {
        public static void Main()
        {
            var app = new FinanceApp();
            app.Run();
        }
    }

}