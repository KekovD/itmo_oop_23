using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Models;

public interface IFileCopyCommandBuilder
{
    IFileCopyCommandBuilder WithFlagsSubChain(FlagsFileCopySubChainLinqBase flagsChain);
    FileCopyCommandLinq Create();
}