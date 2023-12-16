using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}