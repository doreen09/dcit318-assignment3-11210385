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

}