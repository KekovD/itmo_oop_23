using Application.Models.Accounts;
using Application.Models.Operations;
using Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder) =>
        builder
            .MapEnum<UserRole>()
            .MapEnum<OperationType>()
            .MapEnum<OperationState>()
            .MapEnum<CustomerAccountState>();
}