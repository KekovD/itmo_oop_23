using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.CustomerScenarios;

public class CustomerScenarioProvider : IScenarioProvider
{
    private readonly IEnumerable<IScenario> _subScenarios;

    public CustomerScenarioProvider(IEnumerable<IScenario> subScenarios)
    {
        _subScenarios = subScenarios;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ScenarioGroup("Customer", _subScenarios);
        return true;
    }
}