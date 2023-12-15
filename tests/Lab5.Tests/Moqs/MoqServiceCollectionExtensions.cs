using Application.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public static class MoqServiceCollectionExtensions
{
    public static IServiceCollection MoqAddInfrastructureDataAccess(
        this IServiceCollection collection)
    {
        collection
            .AddScoped<ICustomerAccountsRepository, MoqCustomerAccountsRepository>()
            .AddScoped<IOperationsHistoryRepository, MoqOperationsHistoryRepository>();

        return collection;
    }
}