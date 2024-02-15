using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.LogOut;

public class LogoutAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LogoutAdminScenario(IAdminService adminService)
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