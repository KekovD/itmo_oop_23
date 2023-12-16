using Lab5.Application.Contracts.Customers;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerLogoutScenario : ICustomerLoginSubScenario
{
    private readonly ICustomerLogoutService _service;

    public CustomerLogoutScenario(ICustomerLogoutService service)
    {
        _service = service;
    }

    public string Name => "Logout";

    public void Run()
    {
        _service.Logout();
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}