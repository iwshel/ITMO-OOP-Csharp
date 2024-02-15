using System.Globalization;
using Application.Contracts.Users;
using Models.Transactions;
using Spectre.Console;

namespace Presentation.Console.Scenarios.AccountOperations;

public class GetAllTransactionHistoryScenario : IScenario
{
    private readonly ITransactionService _transactionService;

    public GetAllTransactionHistoryScenario(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public string Name => "See all transactions";

    public async Task Run()
    {
        IEnumerable<Transaction> result = await _transactionService.GetAllTransactions();

        foreach (Transaction cur in result)
        {
            AnsiConsole.WriteLine(cur.UserId.ToString(CultureInfo.InvariantCulture) + " " + cur.TransactionType + " " +
                                  cur.Amount.ToString(CultureInfo.InvariantCulture));
        }

        AnsiConsole.WriteLine("That's all.");

        return;
    }
}