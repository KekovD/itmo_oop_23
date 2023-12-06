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

    public string? FindAdminPasswordById(long userId)
    {
        const string sql = """
                           select account_pin_code
                           from admins_accounts
                           where user_id = :userId;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId);
        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        const int passwordIndex = 0;
        string password = reader.GetString(passwordIndex);

        return password;
    }

    public IEnumerable<CustomerAccount> GetAllCustomerAccount()
    {
        const string sql = """
                           select account_id, user_id, account_balance, account_state, account_open_date, account_close_date
                           from customers_accounts;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        const int userIdIndex = 0;
        const int accountIdIndex = 1;
        const int balanceIndex = 2;
        const int stateIndex = 3;
        const int openDateIndex = 4;
        const int closeDateIndex = 5;

        while (reader.Read())
        {
            DateTime? closeDate = reader.IsDBNull(closeDateIndex) ? null : reader.GetDateTime(closeDateIndex);

            yield return new CustomerAccount(
                UserId: reader.GetInt64(userIdIndex),
                AccountId: reader.GetInt32(accountIdIndex),
                Balance: reader.GetDecimal(balanceIndex),
                State: reader.GetFieldValue<CustomerAccountState>(stateIndex),
                OpenDate: reader.GetDateTime(openDateIndex),
                CloseDate: closeDate);
        }
    }
}