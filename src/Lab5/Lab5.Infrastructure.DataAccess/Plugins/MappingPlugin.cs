using Application.Models.Accounts;
using Application.Models.Operations;
using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder) =>
        builder
            .MapEnum<OperationType>()
            .MapEnum<OperationState>()
            .MapEnum<AccountState>();
}