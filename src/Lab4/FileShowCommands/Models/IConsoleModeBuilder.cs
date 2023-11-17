using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;

public interface IConsoleModeBuilder
{
    IConsoleModeBuilder WithContext(IContext context);
    ConsoleLocalMode Create();
}