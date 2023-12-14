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

    public string? FindAccountPasswordByAccountId(long accountId)
    {
        const string sql = """
                           select account_pin_code
                           from customers_accounts
                           where account_id = @accountId;
                           """;

        using NpgsqlConnection connection = Task
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

    public CustomerAccount? FindAccountByAccountId(long accountId)
    {
        const string sql = """
                           select account_id, account_balance, account_state, account_open_date, account_close_date
                           from customers_accounts
                           where account_id = @accountId;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        const int accountIdIndex = 0;
        const int balanceIndex = 1;
        const int stateIndex = 2;
        const int openDateIndex = 3;
        const int closeDateIndex = 4;

        DateTime? closeDate = reader.IsDBNull(closeDateIndex) ? null : reader.GetDateTime(closeDateIndex);

        var customer = new CustomerAccount(
            AccountId: reader.GetInt64(accountIdIndex),
            Balance: reader.GetDecimal(balanceIndex),
            State: reader.GetFieldValue<CustomerAccountState>(stateIndex),
            OpenDate: reader.GetDateTime(openDateIndex),
            CloseDate: closeDate);

        return customer;
    }

    public void CreateCustomer(User newUser, CustomerAccount newAccount, string hashedPassword)
    {
        _userRepository.CreateUser(newUser);

        User? user = _userRepository.FindUserByUsername(newUser.Username);
        long? userId = _userRepository.FindIdByUsername(newUser.Username);

        if (user is null && userId is null)
            throw new UserCreationException($"{nameof(CreateCustomer)} User could not be created.");

        const string sql = """
                           insert into customers_accounts(account_id, user_id, account_balance, account_state, account_open_date, account_pin_code)
                           values(@accountId, @userId, @accountBalance, @accountState, @accountOpenDate, @accountPinCode);
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", newAccount.AccountId);
        command.AddParameter("userId", userId);
        command.AddParameter("accountBalance", newAccount.Balance);
        command.AddParameter("accountState", newAccount.State);
        command.AddParameter("accountOpenDate", newAccount.OpenDate);
        command.AddParameter("accountPinCode", hashedPassword);

        command.ExecuteNonQuery();
    }

    public void ChangeBalance(CustomerAccount account, decimal newBalance)
    {
        const string sql = """
                           update customers_accounts
                           set account_balance = @newBalance
                           where account_id = @accountId;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("newBalance", newBalance);
        command.AddParameter("accountId", account.AccountId);

        command.ExecuteNonQuery();
    }

    public void ChangeAccountStateToClose(CustomerAccount account, DateTime closeDate)
    {
        const string sql = """
                           update customers_accounts
                           set account_state = 'close', account_close_date = @closeDate
                           where account_id = @accountId;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("closeDate", closeDate);
        command.AddParameter("accountId", account.AccountId);

        command.ExecuteNonQuery();
    }
}