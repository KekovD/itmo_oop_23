using System.Globalization;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Contracts.Exceptions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerBalanceViewScenario : ICustomerLoginSubScenario
{
    private readonly ICustomerBalanceViewService _service;

    public CustomerBalanceViewScenario(ICustomerBalanceViewService service)
    {
        _service = service;
    }

    public string Name => "View balance";

    public void Run()
    {
        TransactionResult result = _service.ViewBalance(out decimal balance);

        string message = result switch
        {
            TransactionResult.Success => $"Your balance {balance.ToString(CultureInfo.InvariantCulture)}",
            TransactionResult.Rejected => "Account closed",
            _ => throw new ServiceArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}