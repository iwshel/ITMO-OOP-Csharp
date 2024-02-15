using Microsoft.Extensions.DependencyInjection;
using Presentation.Console.Scenarios.AccountOperations;
using Presentation.Console.Scenarios.Login;
using Presentation.Console.Scenarios.LogOut;
using Presentation.Console.Scenarios.SignUp;

namespace Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, SignUpScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetUserTransactionHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetAllTransactionHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AccountReplenishmentScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutUserScenarioProvider>();

        return collection;
    }
}