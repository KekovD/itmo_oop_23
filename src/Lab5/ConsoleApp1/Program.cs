using Lab5.Infrastructure.DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;

public static void Main()
{
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
}