using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminLogoutScenario : IAdminLoginSubScenario
{
    private readonly IAdminLogoutService _service;

    public AdminLogoutScenario(IAdminLogoutService service)
    {
        _service = service;
    }

    public string Name => "Logout";

    public void Run()
    {
        _service.Logout();
        AnsiConsole.Ask<string>("Ok");
    }
}