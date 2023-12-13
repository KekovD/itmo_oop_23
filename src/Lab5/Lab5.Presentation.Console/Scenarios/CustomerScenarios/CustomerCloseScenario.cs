using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Contracts.Exceptions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerCloseScenario : IScenario
{
    private readonly ICustomerCloseService _service;

    public CustomerCloseScenario(ICustomerCloseService service)
    {
        _service = service;
    }

    public string Name => "Close account";

    public async Task Run()
    {
        string password = AnsiConsole.Ask<string>("Enter your password");

        CloseResult result = await _service.DeleteAccount(password);

        string message = result switch
        {
            CloseResult.Success => "Account successfully closed",
            CloseResult.AccountClosed => "The account was already closed",
            CloseResult.WrongPassword => "Wrong password",
            _ => throw new ServiceArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}