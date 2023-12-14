using Lab5.Application.Admins;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Admins;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection
            .AddScoped<IAdminLoginService, AdminLoginService>()
            .AddScoped<IAdminViewAllCustomersService, AdminViewAllCustomersService>()
            .AddScoped<IAdminViewAllOperationsHistoryByCustomerService,
                AdminViewAllOperationsHistoryByCustomerService>()
            .AddScoped<IAdminViewAllOperationsHistoryService, AdminViewAllOperationsHistoryService>()
            .AddScoped<IAdminViewPeriodOperationsHistoryService, AdminViewPeriodOperationsHistoryService>();

        collection
            .AddScoped<CurrentAdminManager>()
            .AddScoped<ICurrentAdminService>(
                provider => provider.GetRequiredService<CurrentAdminManager>());

        collection
            .AddScoped<ICustomerBalanceViewService, CustomerBalanceViewService>()
            .AddScoped<ICustomerCloseService, CustomerCloseService>()
            .AddScoped<ICustomerDepositService, CustomerDepositService>()
            .AddScoped<ICustomerLoginService, CustomerLoginService>()
            .AddScoped<ICustomerRegisterService, CustomerRegisterService>()
            .AddScoped<ICustomerViewAllOperationsHistoryService, CustomerViewAllOperationsHistoryService>()
            .AddScoped<ICustomerViewPeriodOperationsHistoryService, CustomerViewPeriodOperationsHistoryService>()
            .AddScoped<ICustomerWithdrawalService, CustomerWithdrawalService>();

        collection
            .AddScoped<ICurrentCustomerService>()
            .AddScoped<ICurrentCustomerService>(
                provider => provider.GetRequiredService<CurrentCustomerManager>());

        collection.AddScoped<IPasswordHasher, PasswordHasher>();

        return collection;
    }
}