using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Infrastructure.DataAccess.Exceptions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminAccountsRepository : IAdminAccountsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;
    private readonly IUserRepository _userRepository;

    public AdminAccountsRepository(IPostgresConnectionProvider connectionProvider, IUserRepository userRepository)
    {
        _connectionProvider = connectionProvider;
        _userRepository = userRepository;
    }

    public AdminAccount? FindAccountByAccountId(long accountId)
    {
        const string sql = """
                           select account_id
                           from admins_accounts
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

        return new AdminAccount(reader.GetInt64(accountIdIndex));
    }

    public string? FindAdminPasswordByAccountId(long accountId)
    {
        const string sql = """
                           select account_pin_code
                           from admins_accounts
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

    public void AddAdmin(User newUser, AdminAccount adminAccount, string hashedPassword)
    {
        _userRepository.CreateUser(newUser with { Role = UserRole.Admin });

        User? user = _userRepository.FindUserByUsername(newUser.Username);
        long? userId = _userRepository.FindIdByUsername(newUser.Username);

        if (user is null && userId is null)
            throw new UserCreationException($"{nameof(AddAdmin)} User could not be created.");

        const string sql = """
                           insert into admins_accounts(account_id, user_id, account_pin_code)
                           values(@accountId, @userId, @hashedPassword);
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", adminAccount.AccountId);
        command.AddParameter("hashedPassword", hashedPassword);
        command.AddParameter("userId", userId);

        command.ExecuteNonQuery();
    }
}