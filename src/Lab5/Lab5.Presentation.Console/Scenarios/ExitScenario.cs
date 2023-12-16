namespace Lab5.Presentation.Console.Scenarios;

public class ExitScenario : IExitScenario
{
    public string Name => "Exit";

    public void Run() => Environment.Exit(0);
}