using Application.Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminAccountsRepository : IAdminAccountsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminAccountsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public string? FindAdminPasswordById(long userId, long accountId)
    {
        const string sql = """
                           select account_pin_code
                           from admins_accounts
                           where user_id = :userId
                           and account_id = :accountId;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId).AddParameter("accountId", accountId);
        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        const int passwordIndex = 0;
        string password = reader.GetString(passwordIndex);

        return password;
    }
}