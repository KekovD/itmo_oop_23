using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Models;

public interface IFileRenameCommandBuilder
{
    IFileRenameCommandBuilder WithContext(IContext context);
    IFileRenameCommandBuilder WithFlagsSubChain(FlagsFileRenameSubChainLinqBase flagsChain);
    IFileRenameCommandBuilder WithFileSystemSubChain(RenameFileSystemSubChainLinqBase fileSystemChain);
    FileRenameCommand Crate();
}