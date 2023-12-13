using Application.Abstractions.Repositories;
using Application.Models.Accounts;
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

    public async Task<AdminAccount?> FindAccountByAccountId(long accountId)
    {
        const string sql = """
                           select account_id
                           from admins_accounts
                           where account_id = :accountId;
                           """;

        await using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        const int accountIdIndex = 0;

        return new AdminAccount(reader.GetInt64(accountIdIndex));
    }

    public async Task<string?> FindAdminPasswordByAccountId(long accountId)
    {
        const string sql = """
                           select account_pin_code
                           from admins_accounts
                           where account_id = :accountId;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
            return null;

        const int passwordIndex = 0;
        string password = reader.GetString(passwordIndex);

        return password;
    }
}