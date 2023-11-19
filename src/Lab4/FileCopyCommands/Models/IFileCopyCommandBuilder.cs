using Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileCopyCommands.Models;

public interface IFileCopyCommandBuilder
{
    IFileCopyCommandBuilder WithContext(IContext context);
    IFileCopyCommandBuilder WithFlagsSubChain(FlagsFileCopySubChainLinqBase flagsChain);
    FileCopyCommand Create();
}