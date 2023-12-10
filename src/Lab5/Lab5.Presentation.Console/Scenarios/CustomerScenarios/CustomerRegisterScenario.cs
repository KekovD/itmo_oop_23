using Application.Models.Accounts;
using Application.Models.Users;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Contracts.Exceptions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerRegisterScenario : IScenario
{
    private readonly ICustomerRegisterService _userService;

    public CustomerRegisterScenario(ICustomerRegisterService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        long accountId = AnsiConsole.Ask<long>("Enter your account id");
        string password = AnsiConsole.Ask<string>("Enter your password");

        var newUser = new User(username, UserRole.Customer);
        const decimal registerBalance = 0;

        var newAccount =
            new CustomerAccount(accountId, registerBalance, CustomerAccountState.Open, DateTime.Now, null);

        RegisterResult result = await _userService.Register(newUser, newAccount, password);

        string message = result switch
        {
            RegisterResult.Success => "Successful register",
            RegisterResult.AccountAlreadyExists => "Account already exists",
            _ => throw new ServiceArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}