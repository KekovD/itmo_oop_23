using System.Globalization;
using System.Text;
using Application.Models.Accounts;
using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminViewAllCustomersScenario : IAdminLoginSubScenario
{
    private readonly IAdminViewAllCustomersService _service;

    public AdminViewAllCustomersScenario(IAdminViewAllCustomersService service)
    {
        _service = service;
    }

    public string Name => "View all customers";

    public void Run()
    {
        var stringBuilder = new StringBuilder();

        foreach (CustomerAccount account in _service.ViewAllCustomers().ToList())
        {
            stringBuilder.AppendFormat(
                CultureInfo.InvariantCulture,
                "Account ID: {0}, Balance: {1}, State: {2}, Open Date: {3}, Close Date: {4}\n",
                account.AccountId,
                account.Balance,
                account.State,
                account.OpenDate,
                account.CloseDate.HasValue ? account.CloseDate.Value.ToString(CultureInfo.InvariantCulture) : "N/A");
        }

        AnsiConsole.WriteLine(stringBuilder.ToString());
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}