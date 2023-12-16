using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerScenarioProvider : IScenarioProvider
{
    private readonly IEnumerable<ICustomerProviderSubScenario> _subScenarios;

    public CustomerScenarioProvider(IEnumerable<ICustomerProviderSubScenario> subScenarios)
    {
        _subScenarios = subScenarios;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ScenarioGroup("Customer", _subScenarios);
        return true;
    }
}