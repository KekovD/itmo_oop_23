using Itmo.ObjectOrientedProgramming.Lab4.Renderables.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderables.Models;

public interface IModeFlagBuilder
{
    IModeFlagBuilder AddFirstMode(ModeFlagSubChainLinkBase mode);
    ModeFlag Crate();
}