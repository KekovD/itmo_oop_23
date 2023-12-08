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

        const int accountIdIndex = 0;
        const int userIdIndex = 1;
        const int balanceIndex = 2;
        const int stateIndex = 3;
        const int openDateIndex = 4;
        const int closeDateIndex = 5;

        while (reader.Read())
        {
            DateTime? closeDate = reader.IsDBNull(closeDateIndex) ? null : reader.GetDateTime(closeDateIndex);

            yield return new CustomerAccount(
                AccountId: reader.GetInt64(accountIdIndex),
                UserId: reader.GetInt64(userIdIndex),
                Balance: reader.GetDecimal(balanceIndex),
                State: reader.GetFieldValue<CustomerAccountState>(stateIndex),
                OpenDate: reader.GetDateTime(openDateIndex),
                CloseDate: closeDate);
        }
    }
}