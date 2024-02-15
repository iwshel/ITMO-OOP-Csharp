using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.LogOut;

public class LogoutUserScenario : IScenario
{
    private readonly IUserService _adminService;

    public LogoutUserScenario(IUserService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "LogOut";

    public Task Run()
    {
        _adminService.LogOut();

        AnsiConsole.WriteLine("You are logged out.");
        return Task.CompletedTask;
    }
}