using Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileDeleteCommands.Models;

public interface IFileDeleteCommandBuilder
{
    IFileDeleteCommandBuilder WithContext(IContext context);
    IFileDeleteCommandBuilder WithFlagsSubChain(FlagsFileDeleteSubChainLinqBase flagsChain);
    IFileDeleteCommandBuilder WithFileSystemSubChain(DeleteFileSystemSubChainLinqBase fileSystemChain);
    FileDeleteCommand Create();
}