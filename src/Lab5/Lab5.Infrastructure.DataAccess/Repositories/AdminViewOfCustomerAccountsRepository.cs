using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminViewOfCustomerAccountsRepository : IAdminViewOfCustomerAccountsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminViewOfCustomerAccountsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async IAsyncEnumerable<CustomerAccount> GetAllCustomerAccount()
    {
        const string sql = """
                           select account_id, user_id, account_balance, account_state, account_open_date, account_close_date
                           from customers_accounts;
                           """;

        await using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        const int accountIdIndex = 0;
        const int userIdIndex = 1;
        const int balanceIndex = 2;
        const int stateIndex = 3;
        const int openDateIndex = 4;
        const int closeDateIndex = 5;

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            DateTime? closeDate =
                await reader.IsDBNullAsync(closeDateIndex) ? null : reader.GetDateTime(closeDateIndex);

            yield return new CustomerAccount(
                AccountId: reader.GetInt64(accountIdIndex),
                UserId: reader.GetInt64(userIdIndex),
                Balance: reader.GetDecimal(balanceIndex),
                State: await reader.GetFieldValueAsync<CustomerAccountState>(stateIndex),
                OpenDate: reader.GetDateTime(openDateIndex),
                CloseDate: closeDate);
        }
    }
}