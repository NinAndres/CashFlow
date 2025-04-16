using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Responses;

public class ResponseExpenseJson
{
    public List<ResponseShortExpensesJson> Expenses { get; set; } = [];
}
