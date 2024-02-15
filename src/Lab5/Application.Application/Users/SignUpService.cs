using Abstractions.Repositories;
using Application.Contracts.Users;

namespace Application.Application.Users;

public class SignUpService : ISignUpService
{
    private readonly IUserRepository _repository;

    public SignUpService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<SignUpResult> SignUp(long username, long pin)
    {
        bool result = await _repository.CreateNewUser(username, pin);

        if (!result)
        {
            return new SignUpResult.UserExists();
        }

        return new SignUpResult.Success();
    }
}