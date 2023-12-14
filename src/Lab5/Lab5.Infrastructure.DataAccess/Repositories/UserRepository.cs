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

    public User? FindUserByUsername(string username)
    {
        const string sql = """
                           select user_name, user_role
                           from users
                           where user_name = @username;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        const int userNameIndex = 0;
        const int userRoleIndex = 1;

        var user = new User(
            Username: reader.GetString(userNameIndex),
            Role: reader.GetFieldValue<UserRole>(userRoleIndex));

        return user;
    }

    public long? FindIdByUsername(string username)
    {
        const string sql = """
                           select user_id
                           from users
                           where user_name = @username;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        const int userIdIndex = 0;

        return reader.GetInt64(userIdIndex);
    }

    public void CreateUser(User newUser)
    {
        User? existingUser = FindUserByUsername(newUser.Username);

        if (existingUser != null)
            return;

        const string sql = """
                           insert into users(user_name, user_role)
                           values(@userName, @userRole);
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userName", newUser.Username);
        command.AddParameter("userRole", newUser.Role);

        command.ExecuteNonQuery();
    }
}