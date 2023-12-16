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

    public AdminAccount? FindAccountByAccountId(long accountId)
    {
        const string sql = """
                           select account_id
                           from admins_accounts
                           where account_id = @accountId;
                           """;

        NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        const int accountIdIndex = 0;

        return new AdminAccount(reader.GetInt64(accountIdIndex));
    }

    public string? FindAdminPasswordByAccountId(long accountId)
    {
        const string sql = """
                           select account_pin_code
                           from admins_accounts
                           where account_id = @accountId;
                           """;

        NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        const int passwordIndex = 0;
        string password = reader.GetString(passwordIndex);

        return password;
    }

    public void AddAdmin(AdminAccount adminAccount, string hashedPassword)
    {
        const string sql = """
                           insert into admins_accounts(account_id, account_pin_code)
                           values(@accountId, @hashedPassword);
                           """;

        NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", adminAccount.AccountId);
        command.AddParameter("hashedPassword", hashedPassword);
        command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}