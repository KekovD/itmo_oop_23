using Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileShowCommands.Models;

public interface IFileShowCommandBuilder
{
    IFileShowCommandBuilder WithSubChain(FlagsFileShowSubChainLinkBase chain);
    FileShowCommandLinq Create();
}