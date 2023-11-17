using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeCommands.Models;

public interface IConsoleDepthFlagBuilder
{
    IConsoleDepthFlagBuilder WithContext(IContext context);
    IConsoleDepthFlagBuilder WithFolderSymbol(string symbol);
    IConsoleDepthFlagBuilder WithFileSymbol(string symbol);
    IConsoleDepthFlagBuilder WithIndentation(string symbol);
    ConsoleDepthFlag Create();
}