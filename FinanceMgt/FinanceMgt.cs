using System;

namespace FinanceManagementSystem.Models
{
    public record Transaction(
        int Id,
        DateOnly Date,
        decimal Amount,
        string Category
    );
}