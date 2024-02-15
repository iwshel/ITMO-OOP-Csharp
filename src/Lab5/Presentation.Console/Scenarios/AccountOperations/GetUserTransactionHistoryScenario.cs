using System.Globalization;
using Application.Contracts.Users;
using Models.Transactions;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AccountOperations;

public class GetUserTransactionHistoryScenario : IScenario
{
    private readonly ITransactionService _transactionService;

    public GetUserTransactionHistoryScenario(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public string Name => "See all transactions";

    public async Task Run()
    {
        IEnumerable<Transaction> result = await _transactionService.GetAllUserTransactions();

        foreach (Transaction cur in result)
        {
            AnsiConsole.WriteLine(cur.TransactionType + " " +
                                  cur.Amount.ToString(CultureInfo.InvariantCulture));
        }

        AnsiConsole.WriteLine("That's all.");

        return;
    }
}