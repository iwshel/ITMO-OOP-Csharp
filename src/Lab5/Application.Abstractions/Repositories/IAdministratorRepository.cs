namespace Abstractions.Repositories;

public interface IAdministratorRepository
{
    Task<bool> CheckPassword(long password);
}