using System.Collections.Generic;
using System.Linq;
using Lab5.Presentation.Console.Scenarios.CustomerScenarios;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public static class MoqScenariosServiceCollectionExtensions
{
    public static IServiceCollection MoqAddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<MoqScenarioRunner>();

        collection
            .AddScoped<MoqCurrentCustomerService>()
            .AddScoped<IMoqCurrentCustomerService>(
                provider => provider.GetRequiredService<MoqCurrentCustomerService>());

        collection
            .AddScoped<OperationAmount>()
            .AddScoped<IOperationAmount>(
                provider => provider.GetRequiredService<OperationAmount>());

        collection
            .AddScoped<ICustomerLoginSubScenario, MoqCustomerWithdrawalScenario>()
            .AddScoped<ICustomerLoginSubScenario, MoqCustomerDepositScenario>()
            .AddScoped<ICustomerLoginSubScenario, MoqCustomerRegisterScenario>()
            .AddScoped<ICustomerLoginSubScenario, GetCustomer>();

        collection.AddScoped<IList<ICustomerLoginSubScenario>>(provider =>
            provider.GetServices<ICustomerLoginSubScenario>().ToList());

        return collection;
    }
}