namespace Application.Contracts.Users;

public interface IAdminService
{
    Task<LoginResult> Login(long pin);
    void LogOut();
}