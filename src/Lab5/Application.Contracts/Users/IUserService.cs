namespace Application.Contracts.Users;

public interface IUserService
{
    Task<LoginResult> Login(long username, long pin);
    Task<long?> CheckBalance();
    Task<WithdrawResult> Withdraw(long amount);
    Task<bool> TopUp(long amount);
    void LogOut();
}