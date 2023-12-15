using Application.Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Infrastructure.DataAccess.Plugins;
using Lab5.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection
            .AddScoped<IAdminAccountsRepository, AdminAccountsRepository>()
            .AddScoped<IAdminViewOfCustomerAccountsRepository, AdminViewOfCustomerAccountsRepository>()
            .AddScoped<IAdminViewOperationsHistoryRepository, AdminViewOperationsHistoryRepository>()
            .AddScoped<ICustomerAccountsRepository, CustomerAccountsRepository>()
            .AddScoped<IOperationsHistoryRepository, OperationsHistoryRepository>();

        return collection;
    }
}