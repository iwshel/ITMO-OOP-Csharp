namespace Application.Contracts.Users;

public interface ISignUpService
{
    Task<SignUpResult> SignUp(long username, long pin);
}