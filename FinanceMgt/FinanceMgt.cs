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
}