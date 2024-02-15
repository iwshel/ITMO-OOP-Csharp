using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AccountOperations;

public class CheckBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public CheckBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Check balance";

    public async Task Run()
    {
        long? result = await _userService.CheckBalance();

        if (result is null)
        {
            AnsiConsole.WriteLine("Problems with account");
            return;
        }

        AnsiConsole.WriteLine($"Your balance is {result}");
        return;
    }
}