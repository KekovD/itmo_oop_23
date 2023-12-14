using System.Globalization;
using System.Text;
using Application.Models.Operations;
using Lab5.Application.Contracts.Customers;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerViewAllOperationsHistoryScenario : ICustomerLoginSubScenario
{
    private readonly ICustomerViewAllOperationsHistoryService _service;

    public CustomerViewAllOperationsHistoryScenario(ICustomerViewAllOperationsHistoryService service)
    {
        _service = service;
    }

    public string Name => "View all operation history";

    public async Task Run()
    {
        var stringBuilder = new StringBuilder();

        await foreach (Operation operation in _service.ViewAllOperationsHistory())
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