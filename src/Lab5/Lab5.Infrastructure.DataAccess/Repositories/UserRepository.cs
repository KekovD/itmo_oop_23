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
                           select user_id, user_name, user_role
                           from users
                           where user_name = :username;
                           """;

        await using NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        const int idIndex = 0;
        const int userNameIndex = 1;
        const int userRoleIndex = 2;

        var user = new User(
            Id: reader.GetInt64(idIndex),
            Username: reader.GetString(userNameIndex),
            Role: await reader.GetFieldValueAsync<UserRole>(userRoleIndex));

        return user;
    }
}