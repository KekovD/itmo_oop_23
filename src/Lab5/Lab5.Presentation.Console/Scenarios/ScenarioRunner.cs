using Application.Models.Accounts;
using Application.Models.Users;
using Lab5.Application.Contracts.Admins;
using Lab5.Presentation.Console.Scenarios.Selectors;

namespace Lab5.Presentation.Console.Scenarios;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _providers;
    private readonly ISelector _selector;
    private readonly IAddAdminsService _service;

    public ScenarioRunner(IEnumerable<IScenarioProvider> providers, ISelector selector, IAddAdminsService service)
    {
        _providers = providers;
        _selector = selector;
        _service = service;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        IScenario scenario = _selector.ConsoleSelector(scenarios);

        scenario.Run();
    }

    public void AddAdmins(User user, AdminAccount adminAccounts, string plainTextPassword) =>
        _service.AddAdmin(user, adminAccounts, plainTextPassword);

    private IEnumerable<IScenario> GetScenarios()
    {
        return _providers.SelectMany(provider =>
        {
            provider.TryGetScenario(out IScenario? scenario);
            return scenario != null ? new[] { scenario } : Enumerable.Empty<IScenario>();
        });
    }
}