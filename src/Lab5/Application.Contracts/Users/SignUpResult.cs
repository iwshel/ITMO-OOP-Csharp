namespace Application.Contracts.Users;

public abstract record SignUpResult
{
    private SignUpResult() { }

    public sealed record Success : SignUpResult;

    public sealed record UserExists : SignUpResult;
}