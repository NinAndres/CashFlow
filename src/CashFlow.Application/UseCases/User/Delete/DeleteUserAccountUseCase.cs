
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Services.LoggedUser;
using System.Runtime.InteropServices;

namespace CashFlow.Application.UseCases.User.Delete;
public class DeleteUserAccountUseCase : IDeleteUserAccountUseCase
{
    private readonly IUserWhiteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;
    public DeleteUserAccountUseCase(
        IUserWhiteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        ILoggedUser loggedUser)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
    }

    public async Task Execute()
    {
        var loggedUser = await _loggedUser.Get();

        await _repository.Delete(loggedUser);

        await _unitOfWork.Commit();
    }
}
