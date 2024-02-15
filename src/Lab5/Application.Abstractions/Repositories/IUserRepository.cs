using Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUsername(long id, long pin);
    Task<bool> CreateNewUser(long id, long pin);
    Task<long?> CheckBalance(long id);
    Task<bool> WithdrawMoney(long id, long amount);
    Task<bool> TopUp(long id, long amount);
}