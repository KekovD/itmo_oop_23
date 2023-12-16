using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Selectors;

public class Selector : ISelector
{
    public IScenario ConsoleSelector(IEnumerable<IScenario> scenarios)
    {
        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        return AnsiConsole.Prompt(selector);
    }
}