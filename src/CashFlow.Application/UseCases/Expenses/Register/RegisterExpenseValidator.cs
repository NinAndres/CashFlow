using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title)
                .NotEmpty()
                .WithMessage("Title is required.");
            RuleFor(expense => expense.Amount)
                .NotEmpty()
                .WithMessage("Amount is required.")
                .GreaterThan(0)
                .WithMessage("Amount must be greater than zero.");
            RuleFor(expense => expense.Date)
                .NotEmpty()
                .WithMessage("Date is required.")
                .Must(date => date <= DateTime.UtcNow)
                .WithMessage("Date cannot be in the future.");
            RuleFor(expense => expense.PaymentType)
                .IsInEnum()
                .WithMessage("Payment type is invalid.");
        }
    }
}
