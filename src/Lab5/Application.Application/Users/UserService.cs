using Abstractions.Repositories;
using Application.Contracts.Users;
using Models.Users;

namespace Application.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        CurrentUserManager = currentUserManager;
    }

    public CurrentUserManager CurrentUserManager { get; private set; }

    public async Task<LoginResult> Login(long username, long pin)
    {
        User? user = await _repository.FindUserByUsername(username, pin);

        if (user is null)
        {
            return new LoginResult.NotFound();
        }

        CurrentUserManager.User = user;
        return new LoginResult.Success();
    }

    public async Task<long?> CheckBalance()
    {
        if (CurrentUserManager.User is not null)
        {
            long? balance = await _repository.CheckBalance(CurrentUserManager.User.Id);
            return balance;
        }

        return null;
    }

    public async Task<WithdrawResult> Withdraw(long amount)
    {
        if (CurrentUserManager.User is not null)
        {
            bool result = await _repository.WithdrawMoney(CurrentUserManager.User.Id, amount);
            if (result)
            {
                CurrentUserManager.User.ChangeBalance(CurrentUserManager.User.Balance - amount);
                return new WithdrawResult.Success();
            }
        }

        return new WithdrawResult.NotEnoughMoney();
    }

    public async Task<bool> TopUp(long amount)
    {
        if (CurrentUserManager.User is not null)
        {
            CurrentUserManager.User.ChangeBalance(CurrentUserManager.User.Balance + amount);
            bool result = await _repository.TopUp(CurrentUserManager.User.Id, amount);
            return result;
        }

        return false;
    }

    public void LogOut()
    {
        CurrentUserManager.User = null;
        return;
    }
}