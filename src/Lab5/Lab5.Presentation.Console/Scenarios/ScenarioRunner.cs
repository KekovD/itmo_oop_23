using Lab5.Presentation.Console.Scenarios.Selectors;

namespace Lab5.Presentation.Console.Scenarios;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _providers;
    private readonly ISelector _selector;

    public ScenarioRunner(IEnumerable<IScenarioProvider> providers, ISelector selector)
    {
        _providers = providers;
        _selector = selector;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        IScenario scenario = _selector.ConsoleSelector(scenarios);

        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        return _providers.SelectMany(provider =>
        {
            provider.TryGetScenario(out IScenario? scenario);
            return scenario != null ? new[] { scenario } : Enumerable.Empty<IScenario>();
        });
    }
}