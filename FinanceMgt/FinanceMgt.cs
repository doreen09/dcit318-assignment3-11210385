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


    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
    
     public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[BankTransfer] Processing {transaction.Category} for {transaction.Amount:C} on {transaction.Date:d}.");
        }
    }

    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[MobileMoney] Sent {transaction.Amount:C} for {transaction.Category} on {transaction.Date:d}.");
        }
    }

    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[CryptoWallet] Debited {transaction.Amount:C} for {transaction.Category} on {transaction.Date:d} (network fee included).");
        }
    }
}