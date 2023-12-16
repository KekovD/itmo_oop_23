using System.Globalization;
using System.Text;
using Application.Models.Operations;
using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminViewAllOperationsHistoryScenario : IAdminLoginSubScenario
{
    private readonly IAdminViewAllOperationsHistoryService _service;

    public AdminViewAllOperationsHistoryScenario(IAdminViewAllOperationsHistoryService service)
    {
        _service = service;
    }

    public string Name => "View all operation history";

    public void Run()
    {
        var stringBuilder = new StringBuilder();

        foreach (Operation operation in _service.ViewAllOperationsHistory().ToList())
        {
            stringBuilder.AppendFormat(
                CultureInfo.InvariantCulture,
                "Operation ID: {0}, Account ID: {1}, Amount: {2}, Type: {3}, State: {4}, Date: {5}\n",
                operation.OperationId,
                operation.AccountId,
                operation.Amount,
                operation.Type,
                operation.State,
                operation.Date.ToShortDateString());
        }

        AnsiConsole.WriteLine(stringBuilder.ToString());
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}