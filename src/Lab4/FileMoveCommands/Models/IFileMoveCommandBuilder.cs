using Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileMoveCommands.Models;

public interface IFileMoveCommandBuilder
{
    IFileMoveCommandBuilder WithContext(IContext context);
    IFileMoveCommandBuilder WithFlagsSubChain(FlagsFileMoveSubChainLinqBase flagsChain);
    IFileMoveCommandBuilder WithFileSystemSubChain(MoveFileSystemSubChainLinqBase fileSystemChain);
    FileMoveCommand Crate();
}