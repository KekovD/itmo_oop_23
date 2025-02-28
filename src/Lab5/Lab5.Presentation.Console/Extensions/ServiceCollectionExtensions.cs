﻿using Lab5.Presentation.Console.Scenarios;
using Lab5.Presentation.Console.Scenarios.AdminScenarios;
using Lab5.Presentation.Console.Scenarios.CustomerScenarios;
using Lab5.Presentation.Console.Scenarios.Selectors;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<ISelector, Selector>();

        collection
            .AddScoped<IScenarioProvider, AdminScenarioProvider>()
            .AddScoped<IScenarioProvider, CustomerScenarioProvider>()
            .AddScoped<IScenarioProvider, ExitScenarioProvider>();

        collection
            .AddScoped<ICustomerProviderSubScenario, CustomerLoginScenario>()
            .AddScoped<ICustomerProviderSubScenario, CustomerRegisterScenario>();

        collection
            .AddScoped<ICustomerLoginSubScenario, CustomerWithdrawalScenario>()
            .AddScoped<ICustomerLoginSubScenario, CustomerDepositScenario>()
            .AddScoped<ICustomerLoginSubScenario, CustomerBalanceViewScenario>()
            .AddScoped<ICustomerLoginSubScenario, CustomerViewAllOperationsHistoryScenario>()
            .AddScoped<ICustomerLoginSubScenario, CustomerViewPeriodOperationsHistoryScenario>()
            .AddScoped<ICustomerLoginSubScenario, CustomerCloseScenario>()
            .AddScoped<ICustomerLoginSubScenario, CustomerLogoutScenario>();

        collection.AddScoped<IAdminProviderSubScenario, AdminLoginScenario>();
        collection.AddScoped<IExitScenario, ExitScenario>();

        collection
            .AddScoped<IAdminLoginSubScenario, AdminViewAllCustomersScenario>()
            .AddScoped<IAdminLoginSubScenario, AdminViewAllOperationsHistoryScenario>()
            .AddScoped<IAdminLoginSubScenario, AdminViewAllOperationsHistoryByCustomerScenario>()
            .AddScoped<IAdminLoginSubScenario, AdminViewPeriodOperationsHistoryScenario>()
            .AddScoped<IAdminLoginSubScenario, AdminLogoutScenario>();

        return collection;
    }
}