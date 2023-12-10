using System.Diagnostics.CodeAnalysis;
using Workshop5.Application.Contracts.Customers;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerScenarioProvider : IScenarioProvider
{
    private readonly ICustomerLoginService _loginService;

    public CustomerScenarioProvider(ICustomerLoginService loginService)
    {
        _loginService = loginService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        var subScenarios = new List<IScenario>
        {
            new CustomerLoginScenario(_loginService),
            new CustomerRegisterScenario(),
        };

        scenario = new ScenarioGroup("Customer", subScenarios);
        return true;
    }
}