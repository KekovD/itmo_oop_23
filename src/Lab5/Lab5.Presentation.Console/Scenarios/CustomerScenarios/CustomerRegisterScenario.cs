using Application.Models.Accounts;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Contracts.Exceptions;
using Lab5.Presentation.Console.Scenarios.Selectors;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerRegisterScenario : ICustomerProviderSubScenario
{
    private readonly ICustomerRegisterService _userService;
    private readonly IEnumerable<ICustomerLoginSubScenario> _subScenarios;
    private readonly ISelector _selector;
    private readonly ICurrentCustomerService _service;

    public CustomerRegisterScenario(
        ICustomerRegisterService userService,
        IEnumerable<ICustomerLoginSubScenario> subScenarios,
        ISelector selector,
        ICurrentCustomerService service)
    {
        _userService = userService;
        _subScenarios = subScenarios;
        _selector = selector;
        _service = service;
    }

    public string Name => "Register";

    public void Run()
    {
        long accountId = AnsiConsole.Ask<long>("Enter your account id");
        string password = AnsiConsole.Ask<string>("Enter your password");

        const decimal registerBalance = 0;

        var newAccount =
            new CustomerAccount(accountId, registerBalance, CustomerAccountState.Open, DateTime.Now, null);

        RegisterResult result = _userService.Register(newAccount, password);

        string message = result switch
        {
            RegisterResult.Success => "Successful register",
            RegisterResult.AccountAlreadyExists => "Account already exists",
            _ => throw new ServiceArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");

        if (result is RegisterResult.Success)
        {
            while (_service.Customer is not null)
            {
                _selector.ConsoleSelector(_subScenarios).Run();
            }
        }
    }
}