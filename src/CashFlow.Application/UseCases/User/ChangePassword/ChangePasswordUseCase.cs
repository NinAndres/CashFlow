using CashFlow.Communication.Requests;
using CashFlow.Domain.Security.Cryptography;

namespace CashFlow.Application.UseCases.User.ChangePassword;
public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly IPasswordEncripter _passwordEncripter;
    public ChangePasswordUseCase()
    {

    }
    public Task Execute(RequestChangePasswordJson request)
    {

    }
}
