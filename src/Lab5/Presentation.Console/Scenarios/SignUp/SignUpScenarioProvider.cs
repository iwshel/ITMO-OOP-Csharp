using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;

namespace Presentation.Console.Scenarios.SignUp;

public class SignUpScenarioProvider : IScenarioProvider
{
    private readonly ISignUpService _service;
    private readonly ICurrentUserService _currentUser;

    public SignUpScenarioProvider(
        ISignUpService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null || _currentUser.Administrator is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new SignUpScenario(_service);
        return true;
    }
}