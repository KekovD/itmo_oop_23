using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;

public interface IModeFlagBuilder
{
    IModeFlagBuilder WithSubChain(ModeFlagSubChainLinkBase chain);
    IModeFlagBuilder WithContext(IContext context);
    ModeFlag Crate();
}