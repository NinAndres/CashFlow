using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities;
public class Tag
{
    public int Id { get; set; }
    public Tags Value { get; set; }
    public long ExpenseId { get; set; }
    public Expense Expense { get; set; } = default!;
}
