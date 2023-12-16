using System;
using System.Collections.Generic;
using System.Linq;
using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Lab5.Presentation.Console.Scenarios.CustomerScenarios;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class MoqScenarioRunner
{
    private readonly IEnumerable<ICustomerLoginSubScenario> _scenarios;
    private readonly OperationAmount _operationAmount;
    private readonly MoqCurrentCustomerService _currentCustomerService;
    private readonly ICustomerAccountsRepository _repository;

    public MoqScenarioRunner(
        IList<ICustomerLoginSubScenario> scenarios, OperationAmount operationAmount, MoqCurrentCustomerService currentCustomerService, ICustomerAccountsRepository repository)
    {
        _scenarios = scenarios;
        _operationAmount = operationAmount;
        _currentCustomerService = currentCustomerService;
        _repository = repository;
    }

    public CustomerAccount? GetCustomer()
    {
        if (_currentCustomerService.Customer is not null)
            return _repository.FindAccountByAccountId(_currentCustomerService.Customer.AccountId);

        return null;
    }

    public void SetAmount(decimal amount) => _operationAmount.Amount = amount;

    public void SetCustomer(CustomerAccount customerAccount) => _currentCustomerService.Customer = customerAccount;

    public void Run(string scenarioName) =>
        _scenarios.FirstOrDefault(scenario => scenario.Name.Equals(scenarioName, StringComparison.Ordinal))?.Run();
}