using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.AdminScenarios;

public class AdminScenarioProvider : IScenarioProvider
{
    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        var subScenarios = new List<IScenario>
        {
            new AdminLoginScenario(),
        };

        scenario = new ScenarioGroup("Admin", subScenarios);
        return true;
    }
}