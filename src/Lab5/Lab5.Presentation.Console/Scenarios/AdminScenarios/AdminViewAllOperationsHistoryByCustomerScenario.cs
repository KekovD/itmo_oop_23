using System.Globalization;
using System.Text;
using Application.Models.Operations;
using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminViewAllOperationsHistoryByCustomerScenario : IScenario
{
    private readonly IAdminViewAllOperationsHistoryByCustomerService _service;

    public AdminViewAllOperationsHistoryByCustomerScenario(IAdminViewAllOperationsHistoryByCustomerService service)
    {
        _service = service;
    }

    public string Name => "View all operation history by customer";

    public async Task Run()
    {
        long accountId = AnsiConsole.Ask<long>("Enter customer account id");

        var stringBuilder = new StringBuilder();

        await foreach (Operation operation in _service.ViewAllOperationsHistoryByCustomer(accountId))
        {
            stringBuilder.AppendFormat(
                CultureInfo.InvariantCulture,
                "Operation ID: {0}, Account ID: {1}, Amount: {2}, Type: {3}, State: {4}, Date: {5}\n",
                operation.OperationId,
                operation.AccountId,
                operation.Amount,
                operation.Type,
                operation.State,
                operation.Date);

            AnsiConsole.WriteLine(stringBuilder.ToString());
            stringBuilder.Clear();
        }

        AnsiConsole.Ask<string>("Ok");
    }
}