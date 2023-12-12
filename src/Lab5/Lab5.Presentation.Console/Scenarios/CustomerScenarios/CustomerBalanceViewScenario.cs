using System.Globalization;
using Lab5.Application.Contracts.Customers;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerBalanceViewScenario : IScenario
{
    private readonly ICustomerBalanceViewService _service;

    public CustomerBalanceViewScenario(ICustomerBalanceViewService service)
    {
        _service = service;
    }

    public string Name => "View balance";

    public async Task Run()
    {
        decimal balance = await _service.ViewBalance();
        string message = balance.ToString(CultureInfo.InvariantCulture);

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}