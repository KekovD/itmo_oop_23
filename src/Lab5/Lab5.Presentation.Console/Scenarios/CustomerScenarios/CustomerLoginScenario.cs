using Spectre.Console;
using Workshop5.Application.Contracts;
using Workshop5.Application.Contracts.Customers;
using Workshop5.Application.Contracts.Exceptions;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerLoginScenario : IScenario
{
    private readonly ICustomerLoginService _userService;

    public CustomerLoginScenario(ICustomerLoginService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public async Task Run()
    {
        long accountId = AnsiConsole.Ask<long>("Enter your account id");
        string password = AnsiConsole.Ask<string>("Enter your password");

        LoginResult result = await _userService.Login(accountId, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ServiceArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}