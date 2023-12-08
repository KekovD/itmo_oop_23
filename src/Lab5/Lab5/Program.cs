// See https://aka.ms/new-console-template for more information

using Lab5.Infrastructure.DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();

collection
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    });

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

Console.WriteLine("...");