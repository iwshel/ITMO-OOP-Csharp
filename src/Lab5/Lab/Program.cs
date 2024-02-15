using Application.Application.Extensions;
using DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Console;
using Presentation.Console.Extensions;

namespace Lab;

public static class Program
{
    public static async Task Main()
    {
        var collection = new ServiceCollection();

        collection
            .AddApplication()
            .AddInfrastructureDataAccess()
            .AddPresentationConsole();
        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        ScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<ScenarioRunner>();

        while (true)
        {
            await scenarioRunner.Run();
        }
    }
}