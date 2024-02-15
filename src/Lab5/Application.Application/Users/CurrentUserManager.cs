using Application.Contracts.Users;
using Models.Users;

namespace Application.Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
    public Administrator? Administrator { get; set; }
}