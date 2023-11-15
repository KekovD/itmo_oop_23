using Itmo.ObjectOrientedProgramming.Lab4.Renderables.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.States.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderables.Models;

public interface IFileShowCommandBuilder
{
    IFileShowCommandBuilder WithSubChain(FlagsFileShowSubChainLinkBase flags);
    IFileShowCommandBuilder WithContext(IContext context);
    FileShowCommand Crate();
}