using System;
using System.Collections.Generic;
using Application.Models.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;
using Lab5.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Tests;

public static class AccountWithdrawalSuccessful
{
    public static IEnumerable<object[]> GetRequest
    {
        get
        {
            yield return new object[]
            {
                new List<object>
                {
                    new CustomerAccount(1, 20, AccountState.Open, DateTime.Now, null),
                    5m,
                },
            };
        }
    }

    [Theory]
    [MemberData(nameof(GetRequest), MemberType = typeof(AccountWithdrawalSuccessful))]
    private static void ConditionCheck(IList<object> requests)
    {
        var collection = new ServiceCollection();

        collection.AddApplication().MoqAddInfrastructureDataAccess().MoqAddPresentationConsole();

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        MoqScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<MoqScenarioRunner>();

        scenarioRunner.SetCustomer((CustomerAccount)requests[0]);
        scenarioRunner.SetAmount((decimal)requests[1]);
        scenarioRunner.Run("Register");
        scenarioRunner.Run("Withdrawal");

        CustomerAccount? customer = scenarioRunner.GetCustomer();

        Assert.True(customer is not null);
        Assert.True(customer.Balance == 15);
    }
}