using Lab5.Application.Contracts.Customers;
using Lab5.Application.Contracts.Exceptions;
using Lab5.Presentation.Console.Scenarios.Selectors;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerLoginScenario : ICustomerProviderSubScenario
{
    private readonly ICustomerLoginService _userService;
    private readonly IEnumerable<ICustomerLoginSubScenario> _subScenarios;
    private readonly ISelector _selector;

    public CustomerLoginScenario(ICustomerLoginService userService,  IEnumerable<ICustomerLoginSubScenario> subScenarios, ISelector selector)
    {
        _userService = userService;
        _subScenarios = subScenarios;
        _selector = selector;
    }

    public string Name => "Login";

    public void Run()
    {
        long accountId = AnsiConsole.Ask<long>("Enter your account id");
        string password = AnsiConsole.Ask<string>("Enter your password");

        CustomerLoginResult result = _userService.Login(accountId, password);

        string message = result switch
        {
            CustomerLoginResult.Success => "Successful login",
            CustomerLoginResult.NotFound => "User not found",
            CustomerLoginResult.WrongPassword => "Wrong password",
            CustomerLoginResult.AccountClosed => "Account closed",
            _ => throw new ServiceArgumentOutOfRangeException($"{nameof(CustomerLoginScenario)} {nameof(result)}"),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");

        if (result is CustomerLoginResult.Success)
            _selector.ConsoleSelector(_subScenarios).Run();
    }
}