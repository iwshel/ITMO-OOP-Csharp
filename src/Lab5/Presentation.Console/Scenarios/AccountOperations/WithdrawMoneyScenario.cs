using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AccountOperations;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Withdraw money";

    public async Task Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter sum that you want to withdraw: ");

        WithdrawResult result = await _userService.Withdraw(amount);

        string message = result switch
        {
            WithdrawResult.Success => "Successful withdraw",
            WithdrawResult.NotEnoughMoney => "Not enough money on balance to withdraw",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        return;
    }

    public async Task RunTest(long amount)
    {
        await _userService.Withdraw(amount);
    }
}