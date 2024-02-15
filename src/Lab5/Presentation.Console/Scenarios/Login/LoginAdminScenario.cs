using Application.Contracts.Users;
using Presentation.Console.Exceptions;
using Spectre.Console;

namespace Presentation.Console.Scenarios.Login;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login as Admin";

    public async Task Run()
    {
        long password = AnsiConsole.Prompt(new TextPrompt<long>("Enter system password: ").Secret());

        LoginResult result2 = await _adminService.Login(password);

        string message2 = result2 switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.WrongPassword => "Wrong Password",
            _ => throw new ArgumentOutOfRangeException(nameof(result2)),
        };

        AnsiConsole.WriteLine(message2);
        if (result2 is LoginResult.WrongPassword)
        {
            throw new WrongAdminPasswordException();
        }

        return;
    }
}