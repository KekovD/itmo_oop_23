using Application.Models.Accounts;
using Application.Models.Users;
using Lab5.Application.Extensions;
using Lab5.Infrastructure.DataAccess.Extensions;
using Lab5.Presentation.Console.Extensions;
using Lab5.Presentation.Console.Scenarios;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

ScenarioRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

scenarioRunner.AddAdmins(new User("Temp", UserRole.Admin), new AdminAccount(239), "241");

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}