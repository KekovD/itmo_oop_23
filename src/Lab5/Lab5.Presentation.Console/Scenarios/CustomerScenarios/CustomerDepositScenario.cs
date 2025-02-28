﻿using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Contracts.Exceptions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerDepositScenario : ICustomerLoginSubScenario
{
    private readonly ICustomerDepositService _service;

    public CustomerDepositScenario(ICustomerDepositService service)
    {
        _service = service;
    }

    public string Name => "Deposit";

    public void Run()
    {
        decimal replenishmentAmount = AnsiConsole.Ask<decimal>("Enter the amount of money");

        TransactionResult result = _service.Replenishment(replenishmentAmount);

        string message = result switch
        {
            TransactionResult.Success => "Successful operation",
            TransactionResult.Rejected => "Operation rejected",
            _ => throw new ServiceArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}