namespace Lab5.Presentation.Console.Scenarios.Selectors;

public interface ISelector
{
    IScenario ConsoleSelector(IEnumerable<IScenario> scenarios);
}