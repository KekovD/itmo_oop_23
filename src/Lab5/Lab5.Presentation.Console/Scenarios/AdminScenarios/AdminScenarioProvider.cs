using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminScenarioProvider : IScenarioProvider
{
    private readonly IEnumerable<IScenario> _subScenarios;

    public AdminScenarioProvider(IEnumerable<IScenario> subScenarios)
    {
        _subScenarios = subScenarios;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ScenarioGroup("Admin", _subScenarios);
        return true;
    }
}