using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses;

public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
{
    public ExpenseValidator()
    {
        RuleFor(expense => expense.Title)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(expense => expense.Amount)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.AMOUNT_REQUIRED)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.AMOUNT_GREATER_THAN_ZERO);
        RuleFor(expense => expense.Date)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EXPENSES_DATE_REQUIRED)
            .Must(date => date <= DateTime.UtcNow)
            .WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_BE_IN_FUTURE);
        RuleFor(expense => expense.PaymentType)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }
}
