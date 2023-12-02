using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Models;

public interface IFileMoveCommandBuilder
{
    IFileMoveCommandBuilder WithFlagsSubChain(FlagsFileMoveSubChainLinqBase flagsChain);
    FileMoveCommandLinq Create();
}