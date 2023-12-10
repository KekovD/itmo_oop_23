using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Contracts.Exceptions;
using Lab5.Presentation.Console.Scenarios.Selectors;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerLoginScenario : IScenario
{
    private readonly ICustomerLoginService _userService;
    private readonly IEnumerable<IScenario> _subScenarios;
    private readonly ISelector _selector;

    public CustomerLoginScenario(ICustomerLoginService userService,  IEnumerable<IScenario> subScenarios, ISelector selector)
    {
        _userService = userService;
        _subScenarios = subScenarios;
        _selector = selector;
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
            LoginResult.WrongPassword => "Wrong password",
            _ => throw new ServiceArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");

        if (result is LoginResult.Success)
            _selector.ConsoleSelector(_subScenarios);
    }
}