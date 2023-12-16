namespace Lab5.Presentation.Console.Scenarios;

public interface IScenario
{
    string Name { get; }

    void Run();
}