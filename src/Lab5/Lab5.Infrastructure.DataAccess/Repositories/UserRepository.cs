using Application.Abstractions.Repositories;
using Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByUsername(string username)
    {
        const string sql = """
                           select user_name, user_role
                           from users
                           where user_name = :username;
                           """;

        await using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        const int userNameIndex = 0;
        const int userRoleIndex = 1;

        var user = new User(
            Username: reader.GetString(userNameIndex),
            Role: await reader.GetFieldValueAsync<UserRole>(userRoleIndex));

        return user;
    }

    public async Task<long?> FindIdByUsername(string username)
    {
        const string sql = """
                           select user_id
                           from users
                           where user_name = :username;
                           """;

        await using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        const int userIdIndex = 0;

        return reader.GetInt64(userIdIndex);
    }

    public async Task CreateUser(User newUser)
    {
        User? existingUser = await FindUserByUsername(newUser.Username);

        if (existingUser is not null)
            return;

        const string sql = """
                           insert into users(user_name, user_role)
                           values(:userName, :userRole);
                           """;

        await using NpgsqlConnection connection =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userName", newUser.Username);
        command.AddParameter("userRole", newUser.Role);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}