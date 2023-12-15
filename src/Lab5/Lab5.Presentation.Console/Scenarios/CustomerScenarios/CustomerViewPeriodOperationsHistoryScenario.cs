using System.Globalization;
using System.Text;
using Application.Models.Operations;
using Lab5.Application.Contracts.Customers;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerViewPeriodOperationsHistoryScenario : ICustomerLoginSubScenario
{
    private readonly ICustomerViewPeriodOperationsHistoryService _service;

    public CustomerViewPeriodOperationsHistoryScenario(ICustomerViewPeriodOperationsHistoryService service)
    {
        _service = service;
    }

    public string Name => "View operation history for the period";

    public void Run()
    {
        string start = AnsiConsole.Ask<string>("Enter the start date in the format dd.mm.yyyy");
        string end = AnsiConsole.Ask<string>("Enter the end date in the format dd.mm.yyyy");

        if (!DateTime.TryParseExact(start, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate)
            || !DateTime.TryParseExact(end, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
        {
            AnsiConsole.WriteLine("Incorrect date format");
            AnsiConsole.Ask<string>("Ok");
            return;
        }

        var stringBuilder = new StringBuilder();

        foreach (Operation operation in _service.ViewPeriodOperationsHistory(startDate, endDate))
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