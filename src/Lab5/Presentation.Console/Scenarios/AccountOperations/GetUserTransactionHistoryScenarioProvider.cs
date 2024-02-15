using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;

namespace Presentation.Console.Scenarios.AccountOperations;

public class GetUserTransactionHistoryScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _service;
    private readonly ICurrentUserService _currentUser;

    public GetUserTransactionHistoryScenarioProvider(
        ITransactionService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new GetUserTransactionHistoryScenario(_service);
        return true;
    }
}