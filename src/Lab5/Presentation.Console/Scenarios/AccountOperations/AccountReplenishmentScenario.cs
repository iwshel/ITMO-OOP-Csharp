using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AccountOperations;

public class AccountReplenishmentScenario : IScenario
{
    private readonly IUserService _userService;

    public AccountReplenishmentScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "AccountReplenishment";

    public async Task Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter the amount you want to top up your account balance with: ");

        bool result = await _userService.TopUp(amount);

        string message = result switch
        {
            true => "Successful top-up",
            false => "Account not found",
        };

        AnsiConsole.WriteLine(message);
    }

    public async Task RunTest(long amount)
    {
        await _userService.TopUp(amount);
    }
}