using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class CustomerAccountsRepository : ICustomerAccountsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public CustomerAccountsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public string? FindAccountPasswordById(long userId, decimal accountId)
    {
        const string sql = """
                           select account_pin_code
                           from customers_accounts
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

    public CustomerAccount? FindAccountById(long userId, decimal accountId)
    {
        const string sql = """
                           select account_id, user_id, account_balance, account_state, account_open_date, account_close_date
                           from customers_accounts
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

        const int accountIdIndex = 0;
        const int userIdIndex = 1;
        const int balanceIndex = 2;
        const int stateIndex = 3;
        const int openDateIndex = 4;
        const int closeDateIndex = 5;

        DateTime? closeDate = reader.IsDBNull(closeDateIndex) ? null : reader.GetDateTime(closeDateIndex);

        var customer = new CustomerAccount(
            AccountId: reader.GetDecimal(accountIdIndex),
            UserId: reader.GetInt64(userIdIndex),
            Balance: reader.GetDecimal(balanceIndex),
            State: reader.GetFieldValue<CustomerAccountState>(stateIndex),
            OpenDate: reader.GetDateTime(openDateIndex),
            CloseDate: closeDate);

        return customer;
    }
}