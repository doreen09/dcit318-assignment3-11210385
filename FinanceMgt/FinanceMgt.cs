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

}