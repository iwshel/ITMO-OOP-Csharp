using Abstractions.Repositories;
using Npgsql;

namespace DataAccess.Repositories;

public class AdministratorRepository : IAdministratorRepository
{
    public async Task<bool> CheckPassword(long password)
    {
        const string sql = """
                           select password
                           from administrators
                           where password = :password;
                           """;
        const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=mysecretpassword;Database=postgres;";
        using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("password", password);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        return await reader.ReadAsync();
    }
}