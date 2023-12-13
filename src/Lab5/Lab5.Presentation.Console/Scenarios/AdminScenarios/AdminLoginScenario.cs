using Lab5.Application.Contracts.Admins;
using Lab5.Application.Contracts.Exceptions;
using Lab5.Presentation.Console.Scenarios.Selectors;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminLoginService _userService;
    private readonly IEnumerable<IScenario> _subScenarios;
    private readonly ISelector _selector;

    public AdminLoginScenario(IAdminLoginService userService, IEnumerable<IScenario> subScenarios, ISelector selector)
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

        AdminLoginResult result = await _userService.Login(accountId, password);

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
            _selector.ConsoleSelector(_subScenarios);
    }
}