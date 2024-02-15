using Application.Contracts.Users;
using Spectre.Console;

namespace Presentation.Console.Scenarios.SignUp;

public class SignUpScenario : IScenario
{
    private readonly ISignUpService _signUpService;

    public SignUpScenario(ISignUpService signUpService)
    {
        _signUpService = signUpService;
    }

    public string Name => "SignUp";

    public async Task Run()
    {
        long username = AnsiConsole.Ask<long>("Enter your username: ");
        long pin = AnsiConsole.Ask<long>("Enter your pin: ");

        SignUpResult result = await _signUpService.SignUp(username, pin);
        string message = result switch
        {
            SignUpResult.Success => "Account created",
            SignUpResult.UserExists => "User already exists",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        return;
    }
}