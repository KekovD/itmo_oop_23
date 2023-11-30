using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Models;

public interface IFileDeleteCommandBuilder
{
    IFileDeleteCommandBuilder WithFlagsSubChain(FlagsFileDeleteSubChainLinqBase flagsChain);
    FileDeleteCommandLinq Create();
}