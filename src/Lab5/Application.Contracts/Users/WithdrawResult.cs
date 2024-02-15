namespace Application.Contracts.Users;

public abstract record WithdrawResult
{
    private WithdrawResult() { }

    public sealed record Success : WithdrawResult;

    public sealed record NotEnoughMoney : WithdrawResult;
}