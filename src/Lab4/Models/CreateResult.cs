namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record CreateResult
{
    private CreateResult() { }

    public sealed record CreateFail : CreateResult;

    public sealed record CreateSuccess : CreateResult;
}