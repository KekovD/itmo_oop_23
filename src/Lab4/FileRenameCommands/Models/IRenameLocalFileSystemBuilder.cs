using Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.StatesCommands.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileRenameCommands.Models;

public interface IRenameLocalFileSystemBuilder
{
    IRenameLocalFileSystemBuilder WithContext(IContext context);
    RenameLocalFileSystem Crate();
}