using Abstractions.Repositories;
using Application.Application.Users;
using Application.Contracts.Users;
using Models.Users;

namespace Application.Application.Administrators;

public class AdministratorService : IAdminService
{
    private readonly IAdministratorRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public AdministratorService(IAdministratorRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public async Task<LoginResult> Login(long pin)
    {
        bool user = await _repository.CheckPassword(pin);

        if (user is false)
        {
            return new LoginResult.WrongPassword();
        }

        _currentUserManager.Administrator = new Administrator(pin);

        return new LoginResult.Success();
    }

    public void LogOut()
    {
        _currentUserManager.Administrator = null;
        return;
    }
}