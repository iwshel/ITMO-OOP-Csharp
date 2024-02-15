using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.Login;

public class LoginUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login as User";

    public async Task Run()
    {
        long username = AnsiConsole.Prompt(new TextPrompt<long>("Enter your user id: ").Secret());
        long pin = AnsiConsole.Prompt(new TextPrompt<long>("Enter your pin: ").Secret());

        LoginResult result = await _userService.Login(username, pin);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        return;
    }
}