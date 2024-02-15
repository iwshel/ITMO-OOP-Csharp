using System.Globalization;
using Abstractions.Repositories;
using Models.Transactions;
using Npgsql;

namespace DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    public async Task<IEnumerable<Transaction>> GetAllTransactions()
    {
        const string sql = """
                               SELECT user_id, type, amount
                               FROM transactions
                           """;

        var transactions = new List<Transaction>();

        const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=postgres;";
        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            transactions.Add(new Transaction(
                UserId: Convert.ToInt64(reader["user_id"], CultureInfo.InvariantCulture),
                TransactionType: Enum.TryParse(reader["type"]?.ToString(), out TransactionType transactionType) ? transactionType : default,
                Amount: Convert.ToInt64(reader["amount"], CultureInfo.InvariantCulture)));
        }

        await reader.CloseAsync();
        return transactions;
    }

    public async Task<IEnumerable<Transaction>> GetAllUserTransactions(long userId)
    {
        const string sql = """
                               SELECT user_id, type, amount
                               FROM transactions
                               where user_id = :userId;
                           """;

        var transactions = new List<Transaction>();

        const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=postgres;";
        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userId", userId);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            transactions.Add(new Transaction(
                UserId: userId,
                TransactionType: Enum.TryParse(reader["type"]?.ToString(), out TransactionType transactionType) ? transactionType : default,
                Amount: Convert.ToInt64(reader["amount"], CultureInfo.InvariantCulture)));
        }

        return transactions;
    }
}