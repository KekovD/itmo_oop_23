using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Infrastructure.DataAccess.Exceptions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class CustomerAccountsRepository : ICustomerAccountsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;
    private readonly IUserRepository _userRepository;

    public CustomerAccountsRepository(IPostgresConnectionProvider connectionProvider, IUserRepository userRepository)
    {
        _connectionProvider = connectionProvider;
        _userRepository = userRepository;
    }

    public async Task<string?> FindAccountPasswordByAccountId(long accountId)
    {
        const string sql = """
                           select account_pin_code
                           from customers_accounts
                           where account_id = :accountId;
                           """;

        await using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        const int passwordIndex = 0;
        string password = reader.GetString(passwordIndex);

        return password;
    }

    public async Task<CustomerAccount?> FindAccountByAccountId(long accountId)
    {
        const string sql = """
                           select account_id, account_balance, account_state, account_open_date, account_close_date
                           from customers_accounts
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
        const int balanceIndex = 1;
        const int stateIndex = 2;
        const int openDateIndex = 3;
        const int closeDateIndex = 4;

        DateTime? closeDate = await reader.IsDBNullAsync(closeDateIndex) ? null : reader.GetDateTime(closeDateIndex);

        var customer = new CustomerAccount(
            AccountId: reader.GetInt64(accountIdIndex),
            Balance: reader.GetDecimal(balanceIndex),
            State: await reader.GetFieldValueAsync<CustomerAccountState>(stateIndex),
            OpenDate: reader.GetDateTime(openDateIndex),
            CloseDate: closeDate);

        return customer;
    }

    public async Task CreateCustomer(User newUser, CustomerAccount newAccount, string hashedPassword)
    {
        await _userRepository.CreateUser(newUser);

        User? user = await _userRepository.FindUserByUsername(newUser.Username);
        long? userId = await _userRepository.FindIdByUsername(newUser.Username);

        if (user is null && userId is null)
            throw new UserCreationException($"{nameof(CreateCustomer)} User could not be created.");

        const string sql = """
                           insert into customers_accounts(account_id, user_id, account_balance, account_state, account_open_date, account_pin_code)
                           values(:accountId, :userId, :accountBalance, :accountState, :accountOpenDate, :accountPinCode);
                           """;

        await using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", newAccount.AccountId);
        command.AddParameter("userId", userId);
        command.AddParameter("accountBalance", newAccount.Balance);
        command.AddParameter("accountState", newAccount.State);
        command.AddParameter("accountOpenDate", newAccount.OpenDate);
        command.AddParameter("accountPinCode", hashedPassword);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task ChangeBalance(CustomerAccount account, decimal newBalance)
    {
        const string sql = """
                           update customers_accounts
                           set account_balance = :newBalance
                           where account_id = :accountId;
                           """;

        await using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("newBalance", newBalance);
        command.AddParameter("accountId", account.AccountId);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}