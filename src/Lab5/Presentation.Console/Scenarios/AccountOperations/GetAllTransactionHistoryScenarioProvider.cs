using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;

namespace Presentation.Console.Scenarios.AccountOperations;

public class GetAllTransactionHistoryScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _service;
    private readonly ICurrentUserService _currentUser;

    public GetAllTransactionHistoryScenarioProvider(
        ITransactionService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.Administrator is null)
        {
            scenario = null;
            return false;
        }

        scenario = new GetAllTransactionHistoryScenario(_service);
        return true;
    }
}