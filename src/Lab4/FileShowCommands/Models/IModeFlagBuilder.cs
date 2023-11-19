using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;

public interface IModeFlagBuilder
{
    IModeFlagBuilder WithContext(IContext context);
    ModeFlag Create();
}