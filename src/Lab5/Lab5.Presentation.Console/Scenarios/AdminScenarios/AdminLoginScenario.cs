using Lab5.Application.Contracts.Admins;
using Lab5.Application.Contracts.Exceptions;
using Lab5.Presentation.Console.Scenarios.Selectors;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminLoginScenario : IAdminProviderSubScenario
{
    private readonly IAdminLoginService _userService;
    private readonly IEnumerable<IAdminLoginSubScenario> _subScenarios;
    private readonly ISelector _selector;
    private readonly ICurrentAdminService _service;

    public AdminLoginScenario(
        IAdminLoginService userService, IEnumerable<IAdminLoginSubScenario> subScenarios, ISelector selector, ICurrentAdminService service)
    {
        _userService = userService;
        _subScenarios = subScenarios;
        _selector = selector;
        _service = service;
    }

    public string Name => "Login";

    public void Run()
    {
        long accountId = AnsiConsole.Ask<long>("Enter your account id");
        string password = AnsiConsole.Ask<string>("Enter your password");

        AdminLoginResult result = _userService.Login(accountId, password);

        string message = result switch
        {
            AdminLoginResult.Success => "Successful login",
            AdminLoginResult.NotFound => "User not found",
            AdminLoginResult.WrongPassword => "Wrong password",
            _ => throw new ServiceArgumentOutOfRangeException($"{nameof(AdminLoginScenario)} {nameof(result)}"),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");

        if (result is AdminLoginResult.Success)
        {
            while (_service.Admin is not null)
            {
                _selector.ConsoleSelector(_subScenarios).Run();
            }
        }
    }
}