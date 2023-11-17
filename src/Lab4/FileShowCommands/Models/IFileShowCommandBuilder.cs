using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;

public interface IFileShowCommandBuilder
{
    IFileShowCommandBuilder WithSubChain(FlagsFileShowSubChainLinkBase chain);
    IFileShowCommandBuilder WithContext(IContext context);
    FileShowCommand Create();
}