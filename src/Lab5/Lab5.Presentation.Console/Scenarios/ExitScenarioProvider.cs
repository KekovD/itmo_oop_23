using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios;

public class ExitScenarioProvider : IScenarioProvider
{
    private readonly IExitScenario _scenario;

    public ExitScenarioProvider(IExitScenario scenario)
    {
        _scenario = scenario;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = _scenario;
        return true;
    }
}