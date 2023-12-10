﻿using Lab5.Presentation.Console.Scenarios.Selectors;

namespace Lab5.Presentation.Console.Scenarios;

public class ScenarioGroup : IScenario
{
    private readonly IEnumerable<IScenario> _subScenarios;
    private readonly ISelector _selector = new Selector();

    public ScenarioGroup(string name, IEnumerable<IScenario> subScenarios)
    {
        Name = name;
        _subScenarios = subScenarios;
    }

    public string Name { get; }

    public async Task Run()
    {
        IScenario scenario = _selector.ConsoleSelector(_subScenarios);
        await scenario.Run();
    }
}