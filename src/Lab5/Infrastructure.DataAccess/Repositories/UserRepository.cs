using System.Globalization;
using Abstractions.Repositories;
using Models.Users;
using Npgsql;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User?> FindUserByUsername(long id, long pin)
    {
        const string sql = """
                           
                                   SELECT user_id, user_pin
                                   FROM users
                                   WHERE user_id = :id and user_pin = :pin;
                               
                           """;

        const string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=postgres;";

        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("pin", pin);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new User(
                Convert.ToInt64(reader["user_id"], CultureInfo.InvariantCulture),
                Convert.ToInt64(reader["user_pin"], CultureInfo.InvariantCulture),
                0);
        }

        return null;
    }

    public async Task<bool> CreateNewUser(long id, long pin)
    {
        const string sql1 = """
                             select count(*)
                             from users
                             where user_id = @id and user_pin = @pin;
                            """;

        const string sql = """
                            INSERT INTO users (user_id, user_pin, balance)
                            VALUES (:id,  :pin, 0);
                           """;
        const string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=postgres;";
        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("pin", pin);

        using var command2 = new NpgsqlCommand(sql1, connection);
        command2.Parameters.AddWithValue("id", id);
        command2.Parameters.AddWithValue("pin", pin);

        int count = Convert.ToInt32(await command2.ExecuteScalarAsync(), CultureInfo.InvariantCulture);
        if (count > 0)
        {
            return false;
        }

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return true;
    }

    public async Task<long?> CheckBalance(long id)
    {
        const string sql = """
                                   SELECT balance
                                   FROM users
                                   WHERE user_id = :id;
                               
                           """;

        const string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=postgres;";
        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return Convert.ToInt64(reader["balance"], CultureInfo.InvariantCulture);
        }

        return null;
    }

    public async Task<bool> WithdrawMoney(long id, long amount)
    {
        const string sql1 = """
                             select count(*)
                             from users
                             where user_id = :id;
                            """;

        const string sql = """
                            UPDATE users
                            SET balance = balance - :amount
                            WHERE user_id = :id;
                           """;

        const string sql3 = """
                             select balance
                             from users
                             where user_id = :id;
                            """;

        const string sql4 = """
                             INSERT INTO transactions (type, amount, user_id)
                             VALUES ('Withdraw', :amount, :id);
                            """;
        const string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=postgres;";
        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("amount", amount);

        using var command2 = new NpgsqlCommand(sql1, connection);
        command2.Parameters.AddWithValue("id", id);

        using var command3 = new NpgsqlCommand(sql3, connection);
        command3.Parameters.AddWithValue("id", id);

        using var command4 = new NpgsqlCommand(sql4, connection);
        command4.Parameters.AddWithValue("id", id);
        command4.Parameters.AddWithValue("amount", amount);

        int count = Convert.ToInt32(await command2.ExecuteScalarAsync(), CultureInfo.InvariantCulture);

        int amountBalance = Convert.ToInt32(await command3.ExecuteScalarAsync(), CultureInfo.InvariantCulture);

        if (count == 0 || amountBalance - amount < 0)
        {
            return false;
        }

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        await reader.CloseAsync();
        using NpgsqlDataReader reader2 = await command4.ExecuteReaderAsync();

        return true;
    }

    public async Task<bool> TopUp(long id, long amount)
    {
        const string sql1 = """
                             select count(*)
                             from users
                             where user_id = :id;
                            """;

        const string sql = """
                            UPDATE users
                            SET balance = balance + :amount
                            WHERE user_id = :id;
                           """;
        const string sql4 = """
                             INSERT INTO transactions (type, amount, user_id)
                             VALUES ('Deposit', :amount, :id);
                            """;
        const string connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=postgres;";
        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("amount", amount);

        using var command2 = new NpgsqlCommand(sql1, connection);
        command2.Parameters.AddWithValue("id", id);

        using var command4 = new NpgsqlCommand(sql4, connection);
        command4.Parameters.AddWithValue("id", id);
        command4.Parameters.AddWithValue("amount", amount);

        int count = Convert.ToInt32(await command2.ExecuteScalarAsync(), CultureInfo.InvariantCulture);

        if (count == 0)
        {
            return false;
        }

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        await reader.CloseAsync();
        using NpgsqlDataReader reader2 = await command4.ExecuteReaderAsync();

        return true;
    }
}