﻿using System.Globalization;
using System.Text;
using Application.Models.Operations;
using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminViewPeriodOperationsHistoryScenario : IAdminLoginSubScenario
{
    private readonly IAdminViewPeriodOperationsHistoryService _service;

    public AdminViewPeriodOperationsHistoryScenario(IAdminViewPeriodOperationsHistoryService service)
    {
        _service = service;
    }

    public string Name => "View period operation history";

    public async Task Run()
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

        await foreach (Operation operation in _service.ViewPeriodOperationsHistory(startDate, endDate))
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