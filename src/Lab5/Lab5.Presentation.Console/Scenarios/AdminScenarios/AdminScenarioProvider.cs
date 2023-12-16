using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminScenarioProvider : IScenarioProvider
{
    private readonly IEnumerable<IAdminProviderSubScenario> _subScenarios;

    public AdminScenarioProvider(IEnumerable<IAdminProviderSubScenario> subScenarios)
    {
        _subScenarios = subScenarios;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ScenarioGroup("Admin", _subScenarios);
        return true;
    }
}